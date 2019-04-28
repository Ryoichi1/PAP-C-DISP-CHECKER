using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using static PAP_C_DISP_TESTER.UiControl;

namespace PAP_C_DISP_TESTER
{
    /// <summary>
    /// Theme.xaml の相互作用ロジック
    /// </summary>
    public partial class Theme
    {
        Storyboard storyboard = new Storyboard();
        DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();

        public Theme()
        {
            InitializeComponent();
            this.DataContext = State.VmMainWindow;
            SliderOpacity.Value = State.setting.OpacityTheme;

        }

        private void Pic1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            State.VmMainWindow.Theme = "Resources/Pic/nagasaki.jpg";
            Show();
        }

        private void Pic2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            State.VmMainWindow.Theme = "Resources/Pic/moon.jpg";
            Show();
        }

        private void Pic3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            State.VmMainWindow.Theme = "Resources/Pic/sumetal.jpg";
            Show();
        }

        private void Pic4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/Pic/sumetal3.jpg";
            Show();
        }

        private void Pic5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/Pic/sumetal2.png";
            Show();
        }


        private void Pic6_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/Pic/sumetal4.jpg";
            Show();
        }

        private void SliderOpacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            State.setting.OpacityTheme = State.VmMainWindow.ThemeOpacity;
        }

    }
}
