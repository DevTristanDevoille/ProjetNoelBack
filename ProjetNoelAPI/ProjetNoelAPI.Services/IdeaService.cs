using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Contracts.UnitOfWork;
using ProjetNoelAPI.Models;
using ProjetNoelAPI.Services.Commons;

namespace ProjetNoelAPI.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IUnitOfWork _uow;

        public IdeaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Idea>> CreateIdea(List<Idea> ideas)
        {
            _uow.IdeaRepository.AddRange(ideas);
            _uow.Commit();
            return ideas;
        }

        public async Task<Idea> DeleteIdea(int id)
        {
            Idea idea = _uow.IdeaRepository.Get(id);
            _uow.IdeaRepository.Remove(idea);
            return idea;
        }

        public async Task<List<Idea>> GetIdeas(int idListe)
        {
            var request = RequestExpression<Idea>.CreateRequetWithOneParam("IdListe", idListe.ToString());
            List<Idea> ideas = _uow.IdeaRepository.GetAll(request).ToList();
            return ideas;
        }

        public async Task<List<Idea>> UpdateIdea(List<Idea> ideas)
        {
            _uow.IdeaRepository.UpdateRange(ideas);
            _uow.Commit();
            return ideas;
        }
    }
}
