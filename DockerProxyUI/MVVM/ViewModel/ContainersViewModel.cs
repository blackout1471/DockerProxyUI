using DockerProxy.Managers;
using DockerProxy.Models;
using DockerProxy.Providers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DockerProxyUI.MVVM.ViewModel;

internal class ContainersViewModel
{
    private readonly IContainerManager _containerManager;

    public ObservableCollection<Container> Containers { get; set; }

    public ContainersViewModel()
    {
        var uri = new Uri("npipe://./pipe/docker_engine");
        _containerManager = new ContainerManager(new DockerContainerProvider(uri));

        Task.Run(async () =>
        {
            var containers = await _containerManager.GetContainersAsync();
            Containers = new ObservableCollection<Container>(containers);
        });
    }
}
