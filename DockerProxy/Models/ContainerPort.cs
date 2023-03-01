namespace DockerProxy.Models;

public class ContainerPort
{
    public string IP { get; init; }

    public ushort PrivatePort { get; init; }

    public ushort PublicPort { get; init; }

    public string Type { get; init; }
}
