﻿using Docker.DotNet;
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
            All = true,
            Size = true
        });

        return Convert(containers);
    }

    public async Task<IEnumerable<ImageDto>> GetAllImagesAsync()
    {
        var images = await _client.Images.ListImagesAsync(new ImagesListParameters()
        {
            All = true
        });

        return Convert(images);
    }

    public async Task<IEnumerable<VolumeDto>> GetAllVolumesAsync()
    {
        var volumes = await _client.Volumes.ListAsync(new VolumesListParameters());

        return Convert(volumes);
    }

    public Task CreateContainerAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateImageAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateVolumeAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteContainerAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteImageAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteVolumeAsync()
    {
        throw new NotImplementedException();
    }

    private static IEnumerable<ContainerDto> Convert(IList<ContainerListResponse> containers)
    {
        return containers.Select(x => new ContainerDto()
        {
            Id = x.ID,
            Names = x.Names,
            Image = x.Image,
            ImageId = x.ImageID,
            Command = x.Command,
            Created = x.Created,
            Ports = Convert(x.Ports),
            SizeRw = x.SizeRw,
            SizeRootFs = x.SizeRootFs,
            Labels = x.Labels,
            State = x.State,
            Status = x.Status,
        });
    }

    private static List<PortDto> Convert(IList<Port> ports)
    {
        return ports.Select(p => new PortDto()
        {
            IP = p.IP,
            PrivatePort = p.PrivatePort,
            PublicPort = p.PublicPort,
            Type = p.Type,
        }).ToList();
    }

    private static IEnumerable<ImageDto> Convert(IList<ImagesListResponse> images)
    {
        return images.Select(x => new ImageDto()
        {
            ContainerUseId = x.Containers,
            Created = x.Created,
            Id = x.ID,
            Labels = x.Labels,
            ParentId = x.ParentID,
            RepoDigests = x.RepoDigests,
            RepoTags = x.RepoTags,
            SharedSize = x.SharedSize,
            Size = x.Size,
            VirtualSize = x.VirtualSize
        });
    }

    private static IEnumerable<VolumeDto> Convert(VolumesListResponse volumes)
    {
        return volumes.Volumes.Select(x => new VolumeDto()
        {
            CreatedAt = x.CreatedAt,
            Driver = x.Driver,
            Labels = x.Labels,
            Mountpoint = x.Mountpoint,
            Name = x.Name,
            Options = x.Options,
            RefCount = x.UsageData?.RefCount ?? 0,
            Scope = x.Scope,
            Size = x.UsageData?.Size ?? 0,
            Status = x.Status
        });
    }
}
