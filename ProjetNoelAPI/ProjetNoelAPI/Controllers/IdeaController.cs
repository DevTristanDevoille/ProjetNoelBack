using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        #region Privates
        private readonly IIdeaService _ideaService;
        #endregion

        #region CTOR
        public IdeaController(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }
        #endregion

        #region methods

        #region GetIdeas
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetIdeas([FromQuery]int idListe)
        {
            List<Idea> ideas = await _ideaService.GetIdeas(idListe);
            return ideas == null ? NotFound() : Ok(ideas);
        }
        #endregion

        #region CreateIdeas
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateIdeas([FromBody] List<Idea> ideas, [FromQuery] int idListe)
        {
            List<Idea> resultIdeas = await _ideaService.CreateIdea(ideas, idListe);
            return resultIdeas == null ? NotFound() : Ok(resultIdeas);
        }
        #endregion

        #region UpdateIdeas
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateIdeas([FromBody] List<Idea> ideas, [FromQuery] int idListe)
        {
            List<Idea> resultIdeas = await _ideaService.UpdateIdea(ideas, idListe);
            return resultIdeas == null ? NotFound() : Ok(resultIdeas);
        }
        #endregion

        #region DeleteIdeas
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteIdeas([FromQuery]int idIdea)
        {
            Idea resultIdea = await _ideaService.DeleteIdea(idIdea);
            return resultIdea == null ? NotFound() : Ok(resultIdea);
        }
        #endregion


        #endregion
    }
}
