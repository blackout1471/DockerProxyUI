using DockerProxy.Models;
using DockerProxy.Services;
using DockerProxyUI.MVVM.Core;
using System;
using System.Collections.ObjectModel;

namespace DockerProxyUI.MVVM.ViewModel;

internal class ImagesViewModel : IViewModel
{
    public ObservableCollection<Image> Images { get; private set; }

    private readonly IContainerService _containerService;
    private readonly ContainerBackgroundService _containerBackgroundService;

    public ImagesViewModel(IContainerService containerService, ContainerBackgroundService containerbackgroundService)
    {
        Images = new ObservableCollection<Image>();

        _containerService = containerService ?? throw new ArgumentNullException();
        _containerBackgroundService = containerbackgroundService ?? throw new ArgumentNullException();

        _containerBackgroundService.OnImagesFetched += OnImagesFetched;
    }

    private void OnImagesFetched(System.Collections.Generic.IEnumerable<Image> images)
    {
        App.Current.Dispatcher.Invoke(() =>
        {
            Images.Clear();
            foreach (var image in images)
            {
                Images.Add(image);
            };
        });
    }
}
