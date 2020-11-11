using System.Collections.Generic;
using SpaWebPortofolio.Enums;

namespace SpaWebPortofolio.Controllers
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProjectDisplaySize DisplaySize { get; set; }
        public string Description { get; set; }
        public string DemoLink { get; set; }
        public string GithubLink { get; set; }
        public string[] Features { get; set; }
        public List<ProjectImageViewModel> Images { get; set; }
    }
}