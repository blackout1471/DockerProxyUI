using DockerProxy.DataTransferObjects;
using DockerProxy.Models;
using DockerProxy.Models.ContainerConfigurations;
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
        return Convert(containerDtos);

    }
    public async Task StartContainerAsync(string containerId)
    {
        await _containerProvider.StartContainerAsync(containerId);
    }

    public async Task StopContainerAsync(string containerId)
    {
        await _containerProvider.StopContainerAsync(containerId);
    }

    public async Task CreateContainerAsync(CreateContainerConfiguration config)
    {
        await _containerProvider.CreateContainerAsync(config);
    }

    private static IEnumerable<Container> Convert(IEnumerable<ContainerDto> containerDtos)
    {
        return containerDtos.Select(x => new Container()
        {
            Id = x.Id,
            Name = x.Names.First().Remove(0, 1),
            ImageName = x.Image,
            ImageId = x.ImageId,
            Created = x.Created,
            Ports = Convert(x.Ports),
            State = x.State,
            Status = x.Status,
        });
    }

    private static List<ContainerPort> Convert(IEnumerable<PortDto> ports)
    {
        return ports.Select(p => new ContainerPort()
        {
            Type = p.Type,
            IP = p.IP,
            PrivatePort = p.PrivatePort,
            PublicPort = p.PublicPort
        }).ToList();
    }

}
