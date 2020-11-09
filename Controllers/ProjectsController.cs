using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaWebPortofolio.Data;
using SpaWebPortofolio.Interfaces;

namespace SpaWebPortofolio.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IImageCuttingService _imageCuttingService;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _appDbContext;

        private const int DISPLAY_IMAGE_HEIGHT = 1920;
        private const int DISPALY_IMAGE_WIDTH = 1080;

        public ProjectsController(IImageCuttingService imageCuttingService, IWebHostEnvironment env, AppDbContext appDbContext)
        {
            _imageCuttingService = imageCuttingService;
            _env = env;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _appDbContext.Projects
                .Where(x => x.Deleted == false)
                .Select(x => new ProjectViewModel()
                {
                    Title = x.Title,
                    Description = x.Description,
                    DemoLink = x.DemoLink,
                    GithubLink = x.GithubLink,
                    Features = x.Features,
                    Images = x.Images.Select(i => new ProjectImageViewModel()
                    {
                        Image = i.Image,
                        ProjectId = i.ProjectId,
                    }).ToList()
                })
                .ToList();
            
            return Ok(projects);
        }
        
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(ProjectForm projectForm)
        {
            var newId = Guid.NewGuid();

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