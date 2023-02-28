using DockerProxy.Managers;
using DockerProxy.Models;
using System.ComponentModel;
using Container = DockerProxy.Models.Container;

namespace DockerProxy.Services;

public class ContainerService
{
    public delegate void FetchedContainersEventHandler(IEnumerable<Container> containers);
    public delegate void FetchedImagesEventHandler(IEnumerable<Image> images);

    public int FetchInSeconds { get; set; } = 5;

    public Uri ContainerConnection { get; set; } = new Uri("npipe://./pipe/docker_engine");

    public event FetchedContainersEventHandler? OnContainersFetched;
    public event FetchedImagesEventHandler? OnImagesFetched;

    private readonly IContainerManager _ContainerManager;
    private readonly IImageManager _ImageManager;

    private readonly BackgroundWorker _Worker;

    public ContainerService(IContainerManager containerManager, IImageManager imageManager)
    {
        _ContainerManager = containerManager;
        _ImageManager = imageManager;
        _Worker = new BackgroundWorker();

        _Worker.DoWork += FetchContainerData;
    }

    public void Start()
    {
        if (!_Worker.IsBusy)
            _Worker.RunWorkerAsync();
    }

    public void StopAsync()
    {
        if (_Worker.IsBusy)
            _Worker.CancelAsync();
    }

    private void FetchContainerData(object? sender, DoWorkEventArgs e)
    {
        while (!_Worker.CancellationPending)
        {
            Task.Run(async () =>
            {
                OnImagesFetched?.Invoke( await _ImageManager.GetImagesAsync() );
                OnContainersFetched?.Invoke( await _ContainerManager.GetContainersAsync() );
            });

            Thread.Sleep(FetchInSeconds * 1000);
        }
    }


}
