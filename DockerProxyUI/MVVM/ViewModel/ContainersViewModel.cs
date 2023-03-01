using DockerProxy.Models;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class ContainersViewModel
{
    public ObservableCollection<Container> Containers { get; set; }

    public ContainersViewModel()
    {
        Containers = new ObservableCollection<Container>();
    }
}
