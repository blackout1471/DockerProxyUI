using DockerProxy.Models;
using DockerProxyUI.MVVM.Core;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class VolumesViewModel: IViewModel
{
    public ObservableCollection<Volume> Volumes { get; set; }

    public VolumesViewModel()
    {
        Volumes = new ObservableCollection<Volume>();
    }
}
