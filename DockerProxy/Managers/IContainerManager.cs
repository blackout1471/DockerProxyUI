using DockerProxy.Models;

namespace DockerProxy.Managers;

public interface IContainerManager
{
    public Task<IEnumerable<Container>> GetContainersAsync();

    public Task StartContainerAsync(string containerId);

    public Task StopContainerAsync(string containerId);
}
