using DockerProxy.Managers;
using DockerProxy.Models;
using DockerProxy.Providers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DockerProxyUI.MVVM.ViewModel;

internal class ContainersViewModel
{
    public ObservableCollection<Container> Containers { get; set; }

    public ContainersViewModel()
    {
        Containers = new ObservableCollection<Container>();
    }
}
