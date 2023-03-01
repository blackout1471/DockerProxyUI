using DockerProxyUI.MVVM.ViewModel;

namespace DockerProxyUI.Core;

internal class PageNavigator : ObservableObject
{
    private static PageNavigator instance = null;
    public static PageNavigator Instance 
    { 
        get 
        { 
            if (instance == null)
                instance = new PageNavigator();

            return instance;
        } 
    }

    public RelayCommand DashBoardViewCommand { get; private set; }
    public RelayCommand ContainersViewCommand { get; private set; }
    public RelayCommand ImagesViewCommand { get; private set; }
    public RelayCommand VolumesViewCommand { get; private set; }
    public RelayCommand SettingsViewCommand { get; private set; }
    public RelayCommand CreateContainerViewCommand { get; private set; }

    public DashBoardViewModel DashBoardViewModel { get; private init; }
    public ContainersViewModel ContainersViewModel { get; private init; }
    public ImagesViewModel ImagesViewModel { get; private init; }
    public VolumesViewModel VolumesViewModel { get; private init; }
    public SettingsViewModel SettingsViewModel { get; private init; }
    public CreateContainerViewModel CreateContainerViewModel { get; private init; }

    private object currentView;
	public object CurrentView
	{
		get { return currentView; }
		private set 
		{ 
			currentView = value;
			OnPropertyChanged();
		}
	}

	public PageNavigator()
	{
        DashBoardViewModel = new DashBoardViewModel();
        ContainersViewModel = new ContainersViewModel();
        ImagesViewModel = new ImagesViewModel();
        VolumesViewModel = new VolumesViewModel();
        SettingsViewModel = new SettingsViewModel();
        CreateContainerViewModel = new CreateContainerViewModel();

        SetupViewCommands();
        CurrentView = DashBoardViewModel;
    }

    private void SetupViewCommands()
    {
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

        CreateContainerViewCommand = new RelayCommand(o =>
        {
            CurrentView = CreateContainerViewModel;
        });
    }

}
