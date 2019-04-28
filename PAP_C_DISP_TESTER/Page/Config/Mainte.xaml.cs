using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System;
using static System.Threading.Thread;
using static PAP_C_DISP_TESTER.General;
using static PAP_C_DISP_TESTER.GeneralFuncForTest;
using static PAP_C_DISP_TESTER.Constants;
using PAP_C_DISP_TESTER.TestItems;

namespace PAP_C_DISP_TESTER
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class Mainte
    {
        private SolidColorBrush OnBrush = new SolidColorBrush();
        private SolidColorBrush OffBrush = new SolidColorBrush();
        private const double ButtonOpacity = 0.4;

        public Mainte()
        {
            InitializeComponent();
            canvasBz.DataContext = State.VmTestResults;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OnBrush.Color = Colors.DodgerBlue;
            OffBrush.Color = Colors.Transparent;
            OnBrush.Opacity = ButtonOpacity;
            OffBrush.Opacity = ButtonOpacity;
        }


        private async void ButtonStamp_Click(object sender, RoutedEventArgs e) => await Task.Run(() => StampOn());

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            ResetIo();
        }


        private async void ButtonS1_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendData("SetKs1");
            PushSw1(true);
            await Task.Delay(400);
            LPC1768.SendData("R,P25");
            buttonS1.Background = LPC1768.RecieveData.Contains("L") ? OnBrush : OffBrush;
            PushSw1(false);
        }

        private async void ButtonS2_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendData("SetKs2");
            PushSw2(true);
            await Task.Delay(400);
            LPC1768.SendData("R,P25");
            buttonS2.Background = LPC1768.RecieveData.Contains("L") ? OnBrush : OffBrush;
            PushSw2(false);
        }


        private async void ButtonS3_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendData("SetKs3");
            PushSw3(true);
            await Task.Delay(400);
            LPC1768.SendData("R,P25");
            buttonS3.Background = LPC1768.RecieveData.Contains("L") ? OnBrush : OffBrush;
            PushSw3(false);
        }

        private async void ButtonS4_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendData("SetKs4");
            PushSw4(true);
            await Task.Delay(400);
            LPC1768.SendData("R,P25");
            buttonS4.Background = LPC1768.RecieveData.Contains("L") ? OnBrush : OffBrush;
            PushSw4(false);
        }

        private async void ButtonS5_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendData("SetKs5");
            PushSw5(true);
            await Task.Delay(400);
            LPC1768.SendData("R,P25");
            buttonS5.Background = LPC1768.RecieveData.Contains("L") ? OnBrush : OffBrush;
            PushSw5(false);
        }

        private async void ButtonS6_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendData("SetKs6");
            PushSw6(true);
            await Task.Delay(400);
            LPC1768.SendData("R,P25");
            buttonS6.Background = LPC1768.RecieveData.Contains("L") ? OnBrush : OffBrush;
            PushSw6(false);
        }

        private async void ButtonS7_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendData("SetKs7");
            PushSw7(true);
            await Task.Delay(400);
            LPC1768.SendData("R,P25");
            buttonS7.Background = LPC1768.RecieveData.Contains("L") ? OnBrush : OffBrush;
            PushSw7(false);
        }

        private void ButtonBzOn_Click(object sender, RoutedEventArgs e) => SetBz(true);

        private void ButtonBzOff_Click(object sender, RoutedEventArgs e) => SetBz(false);
    }
}
