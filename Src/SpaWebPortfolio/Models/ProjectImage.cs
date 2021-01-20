namespace SpaWebPortofolio.Controllers
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}