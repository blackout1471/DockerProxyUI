namespace DockerProxy.Models;

public class Volume
{
    public string CreatedAt { get; init; }

    public string Driver { get; init; }

    public IDictionary<string, string> Labels { get; init; }

    public string Mountpoint { get; init; }

    public string Name { get; init; }

    public IDictionary<string, string> Options { get; init; }

    public string Scope { get; init; }

    public IDictionary<string, object> Status { get; init; }

    public long RefCount { get; init; }

    public long Size { get; init; }

    public Container? Container { get; set; }
}
