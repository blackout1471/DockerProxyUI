using DockerProxy.Models;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class VolumesViewModel
{
    public ObservableCollection<Volume> Volumes { get; set; }

	public VolumesViewModel()
	{
		Volumes = new ObservableCollection<Volume>();
	}
}
