using DockerProxy.Models;
using DockerProxy.Providers;

namespace DockerProxy.Managers;

public class ImageManager : IImageManager
{
    private readonly IContainerProvider _provider;

    public ImageManager(IContainerProvider containerProider)
    {
        _provider = containerProider;
    }

    public async Task<IEnumerable<Image>> GetImagesAsync()
    {
        var images = await _provider.GetAllImagesAsync();

        return images.Select(x => new Image()
        {
            UsedByContainers = x.ContainerUseId,
            VirtualSize = x.VirtualSize,
            Created = x.Created,
            Id = x.Id,
            Labels = x.Labels,
            ParentId = x.ParentId,
            RepoDigests = x.RepoDigests,
            Tag = x.RepoTags.First(),
            SharedSize = x.SharedSize,
            Size = x.Size
        });
    }
}
