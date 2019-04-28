using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static PAP_C_DISP_TESTER.UiControl;


namespace PAP_C_DISP_TESTER
{
    /// <summary>
    /// Test.xaml の相互作用ロジック
    /// </summary>
    public partial class Test
    {
        private SolidColorBrush ButtonBrush = new SolidColorBrush();
        private const double ButtonOpacity = 0.3;

        public Test()
        {
            this.InitializeComponent();

            //スタートボタンのデザイン
            ButtonBrush.Color = Colors.DodgerBlue;
            ButtonBrush.Opacity = ButtonOpacity;

            // オブジェクト作成に必要なコードをこの下に挿入します。
            this.DataContext = State.VmTestStatus;
            Canvas検査データ.DataContext = State.VmTestResults;
            CanvasImg1.DataContext = General.cam1;
            CanvasImg2.DataContext = General.cam2;


            (FindResource("Blink") as Storyboard).Begin();

            //試験合格後（１項目試験 or 日常点検）と試験不合格後に、検査ステータス以外をクリアするための処理
            State.TestCommand.RefreshDataContext = InitDataContext;



            //ストーリーボードの初期化
            State.TestCommand.SbRingLoad = (() => { (FindResource("StoryboardRingLoad") as Storyboard).Begin(); });
            State.TestCommand.SbPass = (() => { (FindResource("StoryboardDecision") as Storyboard).Begin(); });
            State.TestCommand.SbFail = (() => { (FindResource("StoryboardDecision") as Storyboard).Begin(); });
            State.TestCommand.StopButtonBlinkOn = (() => { (FindResource("BlinkStopButton") as Storyboard).Begin(); });
            State.TestCommand.StopButtonBlinkOff = (() => { (FindResource("BlinkStopButton") as Storyboard).Stop(); });
            State.TestCommand.RingRotation = (() => { (FindResource("SbRingRotation") as Storyboard).Begin(); });


            //デートコード表記の設定
            var 年 = System.DateTime.Now.ToString("yy");
            var 月 = (Int32.Parse(System.DateTime.Now.ToString("MM")) * 4).ToString("D2");
            State.VmTestStatus.Dc = 年 + 月 + "Ne";



        }

        private void InitDataContext()
        {
            Canvas検査データ.DataContext = State.VmTestResults;
            tbTestLog.DataContext = State.VmTestStatus;
        }




        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //エラーインフォメーションページからテストページに遷移する場合は、
            //下記のif文を有効にする
            if (Flags.ShowErrInfo)
            {
                Flags.ShowErrInfo = false;
            }
            else
            {
                //フォームの初期化
                SetUnitTest();
                ResetViewModel();
                InitDataContext();

                await State.TestCommand.StartCheck();
            }
        }

        private void tbTestLog_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbTestLog.ScrollToEnd();
        }

        private void canvasUnitTest_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CheckBoxUnitTest.IsChecked = false;
            cbUnitTest.SelectedIndex = 0;
        }

        private void SetUnitTest()
        {
            var list = new List<string>();
            var GroupingItems = State.テスト項目.GroupBy(t => t.Key);
            foreach (var g in GroupingItems)
            {
                var addItem = g.First();
                list.Add($"{(addItem.Key * 10).ToString()}_{addItem.Value}");
            }
            State.VmTestStatus.UnitTestItems = list;
            State.VmTestStatus.CbUnitTestIndex = -1;
        }



        private void ButtonErrInfo_Click(object sender, RoutedEventArgs e)
        {
            Flags.ShowErrInfo = true;
            State.VmMainWindow.TabIndex = 3;
        }


        private void Canvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbTestLog.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

        }

        private void Canvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbTestLog.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }


    }


}
