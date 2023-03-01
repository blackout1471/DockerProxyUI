namespace DockerProxy.Models;

public class Image
{
    public long UsedByContainers { get; init; }

    public DateTime Created { get; init; }
    public string Id { get; init; }

    public IDictionary<string, string> Labels { get; init; }

    public string ParentId { get; init; }

    public IList<string> RepoDigests { get; init; }

    public string Tag { get; init; }

    public long SharedSize { get; init; }

    public long Size { get; init; }

    public long VirtualSize { get; init; }

    public IList<Container> Containers { get; init; } = new List<Container>();
}
