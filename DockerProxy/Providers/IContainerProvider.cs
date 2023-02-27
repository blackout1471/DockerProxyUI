using DockerProxy.DataTransferObjects;

namespace DockerProxy.Providers;

public interface IContainerProvider
{
    public Task<IEnumerable<ContainerDto>> GetAllContainersAsync();
}
