using DockerProxy.Managers;
using DockerProxy.Providers;
using DockerProxy.Services;
using DockerProxyUI.Core;
using System;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class MainViewModel : ObservableObject
{
    private readonly ContainerBackgroundService _service;

    public MainViewModel()
    {
        var provider = new DockerContainerProvider(new Uri("npipe://./pipe/docker_engine"));

        var containerManager = new ContainerManager(provider);
        var imageManager = new ImageManager(provider);
        var volumeManager = new VolumeManager(provider);

        _service = new ContainerBackgroundService(containerManager, imageManager, volumeManager);
        SetupServiceDataEvents();
        _service.Start();
    }

    private void SetupServiceDataEvents()
    {
        _service.OnContainersFetched += (containers) =>
        {
            PageNavigator.Instance.ContainersViewModel.Containers = new ObservableCollection<DockerProxy.Models.Container>(containers);
        };

        _service.OnImagesFetched += (images) =>
        {
            PageNavigator.Instance.ImagesViewModel.Images = new ObservableCollection<DockerProxy.Models.Image>(images);
        };

        _service.OnVolumesFetched += (volumes) =>
        {
            PageNavigator.Instance.VolumesViewModel.Volumes = new ObservableCollection<DockerProxy.Models.Volume>(volumes);
        };
    }
}
