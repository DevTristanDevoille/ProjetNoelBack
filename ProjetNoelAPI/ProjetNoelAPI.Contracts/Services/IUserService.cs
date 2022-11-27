using ProjetNoelAPI.Models;
using ProjetNoelAPI.Models.DTO.Down;

namespace ProjetNoelAPI.Contracts.Services
{
    public interface IUserService
    {
        public Task<User> CreateUser(UserDtoDown userDtoDown);
        Task<UserDtoDownToken?> Login(string username, string password);
    }
}
