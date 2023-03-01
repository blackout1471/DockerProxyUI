using System.Windows.Controls;

namespace DockerProxyUI.MVVM.View
{
    /// <summary>
    /// Interaction logic for ContainerView.xaml
    /// </summary>
    public partial class ContainerView : UserControl
    {
        public ContainerView()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
