using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Contracts.UnitOfWork;
using ProjetNoelAPI.Models;
using ProjetNoelAPI.Models.DTO.Down;
using ProjetNoelAPI.Services.Commons;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace ProjetNoelAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApiSettings? _apiSettings;
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _uow;

        public UserService(IOptions<ApiSettings> apiSettings,IJwtService jwtService,IUnitOfWork uow)
        {
            _apiSettings = apiSettings.Value;
            _jwtService = jwtService;
            _uow = uow;
        }

        public async Task<UserDtoDownToken?> Login(string username, string password)
        {
            Expression<Func<User, bool>> requete = RequestExpression<User>.CreateRequetWithOneParam("UserName", username);
            User? user = await _uow.UserRepository.GetAsync(requete);

            if (user == null)
                return null;

            string hashedPassword = await HashPasswordWithSalt(password, Convert.FromBase64String(user.Salt));

            if (user.Password == hashedPassword)
            {
                var token = _jwtService.GenerateJwtToken(user);
                return new UserDtoDownToken() { User = user, Token = token };
            }
            else
                return null;
        }


        public async Task<UserDtoDownToken> CreateUser(UserDtoDown userDtoDown)
        {

            byte[]? salt = GenerateSalt();
            string? hashedPassword = await HashPasswordWithSalt(userDtoDown.Password, salt);

            var usernameResult = RequestExpression<User>.CreateRequetWithTwoParam("UserName", userDtoDown.UserName, "Email", userDtoDown.Email);

            User verifyUser = await _uow.UserRepository.GetAsync(usernameResult);

            if(verifyUser != null)
                return null;

            User user = new User()
            {
                UserName = userDtoDown.UserName,
                Password = hashedPassword,
                Avatar = userDtoDown.Avatar,
                Email = userDtoDown.Email,
                Salt = Convert.ToBase64String(salt)
            };


            _uow.UserRepository.Add(user);
            _uow.Commit();

            var token = _jwtService.GenerateJwtToken(user);
            Expression<Func<User, bool>> requete = RequestExpression<User>.CreateRequetWithOneParam("UserName", userDtoDown.UserName);
            User? userResult = await _uow.UserRepository.GetAsync(requete);
            return new UserDtoDownToken() { User = userResult, Token = token };
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return salt;
        }

        private static Task<string> HashPasswordWithSalt(string password, byte[] salt)
        {
            // obtenir une clé de 256-bit (en utilisant HMACSHA256 sur 100,000 itérations)
            return Task.FromResult(Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)));
        }
    }
}
