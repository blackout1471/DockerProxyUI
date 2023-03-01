using DockerProxy.DataTransferObjects;

namespace DockerProxy.Providers;

public interface IContainerProvider
{
    public Task<IEnumerable<ContainerDto>> GetAllContainersAsync();

    public Task<IEnumerable<ImageDto>> GetAllImagesAsync();

    public Task<IEnumerable<VolumeDto>> GetAllVolumesAsync();

    public Task CreateContainerAsync();
    public Task CreateImageAsync();
    public Task CreateVolumeAsync();

    public Task DeleteContainerAsync();
    public Task DeleteImageAsync();
    public Task DeleteVolumeAsync();

}
