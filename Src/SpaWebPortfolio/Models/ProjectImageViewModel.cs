namespace SpaWebPortofolio.Controllers
{
    public class ProjectImageViewModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int ProjectId { get; set; }
    }
}