using ProjetNoelAPI.Models;
using ProjetNoelAPI.Models.DTO.Down;

namespace ProjetNoelAPI.Interfaces
{
    public interface IUserServices
    {
        public Task<User> CreateUser(UserDtoDown userDtoDown);
        Task<UserDtoDownToken?> Login(string username, string password);
    }
}
