using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.Contracts.Services
{
    public interface ISquadService
    {
        public Task<bool> FindSquad(string? code, string? token);
        public Task<Squad>? CreateSquad(string token,string name);
        public Task<List<Squad>> GetAllSquad(string token);
    }
}
