using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SpaWebPortofolio.Interfaces
{
    public interface IImageCuttingService
    {
        public Task ChangeResolution(IFormFile file, int width, int height, string savePath);
    }
}