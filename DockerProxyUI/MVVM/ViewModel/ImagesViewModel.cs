using DockerProxy.Models;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class ImagesViewModel
{
    public ObservableCollection<Image> Images { get; set; }

    public ImagesViewModel()
    {
        Images = new ObservableCollection<Image>();
    }


}
