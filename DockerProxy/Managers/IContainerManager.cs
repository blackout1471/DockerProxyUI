using DockerProxy.Models;

namespace DockerProxy.Managers;

public interface IContainerManager
{
    public Task<IEnumerable<Container>> GetContainersAsync();
}
