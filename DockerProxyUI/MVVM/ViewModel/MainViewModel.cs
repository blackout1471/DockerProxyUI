using DockerProxyUI.Core;

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

    public MainViewModel()
    {
        DashBoardViewModel = new DashBoardViewModel();
        ContainersViewModel = new ContainersViewModel();
        ImagesViewModel = new ImagesViewModel();
        VolumesViewModel = new VolumesViewModel();
        SettingsViewModel = new SettingsViewModel();


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
