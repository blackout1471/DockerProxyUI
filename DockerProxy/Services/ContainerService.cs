using DockerProxy.Managers;
using DockerProxy.Models;

namespace DockerProxy.Services;

public class ContainerService
{
    public IEnumerable<Container> Containers { get; private set; }
    public IEnumerable<Image> Images { get; private set; }
    public IEnumerable<Volume> Volumes { get; private set; }

    private readonly IContainerManager _ContainerManager;
    private readonly IImageManager _ImageManager;
    private readonly IVolumeManager _VolumeManager;

    public ContainerService(IContainerManager containerManager, IImageManager imageManager, IVolumeManager volumeManager)
    {
        _ContainerManager = containerManager;
        _ImageManager = imageManager;
        _VolumeManager = volumeManager;
    }

    public async Task GetAllContainerData()
    {
        Containers = await _ContainerManager.GetContainersAsync()
            .ContinueWith(x => x.Result.ToList());

        Images = await _ImageManager.GetImagesAsync()
            .ContinueWith(x => x.Result.ToList());

        Volumes = await _VolumeManager.GetVolumesAsync()
            .ContinueWith(x => x.Result.ToList());

        foreach (var container in Containers)
        {
            var image = Images.FirstOrDefault(x => x.Id == container.ImageId);

            if (image == null)
                continue;

            image.Containers.Add(container);
            container.Image = image;
        }
    }
}
