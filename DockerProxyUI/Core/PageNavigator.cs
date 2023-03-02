using DockerProxyUI.MVVM.Core;
using DockerProxyUI.MVVM.ViewModel;
using System.Collections.Generic;
using System.Linq;

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

    private readonly IList<IViewModel> _viewModels;

	public PageNavigator()
	{
        _viewModels = new List<IViewModel>();
    }

    public void Add(IViewModel viewModel)
    {
        _viewModels.Add(viewModel);
    }

    public void Set<T>() where T : class, IViewModel
    {
        var viewModel = Get<T>();
        CurrentView = viewModel;
    }

    private T Get<T>() where T : class, IViewModel
    {
        var viewModel = _viewModels.Where(x => x.GetType() == typeof(T))
            .FirstOrDefault();

        if (viewModel is null)
            throw new KeyNotFoundException();

        return (T)viewModel;
    }

}
