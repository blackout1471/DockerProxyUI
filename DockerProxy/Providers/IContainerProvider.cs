using DockerProxy.DataTransferObjects;

namespace DockerProxy.Providers;

public interface IContainerProvider
{
    public Task<IEnumerable<ContainerDto>> GetAllContainersAsync();

    public Task<IEnumerable<ImageDto>> GetAllImagesAsync();

    public Task<IEnumerable<VolumeDto>> GetAllVolumesAsync();
}
