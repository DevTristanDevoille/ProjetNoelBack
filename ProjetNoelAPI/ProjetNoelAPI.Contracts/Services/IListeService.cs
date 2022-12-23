using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.Contracts.Services
{
    public interface IListeService
    {
        public List<Liste> GetListe(int idSquad);
        public Liste GetListeWithIdListe(int idListe);
        public Task<Liste> CreateListe(Liste liste, string? token);
        public Task<bool> DeleteListe(string? token, int idListe);
        public Task<bool> UpdateListe(Liste liste);
    }
}
