using DockerProxy.Models;
using DockerProxy.Services;
using DockerProxyUI.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class VolumesViewModel: IViewModel
{
    public ObservableCollection<Volume> Volumes { get; set; }

    private readonly IContainerService _containerService;
    private readonly ContainerBackgroundService _containerBackgroundService;

    public VolumesViewModel(IContainerService containerService, ContainerBackgroundService containerBackgroundService)
    {
        Volumes = new ObservableCollection<Volume>();

        _containerService = containerService ?? throw new ArgumentNullException();
        _containerBackgroundService = containerBackgroundService ?? throw new ArgumentNullException();

        _containerBackgroundService.OnVolumesFetched += OnVolumesFetched;
    }

    private void OnVolumesFetched(IEnumerable<Volume> volumes)
    {
        App.Current.Dispatcher.Invoke(() =>
        {
            Volumes.Clear();
            foreach (var volume in volumes)
            {
                Volumes.Add(volume);
            }
        });
    }
}
