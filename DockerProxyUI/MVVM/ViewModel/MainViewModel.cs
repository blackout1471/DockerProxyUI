using DockerProxy.Managers;
using DockerProxy.Providers;
using DockerProxy.Services;
using DockerProxyUI.Core;
using System;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class MainViewModel : ObservableObject
{
    public RelayCommand DashBoardViewCommand { get; set; }
    public RelayCommand ContainersViewCommand { get; set; }
    public RelayCommand ImagesViewCommand { get; set; }
    public RelayCommand VolumesViewCommand { get; set; }
    public RelayCommand SettingsViewCommand { get; set; }

    public DashBoardViewModel DashBoardViewModel { get; set; }
    public ContainersViewModel ContainersViewModel { get; set; }
    public ImagesViewModel ImagesViewModel { get; set; }
    public VolumesViewModel VolumesViewModel { get; set; }
    public SettingsViewModel SettingsViewModel { get; set; }

    private object currentView;
	public object CurrentView
	{
		get { return currentView; }
		set 
		{ 
			currentView = value;
			OnPropertyChanged();
		}
	}

    private readonly ContainerBackgroundService _service;

    public MainViewModel()
    {
        DashBoardViewModel = new DashBoardViewModel();
        ContainersViewModel = new ContainersViewModel();
        ImagesViewModel = new ImagesViewModel();
        VolumesViewModel = new VolumesViewModel();
        SettingsViewModel = new SettingsViewModel();

        var provider = new DockerContainerProvider(new Uri("npipe://./pipe/docker_engine"));
        var containerManager = new ContainerManager(provider);
        var imageManager = new ImageManager(provider);


        _service = new ContainerBackgroundService(containerManager, imageManager);
        _service.OnContainersFetched += (containers) => 
        {
            ContainersViewModel.Containers = new ObservableCollection<DockerProxy.Models.Container>(containers);
        };

        _service.OnImagesFetched += (images) =>
        {
            ImagesViewModel.Images = new ObservableCollection<DockerProxy.Models.Image>(images);
        };
        _service.Start();


		CurrentView = DashBoardViewModel;

		DashBoardViewCommand = new RelayCommand(o =>
		{
			CurrentView = DashBoardViewModel;
		});

        ContainersViewCommand = new RelayCommand(o =>
        {
            CurrentView = ContainersViewModel;
        });

        ImagesViewCommand = new RelayCommand(o =>
        {
            CurrentView = ImagesViewModel;
        });

        VolumesViewCommand = new RelayCommand(o =>
        {
            CurrentView = VolumesViewModel;
        });

        SettingsViewCommand = new RelayCommand(o =>
        {
            CurrentView = SettingsViewModel;
        });
    }

}
