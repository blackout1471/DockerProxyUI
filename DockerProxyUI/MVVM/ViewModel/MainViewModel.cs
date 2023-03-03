using DockerProxy.Managers;
using DockerProxy.Providers;
using DockerProxy.Services;
using DockerProxyUI.Core;
using System;

namespace DockerProxyUI.MVVM.ViewModel;

internal class MainViewModel : ObservableObject
{
    private readonly ContainerBackgroundService _service;

    public RelayCommand DashboardViewCommand { get; private set; } = new RelayCommand((o) => PageNavigator.Instance.Set<DashBoardViewModel>());
    public RelayCommand ContainersViewCommand { get; private set; } = new RelayCommand((o) => PageNavigator.Instance.Set<ContainersViewModel>());
    public RelayCommand ImagesViewCommand { get; private set; } = new RelayCommand((o) => PageNavigator.Instance.Set<ImagesViewModel>());
    public RelayCommand VolumesViewCommand { get; private set; } = new RelayCommand((o) => PageNavigator.Instance.Set<VolumesViewModel>());
    public RelayCommand SettingsViewCommand { get; private set; } = new RelayCommand((o) => PageNavigator.Instance.Set<SettingsViewModel>());

    public MainViewModel()
    {
        var uri = new Uri("npipe://./pipe/docker_engine");
        uri = new UriBuilder("tcp", "localhost", 2375).Uri;
        var provider = new DockerContainerProvider(uri);

        var containerManager = new ContainerManager(provider);
        var imageManager = new ImageManager(provider);
        var volumeManager = new VolumeManager(provider);

        var containerService = new ContainerService(containerManager, imageManager, volumeManager);
        _service = new ContainerBackgroundService(containerService);

        PageNavigator.Instance.Add(new DashBoardViewModel());
        PageNavigator.Instance.Add(new ContainersViewModel(containerService, _service));
        PageNavigator.Instance.Add(new ImagesViewModel(containerService, _service));
        PageNavigator.Instance.Add(new VolumesViewModel(containerService, _service));
        PageNavigator.Instance.Add(new SettingsViewModel());
        PageNavigator.Instance.Add(new CreateContainerViewModel(_service));
        PageNavigator.Instance.Set<DashBoardViewModel>();
        
        _service.Start();
    }
}
