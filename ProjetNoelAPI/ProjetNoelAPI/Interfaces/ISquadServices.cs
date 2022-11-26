namespace ProjetNoelAPI.Interfaces
{
    public interface ISquadServices
    {
        public Task<bool> FindSquad(string? code,string? token);
        public Task<string>? CreateSquad(string token);
    }
}
