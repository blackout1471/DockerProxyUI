using DockerProxy.Managers;
using DockerProxy.Models;

namespace DockerProxy.Services;

public class ContainerService
{
    public IEnumerable<Container> Containers { get; private set;}
    public IEnumerable<Image> Images { get; private set; }

    private readonly IContainerManager _ContainerManager;
    private readonly IImageManager _ImageManager;

    public ContainerService(IContainerManager containerManager, IImageManager imageManager)
    {
        _ContainerManager = containerManager;
        _ImageManager = imageManager;
    }

    public async Task GetAllContainerData()
    {
        Containers = await _ContainerManager.GetContainersAsync()
            .ContinueWith(x => x.Result.ToList());

        Images = await _ImageManager.GetImagesAsync()
            .ContinueWith(x => x.Result.ToList()); ;
        
        foreach (var container in Containers)
        {
            var image = Images.FirstOrDefault(x => x.Id == container.ImageId);
            container.Image = image;
        }
    }
}
