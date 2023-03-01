namespace DockerProxy.DataTransferObjects;

public class ImageDto
{
    public string Id { get; init; }

    public long ContainerUseId { get; init; }

    public DateTime Created { get; init; }
    
    public IDictionary<string, string> Labels { get; init; }

    public string ParentId { get; init; }

    public IList<string> RepoDigests { get; init; }

    public IList<string> RepoTags { get; init; }

    public long SharedSize { get; init; }

    public long Size { get; init; }

    public long VirtualSize { get; init; }
}
