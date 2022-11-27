namespace ProjetNoelAPI.Contracts.Services
{
    public interface ISquadService
    {
        public Task<bool> FindSquad(string? code, string? token);
        public Task<string>? CreateSquad(string token);
    }
}
