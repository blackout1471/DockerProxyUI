using Docker.DotNet;
using Docker.DotNet.Models;
using DockerProxy.DataTransferObjects;

namespace DockerProxy.Providers;

public class DockerContainerProvider : IContainerProvider
{

    private readonly IDockerClient _client;

    public DockerContainerProvider(Uri connection)
    {
        _client = new DockerClientConfiguration(connection)
            .CreateClient();
    }

    public async Task<IEnumerable<ContainerDto>> GetAllContainersAsync()
    {
        var containers = await _client.Containers.ListContainersAsync(new ContainersListParameters()
        {
            All = true
        });

        var containerDtos = containers.Select(x => new ContainerDto()
        {
            Id = x.ID,
            Names = x.Names,
            Image = x.Image,
            ImageId = x.ImageID,
            Command = x.Command,
            Created = x.Created,
            Ports = x.Ports.Select(p => (byte)p.PublicPort).ToList(),
            SizeRw = x.SizeRw,
            SizeRootFs = x.SizeRootFs,
            Labels = x.Labels,
            State = x.State,
            Status = x.Status,
        });

        return containerDtos;
    }
}
