using MoFish.Common.Utils;
using System.Windows;

namespace MoFish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGithub(object sender, RoutedEventArgs e)
        {
            Link.OpenInBrowser("https://github.com/HenJigg/WPF-Xamarin-Blazor-Examples");
        }

        private void btnBilibili(object sender, RoutedEventArgs e)
        {
            Link.OpenInBrowser("https://space.bilibili.com/32497462");
        }

        private void btnQQ(object sender, RoutedEventArgs e)
        {
            Link.OpenInBrowser(" http://qm.qq.com/cgi-bin/qm/qr?k=KpcFszjNfY2g-o0q1eEMIoYWbzjSMO2-&authKey=lg1kMENlcHkLO2gejRLvXmGq9Xy6GGb0X1h%2B9QDMhbNxvLLLugAsDQUIuzPJZhDy&group_code=874752819");
        }

    }
}
