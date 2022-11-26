using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetNoelAPI.Interfaces;
using ProjetNoelAPI.Models;
using ProjetNoelAPI.Models.DTO.Down;

namespace ProjetNoelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region privates
        private readonly IUserServices _userServices;
        #endregion

        #region CTOR
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion

        #region methods

        #region Login
        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] string login, [FromQuery] string password)
        {
            // If the login or the password is null we return an error
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return BadRequest();

            // Get the administrator in the database
            UserDtoDownToken? user = await _userServices.Login(login, password);

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
            User user = await _userServices.CreateUser(userDtoDown);

            return user == null ? NotFound() : Ok(user);
        }
        #endregion

        #endregion
    }
}
