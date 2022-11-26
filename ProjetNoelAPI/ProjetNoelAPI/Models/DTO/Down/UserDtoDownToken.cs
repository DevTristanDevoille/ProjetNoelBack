namespace ProjetNoelAPI.Models.DTO.Down
{
    public class UserDtoDownToken
    {
        public User? User { get; set; }

        public string? Token { get; set; }

        public UserDtoDownToken(User user,string token)
        {
            User = user;
            Token = token;
        }

        public UserDtoDownToken()
        {
        }
    }
}
