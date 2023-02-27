namespace DockerProxy.Models;

public class Container
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Image { get; set; }

    public DateTime Created { get; set; }

    public IList<byte> Ports { get; set; }

    public string State { get; set; }

    public string Status { get; set; }
}
