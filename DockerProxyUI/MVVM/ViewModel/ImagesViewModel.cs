using DockerProxy.Managers;
using DockerProxy.Models;
using DockerProxy.Providers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DockerProxyUI.MVVM.ViewModel;

internal class ImagesViewModel
{
    public ObservableCollection<Image> Images { get; set; }

    public ImagesViewModel()
    {
        Images = new ObservableCollection<Image>();
    }


}
