using System;
using System.Windows;
using System.Windows.Navigation;

namespace PAP_C_DISP_TESTER
{
    /// <summary>
    /// Config.xaml の相互作用ロジック
    /// </summary>
    public partial class Conf
    {
        private NavigationService naviMainte;
        private NavigationService naviCamera1;
        private NavigationService naviCamera2;
        private NavigationService naviOperator;
        private NavigationService naviTheme;
        Uri uriMaintePage = new Uri("Page/Config/Mainte.xaml", UriKind.Relative);
        Uri uriCamera1Page = new Uri("Page/Config/Camera1Conf.xaml", UriKind.Relative);
        Uri uriCamera2Page = new Uri("Page/Config/Camera2Conf.xaml", UriKind.Relative);
        Uri uriOperatorPage = new Uri("Page/Config/EditOpeList.xaml", UriKind.Relative);
        Uri uriThemePage = new Uri("Page/Config/Theme.xaml", UriKind.Relative);

        public Conf()
        {
            InitializeComponent();

            naviMainte = FrameMente.NavigationService;
            naviCamera1 = FrameCamera1.NavigationService;
            naviCamera2 = FrameCamera2.NavigationService;
            naviOperator = FrameOperator.NavigationService;
            naviTheme = FrameTheme.NavigationService;

            FrameMente.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameCamera1.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameCamera2.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameOperator.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameTheme.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            TabMenu.SelectedIndex = 0;

            // オブジェクト作成に必要なコードをこの下に挿入します。
        }

        private void TabMente_Loaded(object sender, RoutedEventArgs e)
        {
            naviMainte.Navigate(uriMaintePage);
        }


        private void TabOperator_Loaded(object sender, RoutedEventArgs e)
        {
            naviOperator.Navigate(uriOperatorPage);
        }

        private void TabTheme_Loaded(object sender, RoutedEventArgs e)
        {
            naviTheme.Navigate(uriThemePage);
        }

        private void TabCamera1_Loaded(object sender, RoutedEventArgs e)
        {
            naviCamera1.Navigate(uriCamera1Page);
        }

        private void TabCamera2_Loaded(object sender, RoutedEventArgs e)
        {
            naviCamera2.Navigate(uriCamera2Page);
        }
    }
}
