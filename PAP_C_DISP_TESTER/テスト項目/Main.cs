
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Effects;
using static PAP_C_DISP_TESTER.UiControl;

namespace PAP_C_DISP_TESTER
{
    public class Main
    {

        //デリゲートの宣言(Test.xaml内のメソッドを使用するため)
        public Action RefreshDataContext;//Test.Xaml内でテスト結果をクリアするために使用すする
        public Action SbRingLoad;
        public Action SbPass;
        public Action SbFail;
        public Action StopButtonBlinkOn;
        public Action StopButtonBlinkOff;
        public Action RingRotation;


        DropShadowEffect effect判定表示PASS;
        DropShadowEffect effect判定表示FAIL;

        public Main()
        {
            effect判定表示PASS = new DropShadowEffect();
            effect判定表示PASS.Color = Colors.Aqua;
            effect判定表示PASS.Direction = 0;
            effect判定表示PASS.ShadowDepth = 0;
            effect判定表示PASS.Opacity = 1.0;
            effect判定表示PASS.BlurRadius = 80;

            effect判定表示FAIL = new DropShadowEffect();
            effect判定表示FAIL.Color = Colors.HotPink; ;
            effect判定表示FAIL.Direction = 0;
            effect判定表示FAIL.ShadowDepth = 0;
            effect判定表示FAIL.Opacity = 1.0;
            effect判定表示FAIL.BlurRadius = 40;

        }

        public async Task StartCheck()
        {
            var dis = App.Current.Dispatcher;

            while (true)
            {
                await Task.Run(() =>
                {

                    while (true)
                    {

                        Thread.Sleep(200);
                        if (Flags.OtherPage) break;
                        Thread.Sleep(200);

                        Flags.EnableTestStart = false;

                        //作業者名、工番が正しく入力されているかの判定
                        if (!Flags.SetOperator)
                        {
                            State.VmTestStatus.Message = Constants.MessOperator;
                            continue;
                        }

                        if (!Flags.SetOpecode)
                        {
                            State.VmTestStatus.Message = Constants.MessOpecode;
                            continue;
                        }

                        General.CheckAll周辺機器フラグ();
                        if (!Flags.AllOk周辺機器接続)
                        {
                            State.VmTestStatus.Message = Constants.MessCheckConnectMachine;
                            continue;
                        }


                        State.VmTestStatus.Message = Constants.MessSet;

                        if (!General.CheckPressIsClose())
                        {
                            continue;
                        }


                        while (true)
                        {
                            if (Flags.OtherPage || General.CheckPressIsClose())
                            {
                                return;
                            }

                            if (!Flags.SetOperator || !Flags.SetOpecode)
                            {
                                break;//最初からやり直し
                            }
                        }
                    }
                });

                //

                if (Flags.OtherPage)//待機中に他のページに遷移したらメソッドを抜ける
                {
                    return;
                }


                State.VmMainWindow.EnableOtherButton = false;
                State.VmTestStatus.TestSettingEnable = false;
                State.VmMainWindow.OperatorEnable = false;


                PlaySoundAsync(soundStart);
                await Task.Delay(1500);
                await Test();//メインルーチンへ


                ////試験合格後、ラベル貼り付けページを表示する場合は下記のステップを追加すること
                //if (Flags.ShowLabelPage) return;

                ////日常点検合格、一項目試験合格、試験NGの場合は、Whileループを繰り返す
                ////通常試験合格の場合は、ラベル貼り付けフォームがロードされた時点で、一旦StartCheckメソッドを終了します
                ////その後、ラベル貼り付けフォームが閉じられた後に、Test.xamlがリロードされ、そのフォームロードイベントでStartCheckメソッドがコールされます

            }

        }

        //メインルーチンで使用するメンバ
        int RetryCnt = 0;//リトライ用に使用する
        int StepNo = 0;
        string Title = "";

        /// <summary>
        ///メインルーチン 
        /// </summary>
        /// <returns></returns>
        public async Task Test()
        {
            RetryCnt = 0;
            var IsTestNg = false;
            InitBeforeTest();
            var テスト項目最新 = ExtractInspectionItems();

            try
            {
                //IO初期化
                await Task.Delay(200);

                //カメラは同時に2ケ起動できないので、画像検査前に使用するカメラだけ起動する
                ////State.SetCam2Point();
                ////General.cam2.Start();
                ////State.SetCam2Prop();




                foreach (var d in テスト項目最新.Select((s, i) => new { i, s }))
                {
                Retry:

                    State.VmTestStatus.EnableButtonErrInfo = System.Windows.Visibility.Hidden;
                    Flags.AddDecision = true;
                    StepNo = d.s.StepNo;
                    Title = d.s.Value;
                    SetTestLog("\n" + d.s.StepNo.ToString() + "_" + d.s.Value);

                    if (!await d.s.testProc())
                    {
                        if (CheckDoRetry())
                        {
                            //NG詳細表示ボタンがvisibleになっている可能性があるため、hiddenに戻す
                            State.VmTestStatus.ErrInfoVisibility = System.Windows.Visibility.Hidden;
                            goto Retry;
                        }
                        else
                        {
                            IsTestNg = true;
                            break;
                        }
                    }


                    await ProcAfeterOneItemPass(d.i, テスト項目最新.Count());
                }

                await Task.Delay(250);
                //↓↓すべての項目が合格した時の処理です↓↓
                await CommonProcAfterTesting();

                if (IsTestNg)
                {
                    Flags.TestDecision = false;
                    Flags.ShowDecision = true;
                    await FailProc();
                }
                else
                {
                    Flags.TestDecision = true;
                    Flags.ShowDecision = true;
                    await PassProc();
                }

            }
            catch
            {
                //例外なのでリセット処理とカメラ停止を強制的に行う
                await General.cam1.Stop();
                await General.cam2.Stop();
                System.Windows.Forms.MessageBox.Show("想定外の例外発生DEATH！！！\r\n申し訳ありませんが再起動してください");
                Environment.Exit(0);

            }
            finally
            {
                //SbRingLoad();
                ResetViewModel();
                RefreshDataContext();
            }
        }



        private void Timer()
        {
            var t = Task.Run(() =>
            {
                //Stopwatchオブジェクトを作成する
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                while (Flags.DoMeasureTime)
                {
                    Thread.Sleep(200);
                    State.VmTestStatus.TestTime = sw.Elapsed.ToString().Substring(0, 8);
                }
                sw.Stop();
            });
        }



        /// <summary>
        /// 試験開始前に各種フラグ、ビューの初期化を行う
        /// </summary>
        private void InitBeforeTest()
        {
            State.VmMainWindow.EnableOtherButton = false;
            State.VmTestStatus.TestSettingEnable = false;
            State.VmMainWindow.OperatorEnable = false;

            Flags.Testing = true;
            Flags.DoMeasureTime = true;
            State.VmTestStatus.Message = Constants.MessWait;

            //現在のテーマ透過度の保存
            State.CurrentThemeOpacity = State.VmMainWindow.ThemeOpacity;

            SetRadius(true);
            Timer();
        }

        /// <summary>
        /// テスト項目の抽出
        /// </summary>
        private List<TestDetail> ExtractInspectionItems()
        {
            var テスト項目最新 = new List<TestDetail>();
            if (State.VmTestStatus.CheckUnitTest == true)
            {
                //チェックしてある項目の百の桁の解析
                var re = Int32.Parse(State.VmTestStatus.UnitTestName.Split('_').ToArray()[0]);

                var GroupingItems = State.テスト項目.GroupBy(t => t.Key);
                foreach (var G in GroupingItems)
                {
                    if (G.Min(t => t.StepNo) == re)
                    {
                        foreach (var g in G)
                        {
                            テスト項目最新.Add(g);
                        }
                    }
                }

            }
            else
            {
                テスト項目最新 = State.テスト項目;
            }
            return テスト項目最新;
        }

        /// <summary>
        /// エラー時のリトライ可否
        /// </summary>
        /// <returns></returns>
        private bool CheckDoRetry()
        {
            if (Flags.AddDecision) SetTestLog("---- FAIL");
            Flags.Retry = true;

            if (++RetryCnt <= Constants.RetryCount)
            {
                //リトライ履歴リスト更新
                State.RetryLogList.Add(StepNo.ToString() + "," + Title + "," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                return true;
            }

            return false;
        }

        /// <summary>
        /// 各ステップが合格したあとの処理
        /// </summary>
        /// <returns></returns>
        private async Task ProcAfeterOneItemPass(int stepCount, int totalStepCount)
        {
            if (Flags.AddDecision)
                SetTestLog("---- PASS");

            State.VmTestStatus.Spec = "規格値 : ---";
            State.VmTestStatus.MeasValue = "計測値 : ---";
            State.VmTestStatus.Message = Constants.MessWait;

            //リトライステータスをリセットする
            RetryCnt = 0;
            Flags.Retry = false;

            //プログレスバーの更新
            await Task.Run(() =>
            {
                var CurrentProgValue = State.VmTestStatus.進捗度;
                var NextProgValue = (int)(((stepCount + 1) / (double)totalStepCount) * 100);
                var 変化量 = NextProgValue - CurrentProgValue;
                foreach (var p in Enumerable.Range(1, 変化量))
                {
                    State.VmTestStatus.進捗度 = CurrentProgValue + p;
                    if (State.VmTestStatus.CheckUnitTest == false)
                    {
                        Thread.Sleep(5);
                    }
                }
            });
        }




        private async Task PassProc()
        {
            if (State.VmTestStatus.CheckUnitTest == false)
            {
                //当日試験不合格数をインクリメント ビューモデルはまだ更新しない
                State.setting.TodayOkCount++;
            }

            State.VmTestStatus.EffectDecision = null;
            State.VmTestStatus.ColorDecision = Brushes.DeepSkyBlue;
            State.VmTestStatus.Decision = "PASS";

            if (State.VmTestStatus.CheckUnitTest == false)
                General.StampOn();//合格印押し

            ResetRing();
            //RingRotation();
            await Task.Delay(300);
            SetDecision();
            SbPass();

            if (State.VmTestStatus.CheckUnitTest != true) //null or False アプリ立ち上げ時はnullになっている！
            {

                PlaySoundAsync(soundPass);
            }
            else
            {
                PlaySoundAsync(soundEdy);
            }

            await Task.Run(() =>
            {
                while (true)
                {
                    if (!General.CheckPressIsClose())
                        break;
                    Thread.Sleep(100);
                }
            });
            StopSound();
        }

        private async Task FailProc()
        {
            if (State.VmTestStatus.CheckUnitTest == false)
            {
                //当日試験不合格数をインクリメント ビューモデルはまだ更新しない
                State.setting.TodayNgCount++;
            }
            await Task.Delay(100);

            State.VmTestStatus.ColorDecision = Brushes.AliceBlue;
            State.VmTestStatus.Decision = "FAIL";
            State.VmTestStatus.EffectDecision = effect判定表示FAIL;

            SetErrorMessage(StepNo, Title);

            var NgDataList = new List<string>()
                                    {
                                        State.VmMainWindow.Opecode,
                                        State.VmMainWindow.Model,
                                        State.VmMainWindow.Operator,
                                        System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                        State.VmTestStatus.FailInfo,
                                        State.VmTestStatus.Spec,
                                        State.VmTestStatus.MeasValue
                                    };

            //General.SaveNgData(NgDataList);


            ResetRing();
            SetDecision();
            SetErrInfo();
            SbFail();

            PlaySoundAsync(soundFail);

            StopButtonBlinkOn();
            await Task.Run(() =>
            {
                while (true)
                {
                    if (!General.CheckPressIsClose())
                        break;
                    Thread.Sleep(100);
                }
            });
            StopButtonBlinkOff();
        }

        private async Task CommonProcAfterTesting()
        {
            await Task.Delay(500);
            await General.cam1.Stop();
            await General.cam2.Stop();
            State.VmTestStatus.Message = Constants.MessRemove;
            Flags.DoMeasureTime = false;
        }



        private void SetErrorMessage(int stepNo, string title)
        {
            State.VmTestStatus.FailInfo = "<エラーコード " + stepNo.ToString() + ">   " + title + "異常";
        }

        //テストログの更新
        private void SetTestLog(string addData)
        {
            State.VmTestStatus.TestLog += addData;
        }

        private void ResetRing()
        {
            State.VmTestStatus.RingVisibility = System.Windows.Visibility.Hidden;

        }

        private void SetDecision()
        {
            State.VmTestStatus.DecisionVisibility = System.Windows.Visibility.Visible;
        }

        private void SetErrInfo()
        {
            State.VmTestStatus.ErrInfoVisibility = System.Windows.Visibility.Visible;
        }



    }
}
