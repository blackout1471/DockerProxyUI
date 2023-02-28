using DockerProxy.Models;
using DockerProxy.Providers;

namespace DockerProxy.Managers;

public class ContainerManager : IContainerManager
{
    private readonly IContainerProvider _containerProvider;

    public ContainerManager(IContainerProvider containerProvider)
    {
        _containerProvider = containerProvider;
    }

    public async Task<IEnumerable<Container>> GetContainersAsync()
    {
        var containerDtos = await _containerProvider.GetAllContainersAsync();

        return containerDtos.Select(x => new Container()
        {
            Id = x.Id,
            Name = x.Names.First(),
            ImageName = x.Image,
            ImageId = x.ImageId,
            Created = x.Created,
            Ports = x.Ports,
            State = x.State,
            Status = x.Status,
        });


    }
}
