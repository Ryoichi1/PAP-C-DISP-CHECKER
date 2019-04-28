using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Threading.Thread;

namespace PAP_C_DISP_TESTER
{
    public static class UiControl
    {

        //インスタンス変数の宣言
        public static SoundPlayer player = null;
        public static SoundPlayer soundPass = null;
        public static SoundPlayer soundEdy = null;
        public static SoundPlayer soundFail = null;
        public static SoundPlayer soundAlarm = null;
        public static SoundPlayer soundCutIn = null;
        public static SoundPlayer soundSuccess = null;
        public static SoundPlayer soundNotice = null;
        public static SoundPlayer soundLabel = null;
        public static SoundPlayer soundStart = null;


        public static SolidColorBrush OnBrush = new SolidColorBrush();
        public static SolidColorBrush OffBrush = new SolidColorBrush();
        public static SolidColorBrush NgBrush = new SolidColorBrush();

        static UiControl()
        {

            //オーディオリソースを取り出す
            soundPass = new SoundPlayer(@"Resources\Wav\PassLong.wav");
            soundEdy = new SoundPlayer(@"Resources\Wav\Edy.wav");
            soundFail = new SoundPlayer(@"Resources\Wav\Fail.wav");
            soundAlarm = new SoundPlayer(@"Resources\Wav\Alarm.wav");
            soundSuccess = new SoundPlayer(@"Resources\Wav\Success.wav");
            soundNotice = new SoundPlayer(@"Resources\Wav\Notice.wav");
            soundLabel = new SoundPlayer(@"Resources\Wav\Label.wav");
            soundCutIn = new SoundPlayer(@"Resources\Wav\CutIn.wav");
            soundStart = new SoundPlayer(@"Resources\Wav\Start.wav");

            OffBrush.Color = Colors.Transparent;

            OnBrush.Color = Colors.DodgerBlue;
            OnBrush.Opacity = Constants.PanelOpacity;

            NgBrush.Color = Colors.Magenta;
            NgBrush.Opacity = Constants.PanelOpacity;
        }

        public static void Show()
        {
            var T = 0.3;
            var t = 0.005;

            State.setting.OpacityTheme = State.VmMainWindow.ThemeOpacity;
            //10msec刻みでT秒で元のOpacityに戻す
            int times = (int)(T / t);

            State.VmMainWindow.ThemeOpacity = 0;
            Task.Run(() =>
            {
                while (true)
                {

                    State.VmMainWindow.ThemeOpacity += State.setting.OpacityTheme / (double)times;
                    Sleep((int)(t * 1000));
                    if (State.VmMainWindow.ThemeOpacity >= State.setting.OpacityTheme) return;

                }
            });
        }

        public static void SetRadius(bool sw)
        {
            var R = 20;
            var T = 0.45;//アニメーションが完了するまでの時間（秒）
            var t = 0.005;//（秒）

            //5msec刻みでT秒で元のOpacityに戻す
            int times = (int)(T / t);


            Task.Run(() =>
            {
                if (sw)
                {
                    while (true)
                    {
                        State.VmMainWindow.ThemeBlurEffectRadius += R / (double)times;
                        Sleep((int)(t * 1000));
                        if (State.VmMainWindow.ThemeBlurEffectRadius >= R) return;

                    }
                }
                else
                {
                    var CurrentRadius = State.VmMainWindow.ThemeBlurEffectRadius;
                    while (true)
                    {
                        CurrentRadius -= R / (double)times;
                        if (CurrentRadius > 0)
                        {
                            State.VmMainWindow.ThemeBlurEffectRadius = CurrentRadius;
                        }
                        else
                        {
                            State.VmMainWindow.ThemeBlurEffectRadius = 0;
                            return;
                        }
                        Sleep((int)(t * 1000));
                    }
                }

            });
        }

        //**************************************************************************
        //WAVEファイルを再生する
        //引数：なし
        //戻値：なし
        //**************************************************************************  
        public static void PlaySoundAsync(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.Play();
        }
        //WAVEファイルを再生する（同期で再生）
        public static void PlaySoundSync(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.PlaySync();

        }

        public static void PlaySoundLoop(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.PlayLooping();
        }

        //再生されているWAVEファイルを止める
        public static void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        public static void ResetViewModel()//TODO:
        {
            //試験結果のクリア
            State.VmTestResults = new ViewModelTestResult();

            //ViewModelの初期化 判定表示
            State.VmTestStatus.進捗度 = 0;
            State.VmTestStatus.TestTime = "00:00:00";
            State.VmTestStatus.OkCount = State.setting.TodayOkCount.ToString() + "台";
            State.VmTestStatus.NgCount = State.setting.TodayNgCount.ToString() + "台";
            State.VmTestStatus.FailInfo = "";
            State.VmTestStatus.Spec = "";
            State.VmTestStatus.MeasValue = "";

            //ViewModelの初期化 ログ
            State.VmTestStatus.TestLog = "";


            ////ViewModelの初期化 作業者へのメッセージ
            //State.VmTestStatus.Message = Constants.MessSet;

            //各種可視化の設定
            State.VmTestStatus.DecisionVisibility = System.Windows.Visibility.Hidden;
            State.VmTestStatus.ErrInfoVisibility = System.Windows.Visibility.Hidden;
            State.VmTestStatus.RingVisibility = System.Windows.Visibility.Visible;
            State.VmTestStatus.EnableButtonErrInfo = System.Windows.Visibility.Hidden;//エラーで検査終了すると表示されたままになるので隠す（誤動作防止！！！）

            //他ページへの遷移を許可する
            State.VmMainWindow.EnableOtherButton = true;

            //各種フラグの初期化
            Flags.PowOn = false;
            Flags.Testing = false;
            Flags.Retry = false;
            Flags.EnableTestStart = false;

            State.VmTestStatus.TestSettingEnable = true;
            State.VmMainWindow.OperatorEnable = true;


            //次回試験時にチェックしたままだと、ソフト書き忘れてNGになるため、毎回初期化する
            State.VmTestStatus.CheckWriteTestFwPass = false;

            SetRadius(false);

            Flags.ShowDecision = false;
        }



    }
}
