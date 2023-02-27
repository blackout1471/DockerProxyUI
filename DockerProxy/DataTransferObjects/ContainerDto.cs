namespace DockerProxy.DataTransferObjects;

public class ContainerDto
{
    public string Id { get; set; }

    public IList<string> Names { get; set; }

    public string Image { get; set; }

    public string ImageId { get; set; }

    public string Command { get; set; }

    public DateTime Created { get; set; }

    public IList<byte> Ports { get; set; }

    public long SizeRw { get; set; }

    public long SizeRootFs { get; set; }

    public IDictionary<string, string> Labels { get; set; }

    public string State { get; set; }

    public string Status { get; set; }
}
