using DockerProxy.DataTransferObjects;
using DockerProxy.Models.ContainerConfigurations;

namespace DockerProxy.Providers;

public interface IContainerProvider
{
    public Task<IEnumerable<ContainerDto>> GetAllContainersAsync();

    public Task<IEnumerable<ImageDto>> GetAllImagesAsync();

    public Task<IEnumerable<VolumeDto>> GetAllVolumesAsync();

    public Task CreateContainerAsync(CreateContainerConfiguration config);
    public Task CreateImageAsync();
    public Task CreateVolumeAsync();

    public Task DeleteContainerAsync(string containerId);
    public Task DeleteImageAsync(string imageId);
    public Task DeleteVolumeAsync(string volumeId);

    public Task StopContainerAsync(string containerId);

    public Task StartContainerAsync(string containerId);

}
