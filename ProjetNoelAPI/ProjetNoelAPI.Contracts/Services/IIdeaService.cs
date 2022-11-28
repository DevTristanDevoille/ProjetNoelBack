using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.Contracts.Services
{
    public interface IIdeaService
    {
        public Task<List<Idea>> GetIdeas(int idListe);
        public Task<List<Idea>> CreateIdea(List<Idea> ideas);
        public Task<List<Idea>> UpdateIdea(List<Idea> ideas);
        public Task<Idea> DeleteIdea(int id);
    }
}
