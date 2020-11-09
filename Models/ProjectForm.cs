using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using SpaWebPortofolio.Enums;

namespace SpaWebPortofolio.Controllers
{
    public class ProjectForm
    {
        public string Title { get; set; }
        public ProjectDisplaySize DisplaySize { get; set; }
        public IFormFile ScreenShots { get; set; }
        public string[] Features { get; set; }
        public string Description { get; set; }
        public string GithubLink { get; set; }
        public string DemoLink { get; set; }
    }
}