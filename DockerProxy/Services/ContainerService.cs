using DockerProxy.Managers;
using DockerProxy.Models;
using DockerProxy.Models.ContainerConfigurations;

namespace DockerProxy.Services;

public class ContainerService : IContainerService
{
    public IEnumerable<Container> Containers { get; private set; }
    public IEnumerable<Image> Images { get; private set; }
    public IEnumerable<Volume> Volumes { get; private set; }

    private readonly IContainerManager _ContainerManager;
    private readonly IImageManager _ImageManager;
    private readonly IVolumeManager _VolumeManager;

    public ContainerService(IContainerManager containerManager,
                            IImageManager imageManager,
                            IVolumeManager volumeManager)
    {
        _ContainerManager = containerManager;
        _ImageManager = imageManager;
        _VolumeManager = volumeManager;
    }

    public async Task FetchDataAsync()
    {
        Containers = await _ContainerManager.GetContainersAsync()
            .ContinueWith(x => x.Result.ToList());

        Images = await _ImageManager.GetImagesAsync()
            .ContinueWith(x => x.Result.ToList());

        Volumes = await _VolumeManager.GetVolumesAsync()
            .ContinueWith(x => x.Result.ToList());
    }

    public async Task StartContainerAsync(string containerId)
    {
        await _ContainerManager.StartContainerAsync(containerId);
    }

    public async Task StopContainerAsync(string containerId)
    {
        await _ContainerManager.StopContainerAsync(containerId);
    }

    public async Task CreateContainerAsync(CreateContainerConfiguration config)
    {
        await _ContainerManager.CreateContainerAsync(config);
    }
}
