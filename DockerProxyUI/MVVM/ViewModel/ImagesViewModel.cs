using DockerProxy.Models;
using DockerProxyUI.MVVM.Core;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class ImagesViewModel : IViewModel
{
    public ObservableCollection<Image> Images { get; set; }

    public ImagesViewModel()
    {
        Images = new ObservableCollection<Image>();
    }


}
