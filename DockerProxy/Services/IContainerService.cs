using DockerProxy.Models;

namespace DockerProxy.Services;

public interface IContainerService
{
    public IEnumerable<Container> Containers { get; }
    public IEnumerable<Image> Images { get; }
    public IEnumerable<Volume> Volumes { get; }

    public Task FetchDataAsync();

    public Task StartContainerAsync(string containerId);
    public Task StopContainerAsync(string containerId);
}