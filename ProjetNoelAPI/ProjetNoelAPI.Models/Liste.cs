using ProjetNoelAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetNoelAPI.Models
{
    public class Liste : BaseModel
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public int? IdCreator { get; set; }
        [JsonIgnore]
        public List<Idea>? Ideas { get; set; }
        [JsonIgnore]
        public List<User>? Users { get; set; }
    }
}
