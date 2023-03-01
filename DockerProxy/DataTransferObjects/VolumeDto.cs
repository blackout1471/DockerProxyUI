namespace DockerProxy.DataTransferObjects;

public class VolumeDto
{
    public string CreatedAt { get; set; }

    public string Driver { get; set; }

    public IDictionary<string, string> Labels { get; set; }

    public string Mountpoint { get; set; }

    public string Name { get; set; }

    public IDictionary<string, string> Options { get; set; }

    public string Scope { get; set; }

    public IDictionary<string, object> Status { get; set; }

    public long RefCount { get; set; }

    public long Size { get; set; }
}
