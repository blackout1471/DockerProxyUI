using DockerProxy.Managers;
using DockerProxy.Models;
using System.ComponentModel;
using Container = DockerProxy.Models.Container;

namespace DockerProxy.Services;

public class ContainerBackgroundService
{
    public delegate void FetchedContainersEventHandler(IEnumerable<Container> containers);
    public delegate void FetchedImagesEventHandler(IEnumerable<Image> images);
    public delegate void FetchedVolumesEventHandler(IEnumerable<Volume> volumes);

    public int FetchInSeconds { get; set; } = 5;

    public Uri ContainerConnection { get; set; } = new Uri("npipe://./pipe/docker_engine");

    public event FetchedContainersEventHandler? OnContainersFetched;
    public event FetchedImagesEventHandler? OnImagesFetched;
    public event FetchedVolumesEventHandler? OnVolumesFetched;

    private readonly ContainerService _containerService;

    private readonly BackgroundWorker _Worker;

    public ContainerBackgroundService(IContainerManager containerManager, IImageManager imageManager, IVolumeManager volumeManager)
    {
        _containerService = new ContainerService(containerManager, imageManager, volumeManager);
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
                await _containerService.GetAllContainerData();

                OnImagesFetched?.Invoke( _containerService.Images );
                OnContainersFetched?.Invoke( _containerService.Containers );
                OnVolumesFetched?.Invoke( _containerService.Volumes );
            }).Wait();

            Thread.Sleep(FetchInSeconds * 1000);
        }
    }


}
