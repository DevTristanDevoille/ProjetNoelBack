using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListeController : ControllerBase
    {
        #region privates
        private readonly IListeService _listeService;
        #endregion

        #region CTOR
        public ListeController(IListeService listeService)
        {
            _listeService = listeService;
        }
        #endregion

        #region Methods

        #region CreateListe
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateListe([FromBody] Liste liste)
        {
            string? token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            Liste result = await _listeService.CreateListe(liste,token) ;

            return Ok(result);
        }
        #endregion

        #region GetListe
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListe()
        {
            string? token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            List<Liste> result = await _listeService.GetListe(token);

            return Ok(result);
        }
        #endregion

        #region DeleteListe
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteListe([FromQuery] int idListe)
        {
            string? token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            bool result = await _listeService.DeleteListe(token,idListe);

            return Ok(result);
        }
        #endregion

        #endregion
    }
}
