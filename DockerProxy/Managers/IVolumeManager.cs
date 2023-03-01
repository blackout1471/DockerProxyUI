using DockerProxy.Models;

namespace DockerProxy.Managers;

public interface IVolumeManager
{
    public Task<IEnumerable<Volume>> GetVolumesAsync();
}
