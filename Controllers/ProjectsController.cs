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

        private const int DisplayImageHeight = 1920;
        private const int DisplayImageWidth = 1080;

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
                .AsNoTracking()
                .Where(x => x.Deleted == false)
                .Select(x => new ProjectViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    DisplaySize = x.DisplaySize,
                    DemoLink = x.DemoLink,
                    GithubLink = x.GithubLink,
                    Features = x.Features,
                    Images = x.Images.Select(i => new ProjectImageViewModel()
                    {
                        Id = i.Id,
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
            var newProject = new Project()
            {
                Title = projectForm.Title,
                Description = projectForm.Description,
                DisplaySize = projectForm.DisplaySize,
                DemoLink = projectForm.Description,
                GithubLink = projectForm.Description,
                Features = projectForm.Features,
            };
            

            _appDbContext.Projects.Add(newProject);
            _appDbContext.SaveChanges();

            return Ok(newProject);
        }

        [HttpPost("upload/screenshot/{id}")]
        public async Task<IActionResult> UploadProjectImages(List<IFormFile> screenShots, int id)
        {
            var project = _appDbContext.Projects.FirstOrDefault(x => x.Id == id);
            
            if (screenShots.Count > 0 && project != null)
            {
                var projectImages = await ConvertImages(screenShots);
                project.Images = projectImages;

                await _appDbContext.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }
        

        [HttpPut("edit/project/{id}")]
        public IActionResult EditProject(int id, ProjectForm projectForm)
        {
            var project = _appDbContext
                .Projects.FirstOrDefault(x => x.Id == id);

            if (project != null)
            {
                project.Title = projectForm.Title;
                project.Description = projectForm.Description;
                project.GithubLink = projectForm.GithubLink;
                project.DemoLink = projectForm.DemoLink;
                project.Features = projectForm.Features;
                project.DisplaySize = projectForm.DisplaySize;
                
                _appDbContext.SaveChanges();
                return Accepted(project);
            }
            
            return NotFound();
        }

        [HttpPut("edit/projectImage/{id}")]
        public async Task<IActionResult> EditImage(int id, IFormFile screenShot)
        {
            var processedImages = await ConvertImages(new List<IFormFile> {screenShot});
            var imageToEdit = _appDbContext.ProjectImages.FirstOrDefault(x => x.Id == id);

            if (imageToEdit != null)
            {
                imageToEdit.Image = processedImages[0].Image;
                await _appDbContext.SaveChangesAsync();
                return Accepted();
            }

            return NotFound();
        }

        [HttpDelete("delete/project/{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _appDbContext.Projects.FirstOrDefault(x => x.Id == id);

            if (project != null)
            {
                _appDbContext.Projects.Remove(project);
                _appDbContext.SaveChanges();
                return Accepted();
            }

            return NotFound();
        }
        
        [HttpDelete("delete/projectImage/{id}")]
        public IActionResult DeleteImage(int id)
        {
            var image = _appDbContext.ProjectImages.FirstOrDefault(x => x.Id == id);

            if (image != null)
            {
                _appDbContext.ProjectImages.Remove(image);
                _appDbContext.SaveChanges();
                return Accepted();
            }

            return NotFound();
        }
        
        private async Task<List<ProjectImage>> ConvertImages(List<IFormFile> images)
        {
            List<ProjectImage> bigProjectImages = new List<ProjectImage>();

            foreach (var screenShot in images)
            {
                var tempSavePath = Path.Combine(_env.WebRootPath, Path.GetRandomFileName() + ".jpg");
                
                var promise = _imageCuttingService.ChangeResolution(screenShot, DisplayImageWidth,
                    DisplayImageHeight, tempSavePath);

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