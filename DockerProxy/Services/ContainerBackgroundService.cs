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

    public event FetchedContainersEventHandler? OnContainersFetched;
    public event FetchedImagesEventHandler? OnImagesFetched;
    public event FetchedVolumesEventHandler? OnVolumesFetched;

    private readonly IContainerService _containerService;
    private readonly BackgroundWorker _Worker;

    public ContainerBackgroundService(IContainerService containerService)
    {
        _containerService = containerService;
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
            var t = Task.Run(async () =>
            {
                await _containerService.FetchDataAsync();

                OnImagesFetched?.Invoke(_containerService.Images);
                OnContainersFetched?.Invoke(_containerService.Containers);
                OnVolumesFetched?.Invoke(_containerService.Volumes);
            });

            Thread.Sleep(FetchInSeconds * 1000);
        }
    }


}
