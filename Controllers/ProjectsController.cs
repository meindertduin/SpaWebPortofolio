using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaWebPortofolio.Interfaces;

namespace SpaWebPortofolio.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IImageCuttingService _imageCuttingService;
        private readonly IWebHostEnvironment _env;

        private const int DISPLAY_IMAGE_HEIGHT = 1920;
        private const int DISPALY_IMAGE_WIDTH = 1080;

        public ProjectsController(IImageCuttingService imageCuttingService, IWebHostEnvironment env)
        {
            _imageCuttingService = imageCuttingService;
            _env = env;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            return Ok();
        }
        
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(ProjectForm projectForm)
        {
            var newProject = new Project()
            {
                Title = projectForm.Title,
                Description = projectForm.Description,
                DisplaySize = projectForm.DisplaySize,
                DemoLink = projectForm.Description,
                GithubLink = projectForm.Description,
                Features = projectForm.Features,
            };

            if (projectForm.ScreenShots != null)
            {
                var projectImages = await ConvertImages(projectForm.ScreenShots);
                newProject.Images = projectImages;
            }

            return Accepted(newProject);
        }

        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, ProjectForm projectForm)
        {
            return Accepted();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Accepted();
        }
        
        private async Task<List<ProjectImage>> ConvertImages(List<IFormFile> images)
        {
            List<ProjectImage> bigProjectImages = new List<ProjectImage>();

            foreach (var screenShot in images)
            {
                var tempSavePath = Path.Combine(_env.WebRootPath, Path.GetRandomFileName() + ".jpg");
                
                var promise = _imageCuttingService.ChangeResolution(screenShot, DISPALY_IMAGE_WIDTH,
                    DISPLAY_IMAGE_HEIGHT, tempSavePath);

                await promise;
                
                using (var reader = new BinaryReader(System.IO.File.OpenRead(tempSavePath)))
                {
                    var bytes = reader.ReadBytes((int) screenShot.Length);
                    
                    bigProjectImages.Add(new ProjectImage()
                    {
                        Image = bytes,
                    });
                }
                    
                System.IO.File.Delete(tempSavePath);
            }

            return bigProjectImages;
        }
    }
}