using DockerProxy.Models;
using DockerProxy.Services;
using DockerProxyUI.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DockerProxyUI.MVVM.ViewModel;

internal class CreateContainerViewModel : IViewModel
{
    public ObservableCollection<Image> Images { get; private set; }
    public Image SelectedImage { get; set; }

    private readonly ContainerBackgroundService _backgroundService;
    private readonly IContainerService _containerService;

    public CreateContainerViewModel(ContainerBackgroundService backgrounContainerService, IContainerService containerService)
    {
        Images = new ObservableCollection<Image>();

        _backgroundService = backgrounContainerService ?? throw new ArgumentNullException();
        _backgroundService.OnImagesFetched += _backgroundService_OnImagesFetched;

        _containerService = containerService ?? throw new ArgumentNullException();

    }

    private void _backgroundService_OnImagesFetched(IEnumerable<Image> images)
    {
        App.Current.Dispatcher.Invoke(() =>
        {
            if (Images.SequenceEqual(images, new ImageComparer()))
                return;

            Images.Clear();
            foreach (var image in images)
            {
                Images.Add(image);
            }
        });
    }

    private class ImageComparer : IEqualityComparer<Image>
    {
        public bool Equals(Image? x, Image? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Image obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
