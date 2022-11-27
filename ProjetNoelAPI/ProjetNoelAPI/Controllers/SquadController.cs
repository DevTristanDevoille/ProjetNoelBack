using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetNoelAPI.Contracts.Services;

namespace ProjetNoelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SquadController : ControllerBase
    {
        #region privates
        private readonly ISquadService _squadServices;
        #endregion

        #region CTOR
        public SquadController(ISquadService squadServices)
        {
            _squadServices = squadServices;
        }
        #endregion

        #region Methods

        #region RegisterInSquad
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RegisterInSquad([FromQuery] string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest();

            string? token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            bool result = await _squadServices.FindSquad(code,token);

            return Ok(result);
        }
        #endregion

        #region CreateSquad
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSquad()
        {
            string? token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            string result = await _squadServices.CreateSquad(token);
            if(result != "")
                return Ok(result);
            else
                return BadRequest();
        }
        #endregion


        #endregion
    }
}
