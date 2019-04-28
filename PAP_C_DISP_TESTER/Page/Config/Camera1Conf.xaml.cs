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
    public partial class Camera1Conf
    {

        public Camera1Conf()
        {
            InitializeComponent();
            this.DataContext = General.cam1;
            canvasLdPoint.DataContext = State.VmCam1Point;
            blobPoint.DataContext = State.VmCam1Point;
            toggleSw.IsChecked = General.cam1.Opening;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            State.VmMainWindow.MainWinEnable = false;
            await Task.Delay(1200);
            State.VmMainWindow.MainWinEnable = true;
            State.SetCam1Point();
            General.cam1.Start();
            State.SetCam1Prop();
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;

        }

        private async void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            LedAllOn = false;
            IsLabeling = false;
            General.cam1.ResetFlag();
            await General.cam1.Stop();

            resetView();

            IsLabeling = false;

            buttonLabeling.IsEnabled = true;
            canvasLdPoint.IsEnabled = true;

            //TODO:
            //LEDを全消灯させる処理
            State.SetCam1Prop();
            State.SetCam1Point();
        }

        private void resetView()
        {
            buttonLedOnOff.Background = OffBrush;

            State.VmCam1Point.LD10 = "";
            State.VmCam1Point.LD11 = "";
            State.VmCam1Point.LD12 = "";
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
            State.cam1Prop.Brightness = General.cam1.Brightness;
            State.cam1Prop.Contrast = General.cam1.Contrast;
            State.cam1Prop.Hue = General.cam1.Hue;
            State.cam1Prop.Saturation = General.cam1.Saturation;
            State.cam1Prop.Sharpness = General.cam1.Sharpness;
            State.cam1Prop.Gamma = General.cam1.Gamma;
            State.cam1Prop.Gain = General.cam1.Gain;
            State.cam1Prop.Exposure = General.cam1.Exposure;
            State.cam1Prop.Whitebalance = General.cam1.Wb;
            State.cam1Prop.Theta = General.cam1.Theta;
            State.cam1Prop.BinLevel = General.cam1.BinLevel;

            State.cam1Prop.Opening = General.cam1.Opening;
            State.cam1Prop.OpenCnt = General.cam1.OpenCnt;
            State.cam1Prop.CloseCnt = General.cam1.CloseCnt;


            State.cam1Prop.LD10 = State.VmCam1Point.LD10;
            State.cam1Prop.LD11 = State.VmCam1Point.LD11;
            State.cam1Prop.LD12 = State.VmCam1Point.LD12;
        }

        private void im_MouseLeave(object sender, MouseEventArgs e)
        {
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;
            General.cam1.FlagHsv = false;
        }

        private void im_MouseEnter(object sender, MouseEventArgs e)
        {
            General.cam1.FlagHsv = true;
            tbHsv.Visibility = System.Windows.Visibility.Visible;
        }

        private void im_MouseMove(object sender, MouseEventArgs e)
        {
            tbPoint.Visibility = System.Windows.Visibility.Visible;
            Point point = e.GetPosition(im);
            tbPoint.Text = "XY=" + ((int)(point.X)).ToString() + "/" + ((int)(point.Y)).ToString();

            General.cam1.PointX = (int)point.X;
            General.cam1.PointY = (int)point.Y;

            tbHsv.Text = "HSV=" + General.cam1.Hdata.ToString() + "," + General.cam1.Sdata.ToString() + "," + General.cam1.Vdata.ToString();
        }

        bool LedAllOn;
        private async void buttonLedOnOff_Click(object sender, RoutedEventArgs e)
        {
            LedAllOn = !LedAllOn;
            if (LedAllOn)
            {
                LPC1768.SendData(Cmd_LD10);
                buttonLedOnOff.Background = OnBrush;
            }
            else
            {
                buttonLedOnOff.Background = OffBrush;
                LPC1768.SendData("Stop");
            }

        }




        private void toggleSw_Checked(object sender, RoutedEventArgs e)
        {
            General.cam1.Opening = true;
        }

        private void toggleSw_Unchecked(object sender, RoutedEventArgs e)
        {
            General.cam1.Opening = false;
        }


        private void labeling()
        {
            Task.Run(() =>
            {
                while (IsLabeling)
                {
                    if (General.cam1.blobs == null) continue;
                    var blobInfo = General.cam1.blobs.Clone().ToList();
                    if (blobInfo.Count() != 1) continue;

                    var _x = (int)(blobInfo[0].Value.Centroid.X);
                    var _y = (int)(blobInfo[0].Value.Centroid.Y);
                    State.VmCam1Point.BlobPoint = $"X/Y={_x.ToString()},{_y.ToString()}";

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
                General.cam1.ResetFlag();
                General.cam1.FlagLabeling = true;

                labeling();
            }
            else
            {
                General.cam1.ResetFlag();
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

                General.cam1.ResetFlag();
                General.cam1.FlagLabeling = true;

                await Task.Delay(1000);

                foreach (var l in Ld10_12Lists)
                {
                    LPC1768.SendData(l.Cmd);
                    await Task.Delay(500);

                    var blobInfo = General.cam1.blobs.Clone().ToList();
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
                General.cam1.ResetFlag();
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

            //LD10-12
            State.VmCam1Point.LD10 = Ld10_12Lists.First(l => l.Name == LD10_12_NAME.LD10).GetPoint;
            State.VmCam1Point.LD11 = Ld10_12Lists.First(l => l.Name == LD10_12_NAME.LD11).GetPoint;
            State.VmCam1Point.LD12 = Ld10_12Lists.First(l => l.Name == LD10_12_NAME.LD12).GetPoint;
        }


    }
}
