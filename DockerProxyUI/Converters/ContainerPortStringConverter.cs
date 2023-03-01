using DockerProxy.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DockerProxyUI.Converters;

internal class ContainerPortStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var port = (ContainerPort)value;

        return $"{port.PublicPort}:{port.PrivatePort}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
