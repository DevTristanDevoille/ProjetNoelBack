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
            await _uow.CommitAsync();
            return ideas;
        }

        public async Task<Idea> DeleteIdea(int id)
        {
            Idea idea = _uow.IdeaRepository.Get(id);
            _uow.IdeaRepository.Remove(idea);
            await _uow.CommitAsync();
            return idea;
        }

        public async Task<List<Idea>> GetIdeas(int idListe)
        {
            var request = RequestExpression<Idea>.CreateRequetWithOneParam("IdListe", idListe.ToString());
            IEnumerable<Idea> ideas = await _uow.IdeaRepository.GetAllAsync(request);
            return ideas.ToList();
        }

        public async Task<List<Idea>> UpdateIdea(List<Idea> ideas)
        {
            foreach (var item in ideas)
            {
                var result = _uow.IdeaRepository.Get(item.Id);
                if(result.IsTake == true)
                {
                    item.IsTake = true;
                }
            }
            _uow.IdeaRepository.UpdateRange(ideas);
            await _uow.CommitAsync();
            return ideas;
        }
    }
}
