using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.Contracts.Services
{
    public interface IListeService
    {
        public Task<List<Liste>> GetListe(string? token);
        public Task<Liste> CreateListe(Liste liste, string? token);
        public Task<bool> DeleteListe(string? token, int? idListe);
        public Task<bool> UpdateListe(Liste liste, string? token);
    }
}
