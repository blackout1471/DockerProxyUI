using DockerProxy.Models;

namespace DockerProxy.Managers;

public interface IImageManager
{
    public Task<IEnumerable<Image>> GetImagesAsync();
}
