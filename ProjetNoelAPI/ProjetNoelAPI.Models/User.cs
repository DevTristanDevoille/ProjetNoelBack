using ProjetNoelAPI.Models.Base;
using System.Text.Json.Serialization;

namespace ProjetNoelAPI.Models
{
    public class User : BaseModel
    {
        public string? UserName { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public string? Salt { get; set; }
        [JsonIgnore]
        public List<Squad>? Squades { get; set; }
        [JsonIgnore]
        public List<Liste>? Listes { get; set; }

    }
}
