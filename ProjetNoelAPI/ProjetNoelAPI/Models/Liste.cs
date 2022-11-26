using ProjetNoelAPI.Models.Base;

namespace ProjetNoelAPI.Models
{
    public class Liste : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Idea>? Ideas { get; set; }
        public List<User>? Users { get; set; }
    }
}
