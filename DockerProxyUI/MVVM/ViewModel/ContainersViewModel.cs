using DockerProxy.Models;
using DockerProxy.Services;
using DockerProxyUI.Core;
using DockerProxyUI.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class ContainersViewModel : IViewModel
{
    public ObservableCollection<Container> Containers { get; private set; }

    public RelayCommand StartContainerCommand { get; private set; }

    public RelayCommand StopContainerCommand { get; private set; }

    public RelayCommand CreateContainerViewCommand { get; set; } = new RelayCommand(o => PageNavigator.Instance.Set<CreateContainerViewModel>());

    private readonly IContainerService _containerService;
    private readonly ContainerBackgroundService _backgroundService;

    public ContainersViewModel(IContainerService containerService , ContainerBackgroundService backgroundService)
    {
        Containers = new ObservableCollection<Container>();

        _containerService = containerService ?? throw new ArgumentNullException();
        _backgroundService = backgroundService ?? throw new ArgumentNullException();
        backgroundService.OnContainersFetched += OnContainersFetched;

        SetupCommands();
    }

    private void OnContainersFetched(IEnumerable<Container> containers)
    {
        App.Current.Dispatcher.Invoke(() =>
        {
            Containers.Clear();
            foreach (var container in containers)
            {
                Containers.Add(container);
            }
        });
    }

    private void SetupCommands()
    {
        StartContainerCommand = new RelayCommand(async (o) =>
        {
            var container = o as Container;
            await _containerService.StartContainerAsync(container.Id);
        }, CanExecuteContainerAction);

        StopContainerCommand = new RelayCommand(async (o) =>
        {
            var container = o as Container;
            await _containerService.StopContainerAsync(container.Id);
        }, CanExecuteContainerAction);
    }

    private bool CanExecuteContainerAction(object o)
    {
        var container = o as Container;

        return container?.State != "Updating";
    }
}
