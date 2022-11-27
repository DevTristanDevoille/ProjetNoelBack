using ProjetNoelAPI.Models.Base;

namespace ProjetNoelAPI.Models
{
    public class Squad : BaseModel
    {
        public List<User>? Users { get; set; }
        public string? Code { get; set; }
    }
}
