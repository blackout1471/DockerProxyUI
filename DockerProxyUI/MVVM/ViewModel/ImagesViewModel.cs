using DockerProxy.Managers;
using DockerProxy.Models;
using DockerProxy.Providers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DockerProxyUI.MVVM.ViewModel;

public class ImagesViewModel
{
    private readonly IImageManager _ImageManager;

    public ObservableCollection<Image> Images { get; set; }

    public ImagesViewModel()
    {
        var uri = new Uri("npipe://./pipe/docker_engine");
        uri = new UriBuilder("tcp", "localhost", 2375).Uri;
        _ImageManager = new ImageManager(new DockerContainerProvider(uri));

        Task.Run(async () =>
        {
            var images = await _ImageManager.GetImagesAsync();
            Images = new ObservableCollection<Image>(images);
        });
    }


}
