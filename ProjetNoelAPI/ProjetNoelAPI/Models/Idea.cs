using ProjetNoelAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetNoelAPI.Models
{
    public class Idea : BaseModel
    {
        [Required]
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? UrlIdea { get; set; }
        [Required]
        public bool? IsTake { get; set; }
        [JsonIgnore]
        public Liste? Liste { get; set; }
        [JsonIgnore]
        public int IdListe { get; set; }
    }
}
