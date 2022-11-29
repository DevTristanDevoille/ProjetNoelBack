using Microsoft.AspNetCore.Mvc;
using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Models.DTO.Down;
using ProjetNoelAPI.Models.DTO.Up;

namespace ProjetNoelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region privates
        private readonly IUserService _userServices;
        #endregion

        #region CTOR
        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }
        #endregion

        #region methods

        #region Login
        [HttpPost]
        [Route("Connexion")]
        public async Task<IActionResult> Login([FromBody] UserDtoUp userDtoUp)
        {
            // If the login or the password is null we return an error
            if (string.IsNullOrEmpty(userDtoUp.UserName) || string.IsNullOrEmpty(userDtoUp.Password))
                return BadRequest();

            // Get the administrator in the database
            UserDtoDownToken? user = await _userServices.Login(userDtoUp.UserName, userDtoUp.Password);

            // If the admin are found we return all infos else we return not found
            return user == null ? NotFound() : Ok(
                new UserDtoDownToken
                {
                    User = user.User,
                    Token = user.Token,
                }
            );
        }
        #endregion

        #region CreateUser
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateUser([FromBody] UserDtoDown userDtoDown)
        {
            UserDtoDownToken user = await _userServices.CreateUser(userDtoDown);

            return user == null ? NotFound() : Ok(user);
        }
        #endregion

        #endregion
    }
}
