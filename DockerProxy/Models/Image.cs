namespace DockerProxy.Models;

public class Image
{
    public long Containers { get; set; }

    public DateTime Created { get; set; }
    public string Id { get; set; }

    public IDictionary<string, string> Labels { get; set; }

    public string ParentId { get; set; }

    public IList<string> RepoDigests { get; set; }

    public string Tag { get; set; }

    public long SharedSize { get; set; }

    public long Size { get; set; }

    public long VirtualSize { get; set; }
}
