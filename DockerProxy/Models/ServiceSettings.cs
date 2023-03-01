namespace DockerProxy.Models;

public class ServiceSettings
{
    public Uri ConnectionUri { get; set; } = new Uri("npipe://./pipe/docker_engine");
    public int FetchContainerDataEverySeconds { get; set; } = 5;
}
