using ProjetNoelAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetNoelAPI.Models
{
    public class Squad : BaseModel
    {
        [JsonIgnore]
        public List<User>? Users { get; set; }
        [JsonIgnore]
        public List<Liste>? Listes { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Code { get; set; }

    }
}
