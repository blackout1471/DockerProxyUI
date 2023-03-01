using DockerProxy.Models;
using DockerProxy.Providers;

namespace DockerProxy.Managers;

public class VolumeManager : IVolumeManager
{

    private readonly IContainerProvider _containerProvider;

    public VolumeManager(IContainerProvider containerProvider)
    {
        _containerProvider = containerProvider;
    }

    public async Task<IEnumerable<Volume>> GetVolumesAsync()
    {
        var volumes = await _containerProvider.GetAllVolumesAsync();

        return volumes.Select(x => new Volume()
        {
            CreatedAt= x.CreatedAt,
            Driver = x.Driver,
            Labels= x.Labels,
            Mountpoint= x.Mountpoint,
            Name= x.Name,
            Options= x.Options,
            RefCount= x.RefCount,
            Scope= x.Scope,
            Size= x.Size,
            Status= x.Status,
        });
    }
}
