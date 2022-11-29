using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Models;

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
        public async Task<IActionResult> CreateSquad([FromBody] string name)
        {
            string? token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            string result = await _squadServices.CreateSquad(token,name);
            if(result != "")
                return Ok(result);
            else
                return BadRequest();
        }
        #endregion

        #region GetAllSquad
        [HttpGet]
        [Authorize]
        [Route("/Squad/GetAll")]
        public async Task<IActionResult> GetAllSquad()
        {
            string? token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            List<Squad> result = await _squadServices.GetAllSquad(token);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        #endregion

        #endregion
    }
}
