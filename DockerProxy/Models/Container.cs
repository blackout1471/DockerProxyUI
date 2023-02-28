namespace DockerProxy.Models;

public class Container
{
    public string Id { get; init; }

    public string Name { get; init; }

    public string ImageName { get; init; }

    public string ImageId { get; init; }

    public DateTime Created { get; init; }

    public IList<byte> Ports { get; init; }

    public string State { get; init; }

    public string Status { get; init; }

    public Image? Image { get; set; }
}
