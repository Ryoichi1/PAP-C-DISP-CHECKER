using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static PAP_C_DISP_TESTER.UiControl;
using static PAP_C_DISP_TESTER.Constants;
using static PAP_C_DISP_TESTER.GeneralFuncForTest;
using System.Collections.Generic;

namespace PAP_C_DISP_TESTER
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class Camera2Conf
    {
        bool IsCalibOk = false;

        public Camera2Conf()
        {
            InitializeComponent();
            this.DataContext = General.cam2;
            canvasLdPoint.DataContext = State.VmCam2Point;
            blobPoint.DataContext = State.VmCam2Point;
            toggleSw.IsChecked = General.cam2.Opening;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            State.VmMainWindow.MainWinEnable = false;
            await Task.Delay(1200);
            State.VmMainWindow.MainWinEnable = true;
            State.SetCam2Point();
            General.cam2.Start();
            State.SetCam2Prop();
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;

        }

        private async void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            LedAllOn = false;
            IsLabeling = false;
            General.cam2.ResetFlag();
            await General.cam2.Stop();

            resetView();

            IsLabeling = false;

            buttonLabeling.IsEnabled = true;
            canvasLdPoint.IsEnabled = true;

            //TODO:
            //LEDを全消灯させる処理
            State.SetCam2Prop();
            State.SetCam2Point();
        }

        private void resetView()
        {
            buttonLedOnOff.Background = OffBrush;

            State.VmCam2Point.LD1a = "";
            State.VmCam2Point.LD1b = "";
            State.VmCam2Point.LD1c = "";
            State.VmCam2Point.LD1d = "";
            State.VmCam2Point.LD1e = "";
            State.VmCam2Point.LD1f = "";
            State.VmCam2Point.LD1g = "";
            State.VmCam2Point.LD1h = "";
            State.VmCam2Point.LD1i = "";
            State.VmCam2Point.LD1j = "";
            State.VmCam2Point.LD1k = "";
            State.VmCam2Point.LD1l = "";
            State.VmCam2Point.LD1m = "";
            State.VmCam2Point.LD1n = "";
            State.VmCam2Point.LD1dp = "";

            State.VmCam2Point.LD2a = "";
            State.VmCam2Point.LD2b = "";
            State.VmCam2Point.LD2c = "";
            State.VmCam2Point.LD2d = "";
            State.VmCam2Point.LD2e = "";
            State.VmCam2Point.LD2f = "";
            State.VmCam2Point.LD2g = "";
            State.VmCam2Point.LD2h = "";
            State.VmCam2Point.LD2i = "";
            State.VmCam2Point.LD2j = "";
            State.VmCam2Point.LD2k = "";
            State.VmCam2Point.LD2l = "";
            State.VmCam2Point.LD2m = "";
            State.VmCam2Point.LD2n = "";
            State.VmCam2Point.LD2dp = "";

            State.VmCam2Point.LD3a = "";
            State.VmCam2Point.LD3b = "";
            State.VmCam2Point.LD3c = "";
            State.VmCam2Point.LD3d = "";
            State.VmCam2Point.LD3e = "";
            State.VmCam2Point.LD3f = "";
            State.VmCam2Point.LD3g = "";
            State.VmCam2Point.LD3h = "";
            State.VmCam2Point.LD3i = "";
            State.VmCam2Point.LD3j = "";
            State.VmCam2Point.LD3k = "";
            State.VmCam2Point.LD3l = "";
            State.VmCam2Point.LD3m = "";
            State.VmCam2Point.LD3n = "";
            State.VmCam2Point.LD3dp = "";

            State.VmCam2Point.LD4a = "";
            State.VmCam2Point.LD4b = "";
            State.VmCam2Point.LD4c = "";
            State.VmCam2Point.LD4d = "";
            State.VmCam2Point.LD4e = "";
            State.VmCam2Point.LD4f = "";
            State.VmCam2Point.LD4g = "";
            State.VmCam2Point.LD4h = "";
            State.VmCam2Point.LD4i = "";
            State.VmCam2Point.LD4j = "";
            State.VmCam2Point.LD4k = "";
            State.VmCam2Point.LD4l = "";
            State.VmCam2Point.LD4m = "";
            State.VmCam2Point.LD4n = "";
            State.VmCam2Point.LD4dp = "";

            State.VmCam2Point.LD5a = "";
            State.VmCam2Point.LD5b = "";
            State.VmCam2Point.LD5c = "";
            State.VmCam2Point.LD5d = "";
            State.VmCam2Point.LD5e = "";
            State.VmCam2Point.LD5f = "";
            State.VmCam2Point.LD5g = "";
            State.VmCam2Point.LD5h = "";
            State.VmCam2Point.LD5i = "";
            State.VmCam2Point.LD5j = "";
            State.VmCam2Point.LD5k = "";
            State.VmCam2Point.LD5l = "";
            State.VmCam2Point.LD5m = "";
            State.VmCam2Point.LD5n = "";
            State.VmCam2Point.LD5dp = "";

            State.VmCam2Point.LD6a = "";
            State.VmCam2Point.LD6b = "";
            State.VmCam2Point.LD6c = "";
            State.VmCam2Point.LD6d = "";
            State.VmCam2Point.LD6e = "";
            State.VmCam2Point.LD6f = "";
            State.VmCam2Point.LD6g = "";
            State.VmCam2Point.LD6h = "";
            State.VmCam2Point.LD6i = "";
            State.VmCam2Point.LD6j = "";
            State.VmCam2Point.LD6k = "";
            State.VmCam2Point.LD6l = "";
            State.VmCam2Point.LD6m = "";
            State.VmCam2Point.LD6n = "";
            State.VmCam2Point.LD6dp = "";

            State.VmCam2Point.LD7a = "";
            State.VmCam2Point.LD7b = "";
            State.VmCam2Point.LD7c = "";
            State.VmCam2Point.LD7d = "";
            State.VmCam2Point.LD7e = "";
            State.VmCam2Point.LD7f = "";
            State.VmCam2Point.LD7g = "";
            State.VmCam2Point.LD7h = "";
            State.VmCam2Point.LD7i = "";
            State.VmCam2Point.LD7j = "";
            State.VmCam2Point.LD7k = "";
            State.VmCam2Point.LD7l = "";
            State.VmCam2Point.LD7m = "";
            State.VmCam2Point.LD7n = "";
            State.VmCam2Point.LD7dp = "";

            State.VmCam2Point.LD8a = "";
            State.VmCam2Point.LD8b = "";
            State.VmCam2Point.LD8c = "";
            State.VmCam2Point.LD8d = "";
            State.VmCam2Point.LD8e = "";
            State.VmCam2Point.LD8f = "";
            State.VmCam2Point.LD8g = "";
            State.VmCam2Point.LD8h = "";
            State.VmCam2Point.LD8i = "";
            State.VmCam2Point.LD8j = "";
            State.VmCam2Point.LD8k = "";
            State.VmCam2Point.LD8l = "";
            State.VmCam2Point.LD8m = "";
            State.VmCam2Point.LD8n = "";
            State.VmCam2Point.LD8dp = "";

            State.VmCam2Point.LD9a = "";
            State.VmCam2Point.LD9b = "";
            State.VmCam2Point.LD9c = "";
            State.VmCam2Point.LD9d = "";
            State.VmCam2Point.LD9e = "";
            State.VmCam2Point.LD9f = "";
            State.VmCam2Point.LD9g = "";
            State.VmCam2Point.LD9h = "";
            State.VmCam2Point.LD9i = "";
            State.VmCam2Point.LD9j = "";
            State.VmCam2Point.LD9k = "";
            State.VmCam2Point.LD9l = "";
            State.VmCam2Point.LD9m = "";
            State.VmCam2Point.LD9n = "";
            State.VmCam2Point.LD9dp = "";

            State.VmCam2Point.LD13 = "";
            State.VmCam2Point.LD14 = "";
            State.VmCam2Point.LD15 = "";
        }


        private async void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            buttonSave.Background = Brushes.DodgerBlue;
            SaveCameraProp();
            await Task.Delay(150);
            PlaySoundAsync(soundSuccess);
            buttonSave.Background = Brushes.Transparent;
        }

        private void SaveCameraProp()
        {
            //すべてのデータを保存する
            State.cam2Prop.Brightness = General.cam2.Brightness;
            State.cam2Prop.Contrast = General.cam2.Contrast;
            State.cam2Prop.Hue = General.cam2.Hue;
            State.cam2Prop.Saturation = General.cam2.Saturation;
            State.cam2Prop.Sharpness = General.cam2.Sharpness;
            State.cam2Prop.Gamma = General.cam2.Gamma;
            State.cam2Prop.Gain = General.cam2.Gain;
            State.cam2Prop.Exposure = General.cam2.Exposure;
            State.cam2Prop.Whitebalance = General.cam2.Wb;
            State.cam2Prop.Theta = General.cam2.Theta;
            State.cam2Prop.BinLevel = General.cam2.BinLevel;

            State.cam2Prop.Opening = General.cam2.Opening;
            State.cam2Prop.OpenCnt = General.cam2.OpenCnt;
            State.cam2Prop.CloseCnt = General.cam2.CloseCnt;


            State.cam2Prop.LD1a = State.VmCam2Point.LD1a;
            State.cam2Prop.LD1b = State.VmCam2Point.LD1b;
            State.cam2Prop.LD1c = State.VmCam2Point.LD1c;
            State.cam2Prop.LD1d = State.VmCam2Point.LD1d;
            State.cam2Prop.LD1e = State.VmCam2Point.LD1e;
            State.cam2Prop.LD1f = State.VmCam2Point.LD1f;
            State.cam2Prop.LD1g = State.VmCam2Point.LD1g;
            State.cam2Prop.LD1h = State.VmCam2Point.LD1h;
            State.cam2Prop.LD1i = State.VmCam2Point.LD1i;
            State.cam2Prop.LD1j = State.VmCam2Point.LD1j;
            State.cam2Prop.LD1k = State.VmCam2Point.LD1k;
            State.cam2Prop.LD1l = State.VmCam2Point.LD1l;
            State.cam2Prop.LD1m = State.VmCam2Point.LD1m;
            State.cam2Prop.LD1n = State.VmCam2Point.LD1n;
            State.cam2Prop.LD1dp = State.VmCam2Point.LD1dp;

            State.cam2Prop.LD2a = State.VmCam2Point.LD2a;
            State.cam2Prop.LD2b = State.VmCam2Point.LD2b;
            State.cam2Prop.LD2c = State.VmCam2Point.LD2c;
            State.cam2Prop.LD2d = State.VmCam2Point.LD2d;
            State.cam2Prop.LD2e = State.VmCam2Point.LD2e;
            State.cam2Prop.LD2f = State.VmCam2Point.LD2f;
            State.cam2Prop.LD2g = State.VmCam2Point.LD2g;
            State.cam2Prop.LD2h = State.VmCam2Point.LD2h;
            State.cam2Prop.LD2i = State.VmCam2Point.LD2i;
            State.cam2Prop.LD2j = State.VmCam2Point.LD2j;
            State.cam2Prop.LD2k = State.VmCam2Point.LD2k;
            State.cam2Prop.LD2l = State.VmCam2Point.LD2l;
            State.cam2Prop.LD2m = State.VmCam2Point.LD2m;
            State.cam2Prop.LD2n = State.VmCam2Point.LD2n;
            State.cam2Prop.LD2dp = State.VmCam2Point.LD2dp;

            State.cam2Prop.LD3a = State.VmCam2Point.LD3a;
            State.cam2Prop.LD3b = State.VmCam2Point.LD3b;
            State.cam2Prop.LD3c = State.VmCam2Point.LD3c;
            State.cam2Prop.LD3d = State.VmCam2Point.LD3d;
            State.cam2Prop.LD3e = State.VmCam2Point.LD3e;
            State.cam2Prop.LD3f = State.VmCam2Point.LD3f;
            State.cam2Prop.LD3g = State.VmCam2Point.LD3g;
            State.cam2Prop.LD3h = State.VmCam2Point.LD3h;
            State.cam2Prop.LD3i = State.VmCam2Point.LD3i;
            State.cam2Prop.LD3j = State.VmCam2Point.LD3j;
            State.cam2Prop.LD3k = State.VmCam2Point.LD3k;
            State.cam2Prop.LD3l = State.VmCam2Point.LD3l;
            State.cam2Prop.LD3m = State.VmCam2Point.LD3m;
            State.cam2Prop.LD3n = State.VmCam2Point.LD3n;
            State.cam2Prop.LD3dp = State.VmCam2Point.LD3dp;

            State.cam2Prop.LD4a = State.VmCam2Point.LD4a;
            State.cam2Prop.LD4b = State.VmCam2Point.LD4b;
            State.cam2Prop.LD4c = State.VmCam2Point.LD4c;
            State.cam2Prop.LD4d = State.VmCam2Point.LD4d;
            State.cam2Prop.LD4e = State.VmCam2Point.LD4e;
            State.cam2Prop.LD4f = State.VmCam2Point.LD4f;
            State.cam2Prop.LD4g = State.VmCam2Point.LD4g;
            State.cam2Prop.LD4h = State.VmCam2Point.LD4h;
            State.cam2Prop.LD4i = State.VmCam2Point.LD4i;
            State.cam2Prop.LD4j = State.VmCam2Point.LD4j;
            State.cam2Prop.LD4k = State.VmCam2Point.LD4k;
            State.cam2Prop.LD4l = State.VmCam2Point.LD4l;
            State.cam2Prop.LD4m = State.VmCam2Point.LD4m;
            State.cam2Prop.LD4n = State.VmCam2Point.LD4n;
            State.cam2Prop.LD4dp = State.VmCam2Point.LD4dp;

            State.cam2Prop.LD5a = State.VmCam2Point.LD5a;
            State.cam2Prop.LD5b = State.VmCam2Point.LD5b;
            State.cam2Prop.LD5c = State.VmCam2Point.LD5c;
            State.cam2Prop.LD5d = State.VmCam2Point.LD5d;
            State.cam2Prop.LD5e = State.VmCam2Point.LD5e;
            State.cam2Prop.LD5f = State.VmCam2Point.LD5f;
            State.cam2Prop.LD5g = State.VmCam2Point.LD5g;
            State.cam2Prop.LD5h = State.VmCam2Point.LD5h;
            State.cam2Prop.LD5i = State.VmCam2Point.LD5i;
            State.cam2Prop.LD5j = State.VmCam2Point.LD5j;
            State.cam2Prop.LD5k = State.VmCam2Point.LD5k;
            State.cam2Prop.LD5l = State.VmCam2Point.LD5l;
            State.cam2Prop.LD5m = State.VmCam2Point.LD5m;
            State.cam2Prop.LD5n = State.VmCam2Point.LD5n;
            State.cam2Prop.LD5dp = State.VmCam2Point.LD5dp;

            State.cam2Prop.LD6a = State.VmCam2Point.LD6a;
            State.cam2Prop.LD6b = State.VmCam2Point.LD6b;
            State.cam2Prop.LD6c = State.VmCam2Point.LD6c;
            State.cam2Prop.LD6d = State.VmCam2Point.LD6d;
            State.cam2Prop.LD6e = State.VmCam2Point.LD6e;
            State.cam2Prop.LD6f = State.VmCam2Point.LD6f;
            State.cam2Prop.LD6g = State.VmCam2Point.LD6g;
            State.cam2Prop.LD6h = State.VmCam2Point.LD6h;
            State.cam2Prop.LD6i = State.VmCam2Point.LD6i;
            State.cam2Prop.LD6j = State.VmCam2Point.LD6j;
            State.cam2Prop.LD6k = State.VmCam2Point.LD6k;
            State.cam2Prop.LD6l = State.VmCam2Point.LD6l;
            State.cam2Prop.LD6m = State.VmCam2Point.LD6m;
            State.cam2Prop.LD6n = State.VmCam2Point.LD6n;
            State.cam2Prop.LD6dp = State.VmCam2Point.LD6dp;

            State.cam2Prop.LD7a = State.VmCam2Point.LD7a;
            State.cam2Prop.LD7b = State.VmCam2Point.LD7b;
            State.cam2Prop.LD7c = State.VmCam2Point.LD7c;
            State.cam2Prop.LD7d = State.VmCam2Point.LD7d;
            State.cam2Prop.LD7e = State.VmCam2Point.LD7e;
            State.cam2Prop.LD7f = State.VmCam2Point.LD7f;
            State.cam2Prop.LD7g = State.VmCam2Point.LD7g;
            State.cam2Prop.LD7h = State.VmCam2Point.LD7h;
            State.cam2Prop.LD7i = State.VmCam2Point.LD7i;
            State.cam2Prop.LD7j = State.VmCam2Point.LD7j;
            State.cam2Prop.LD7k = State.VmCam2Point.LD7k;
            State.cam2Prop.LD7l = State.VmCam2Point.LD7l;
            State.cam2Prop.LD7m = State.VmCam2Point.LD7m;
            State.cam2Prop.LD7n = State.VmCam2Point.LD7n;
            State.cam2Prop.LD7dp = State.VmCam2Point.LD7dp;

            State.cam2Prop.LD8a = State.VmCam2Point.LD8a;
            State.cam2Prop.LD8b = State.VmCam2Point.LD8b;
            State.cam2Prop.LD8c = State.VmCam2Point.LD8c;
            State.cam2Prop.LD8d = State.VmCam2Point.LD8d;
            State.cam2Prop.LD8e = State.VmCam2Point.LD8e;
            State.cam2Prop.LD8f = State.VmCam2Point.LD8f;
            State.cam2Prop.LD8g = State.VmCam2Point.LD8g;
            State.cam2Prop.LD8h = State.VmCam2Point.LD8h;
            State.cam2Prop.LD8i = State.VmCam2Point.LD8i;
            State.cam2Prop.LD8j = State.VmCam2Point.LD8j;
            State.cam2Prop.LD8k = State.VmCam2Point.LD8k;
            State.cam2Prop.LD8l = State.VmCam2Point.LD8l;
            State.cam2Prop.LD8m = State.VmCam2Point.LD8m;
            State.cam2Prop.LD8n = State.VmCam2Point.LD8n;
            State.cam2Prop.LD8dp = State.VmCam2Point.LD8dp;

            State.cam2Prop.LD9a = State.VmCam2Point.LD9a;
            State.cam2Prop.LD9b = State.VmCam2Point.LD9b;
            State.cam2Prop.LD9c = State.VmCam2Point.LD9c;
            State.cam2Prop.LD9d = State.VmCam2Point.LD9d;
            State.cam2Prop.LD9e = State.VmCam2Point.LD9e;
            State.cam2Prop.LD9f = State.VmCam2Point.LD9f;
            State.cam2Prop.LD9g = State.VmCam2Point.LD9g;
            State.cam2Prop.LD9h = State.VmCam2Point.LD9h;
            State.cam2Prop.LD9i = State.VmCam2Point.LD9i;
            State.cam2Prop.LD9j = State.VmCam2Point.LD9j;
            State.cam2Prop.LD9k = State.VmCam2Point.LD9k;
            State.cam2Prop.LD9l = State.VmCam2Point.LD9l;
            State.cam2Prop.LD9m = State.VmCam2Point.LD9m;
            State.cam2Prop.LD9n = State.VmCam2Point.LD9n;
            State.cam2Prop.LD9dp = State.VmCam2Point.LD9dp;

            State.cam2Prop.LD13 = State.VmCam2Point.LD13;
            State.cam2Prop.LD14 = State.VmCam2Point.LD14;
            State.cam2Prop.LD15 = State.VmCam2Point.LD15;
        }

        private void im_MouseLeave(object sender, MouseEventArgs e)
        {
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;
            General.cam2.FlagHsv = false;
        }

        private void im_MouseEnter(object sender, MouseEventArgs e)
        {
            General.cam2.FlagHsv = true;
            tbHsv.Visibility = System.Windows.Visibility.Visible;
        }

        private void im_MouseMove(object sender, MouseEventArgs e)
        {
            tbPoint.Visibility = System.Windows.Visibility.Visible;
            Point point = e.GetPosition(im);
            tbPoint.Text = "XY=" + ((int)(point.X)).ToString() + "/" + ((int)(point.Y)).ToString();

            General.cam2.PointX = (int)point.X;
            General.cam2.PointY = (int)point.Y;

            tbHsv.Text = "HSV=" + General.cam2.Hdata.ToString() + "," + General.cam2.Sdata.ToString() + "," + General.cam2.Vdata.ToString();
        }

        bool LedAllOn;
        private async void buttonLedOnOff_Click(object sender, RoutedEventArgs e)
        {
            LedAllOn = !LedAllOn;
            if (LedAllOn)
            {
                buttonLedOnOff.Background = OnBrush;
                LPC1768.SendData(Cmd_LD1a);
                await Wait();
                LPC1768.SendData(Cmd_LD1b);
                await Wait();
                LPC1768.SendData(Cmd_LD1c);
                await Wait();
                LPC1768.SendData(Cmd_LD1d);
                await Wait();
                LPC1768.SendData(Cmd_LD1e);
                await Wait();
                LPC1768.SendData(Cmd_LD1f);
                await Wait();
                LPC1768.SendData(Cmd_LD1g);
                await Wait();
                LPC1768.SendData(Cmd_LD1h);
                await Wait();
                LPC1768.SendData(Cmd_LD1i);
                await Wait();
                LPC1768.SendData(Cmd_LD1j);
                await Wait();
                LPC1768.SendData(Cmd_LD1k);
                await Wait();
                LPC1768.SendData(Cmd_LD1l);
                await Wait();
                LPC1768.SendData(Cmd_LD1m);
                await Wait();
                LPC1768.SendData(Cmd_LD1n);
                await Wait();
                LPC1768.SendData(Cmd_LD1p);
                await Wait();

            }
            else
            {
                buttonLedOnOff.Background = OffBrush;
                LPC1768.SendData("Stop");
            }

            async Task Wait()
            {
                await Task.Delay(700);
                LPC1768.SendData("Stop");
                await Task.Delay(100);

            }
        }




        private void toggleSw_Checked(object sender, RoutedEventArgs e)
        {
            General.cam2.Opening = true;
        }

        private void toggleSw_Unchecked(object sender, RoutedEventArgs e)
        {
            General.cam2.Opening = false;
        }


        private void labeling()
        {
            Task.Run(() =>
            {
                while (IsLabeling)
                {
                    if (General.cam2.blobs == null) continue;
                    var blobInfo = General.cam2.blobs.Clone().ToList();
                    if (blobInfo.Count() != 1) continue;

                    var _x = (int)(blobInfo[0].Value.Centroid.X);
                    var _y = (int)(blobInfo[0].Value.Centroid.Y);
                    State.VmCam2Point.BlobPoint = $"X/Y={_x.ToString()},{_y.ToString()}";

                }
            });
        }


        bool IsLabeling;
        private void buttonLabeling_Click(object sender, RoutedEventArgs e)
        {
            IsLabeling = !IsLabeling;

            buttonLabeling.Background = IsLabeling ? OnBrush : OffBrush;

            if (IsLabeling)
            {
                General.cam2.ResetFlag();
                General.cam2.FlagLabeling = true;

                labeling();
            }
            else
            {
                General.cam2.ResetFlag();
            }

        }

        private async void ButtonCalibration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LedAllOn || IsLabeling)
                    return;

                buttonCalibration.Background = OnBrush;
                buttonSave.IsEnabled = false;
                buttonLedOnOff.IsEnabled = false;
                buttonLabeling.IsEnabled = false;

                MakeAllSpec();
                var listLd1_9 = new List<List<LdSpec>>();
                listLd1_9.Add(Ld1Lists);
                listLd1_9.Add(Ld2Lists);
                listLd1_9.Add(Ld3Lists);
                listLd1_9.Add(Ld4Lists);
                listLd1_9.Add(Ld5Lists);
                listLd1_9.Add(Ld6Lists);
                listLd1_9.Add(Ld7Lists);
                listLd1_9.Add(Ld8Lists);
                listLd1_9.Add(Ld9Lists);


                General.cam2.ResetFlag();
                General.cam2.FlagLabeling = true;

                await Task.Delay(1000);

                foreach (var list in listLd1_9)
                {
                    foreach (var l in list)
                    {
                        LPC1768.SendData(l.Cmd);
                        await Task.Delay(500);

                        var blobInfo = General.cam2.blobs.Clone().ToList();
                        if (blobInfo.Count() != 1)
                            goto Fail;

                        var _x = (int)(blobInfo[0].Value.Centroid.X);
                        var _y = (int)(blobInfo[0].Value.Centroid.Y);
                        l.GetPoint = $"{_x.ToString()},{_y.ToString()}";

                        LPC1768.SendData("Stop");
                        await Task.Delay(100);
                    }
                }

                foreach (var l in Ld13_15Lists)
                {
                    LPC1768.SendData(l.Cmd);
                    await Task.Delay(500);

                    var blobInfo = General.cam2.blobs.Clone().ToList();
                    if (blobInfo.Count() != 1)
                        goto Fail;

                    var _x = (int)(blobInfo[0].Value.Centroid.X);
                    var _y = (int)(blobInfo[0].Value.Centroid.Y);
                    l.GetPoint = $"{_x.ToString()},{_y.ToString()}";

                    LPC1768.SendData("Stop");
                    await Task.Delay(100);
                }

                return;
            Fail:
                MessageBox.Show("座標取得に失敗しました");

            }
            finally
            {
                LPC1768.SendData("Stop");
                General.cam2.ResetFlag();
                buttonCalibration.Background = OffBrush;
                buttonSave.IsEnabled = true;
                buttonLedOnOff.IsEnabled = true;
                buttonLabeling.IsEnabled = true;

                SetVm();
            }
        }

        private void SetVm()
        {
            //viewmodelの更新

            //LD1
            State.VmCam2Point.LD1a = Ld1Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD1b = Ld1Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD1c = Ld1Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD1d = Ld1Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD1e = Ld1Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD1f = Ld1Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD1g = Ld1Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD1h = Ld1Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD1i = Ld1Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD1j = Ld1Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD1k = Ld1Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD1l = Ld1Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD1m = Ld1Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD1n = Ld1Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD1dp = Ld1Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;

            //LD1
            State.VmCam2Point.LD2a = Ld2Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD2b = Ld2Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD2c = Ld2Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD2d = Ld2Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD2e = Ld2Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD2f = Ld2Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD2g = Ld2Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD2h = Ld2Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD2i = Ld2Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD2j = Ld2Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD2k = Ld2Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD2l = Ld2Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD2m = Ld2Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD2n = Ld2Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD2dp = Ld2Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;

            //LD3
            State.VmCam2Point.LD3a = Ld3Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD3b = Ld3Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD3c = Ld3Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD3d = Ld3Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD3e = Ld3Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD3f = Ld3Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD3g = Ld3Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD3h = Ld3Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD3i = Ld3Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD3j = Ld3Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD3k = Ld3Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD3l = Ld3Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD3m = Ld3Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD3n = Ld3Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD3dp = Ld3Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;

            //LD4
            State.VmCam2Point.LD4a = Ld4Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD4b = Ld4Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD4c = Ld4Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD4d = Ld4Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD4e = Ld4Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD4f = Ld4Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD4g = Ld4Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD4h = Ld4Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD4i = Ld4Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD4j = Ld4Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD4k = Ld4Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD4l = Ld4Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD4m = Ld4Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD4n = Ld4Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD4dp = Ld4Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;

            //LD5
            State.VmCam2Point.LD5a = Ld5Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD5b = Ld5Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD5c = Ld5Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD5d = Ld5Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD5e = Ld5Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD5f = Ld5Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD5g = Ld5Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD5h = Ld5Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD5i = Ld5Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD5j = Ld5Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD5k = Ld5Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD5l = Ld5Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD5m = Ld5Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD5n = Ld5Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD5dp = Ld5Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;

            //LD6
            State.VmCam2Point.LD6a = Ld6Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD6b = Ld6Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD6c = Ld6Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD6d = Ld6Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD6e = Ld6Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD6f = Ld6Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD6g = Ld6Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD6h = Ld6Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD6i = Ld6Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD6j = Ld6Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD6k = Ld6Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD6l = Ld6Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD6m = Ld6Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD6n = Ld6Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD6dp = Ld6Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;

            //LD7
            State.VmCam2Point.LD7a = Ld7Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD7b = Ld7Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD7c = Ld7Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD7d = Ld7Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD7e = Ld7Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD7f = Ld7Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD7g = Ld7Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD7h = Ld7Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD7i = Ld7Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD7j = Ld7Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD7k = Ld7Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD7l = Ld7Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD7m = Ld7Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD7n = Ld7Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD7dp = Ld7Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;

            //LD8
            State.VmCam2Point.LD8a = Ld8Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD8b = Ld8Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD8c = Ld8Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD8d = Ld8Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD8e = Ld8Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD8f = Ld8Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD8g = Ld8Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD8h = Ld8Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD8i = Ld8Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD8j = Ld8Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD8k = Ld8Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD8l = Ld8Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD8m = Ld8Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD8n = Ld8Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD8dp = Ld8Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;

            //LD9
            State.VmCam2Point.LD9a = Ld9Lists.First(l => l.SegName == SEG_NAME.a).GetPoint;
            State.VmCam2Point.LD9b = Ld9Lists.First(l => l.SegName == SEG_NAME.b).GetPoint;
            State.VmCam2Point.LD9c = Ld9Lists.First(l => l.SegName == SEG_NAME.c).GetPoint;
            State.VmCam2Point.LD9d = Ld9Lists.First(l => l.SegName == SEG_NAME.d).GetPoint;
            State.VmCam2Point.LD9e = Ld9Lists.First(l => l.SegName == SEG_NAME.e).GetPoint;
            State.VmCam2Point.LD9f = Ld9Lists.First(l => l.SegName == SEG_NAME.f).GetPoint;
            State.VmCam2Point.LD9g = Ld9Lists.First(l => l.SegName == SEG_NAME.g).GetPoint;
            State.VmCam2Point.LD9h = Ld9Lists.First(l => l.SegName == SEG_NAME.h).GetPoint;
            State.VmCam2Point.LD9i = Ld9Lists.First(l => l.SegName == SEG_NAME.i).GetPoint;
            State.VmCam2Point.LD9j = Ld9Lists.First(l => l.SegName == SEG_NAME.j).GetPoint;
            State.VmCam2Point.LD9k = Ld9Lists.First(l => l.SegName == SEG_NAME.k).GetPoint;
            State.VmCam2Point.LD9l = Ld9Lists.First(l => l.SegName == SEG_NAME.l).GetPoint;
            State.VmCam2Point.LD9m = Ld9Lists.First(l => l.SegName == SEG_NAME.m).GetPoint;
            State.VmCam2Point.LD9n = Ld9Lists.First(l => l.SegName == SEG_NAME.n).GetPoint;
            State.VmCam2Point.LD9dp = Ld9Lists.First(l => l.SegName == SEG_NAME.p).GetPoint;


            //LD13-15
            State.VmCam2Point.LD13 = Ld13_15Lists.First(l => l.Name == LD13_15_NAME.LD13).GetPoint;
            State.VmCam2Point.LD14 = Ld13_15Lists.First(l => l.Name == LD13_15_NAME.LD14).GetPoint;
            State.VmCam2Point.LD15 = Ld13_15Lists.First(l => l.Name == LD13_15_NAME.LD15).GetPoint;
        }




    }
}
