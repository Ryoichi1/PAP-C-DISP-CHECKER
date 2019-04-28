using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Threading.Thread;
using static PAP_C_DISP_TESTER.GeneralFuncForTest;

namespace PAP_C_DISP_TESTER
{


    public static class General
    {
        public static Camera cam1 = new Camera(State.cam1Prop.CamNumber, Constants.filePath_Camera1CalFilePath, 640, 360);
        public static Camera cam2 = new Camera(State.cam2Prop.CamNumber, Constants.filePath_Camera2CalFilePath, 640, 360);

        public static FFT wv = new FFT();

        //**************************************************************************
        //検査データの保存　　　　
        //引数：なし
        //戻値：なし
        //**************************************************************************
        //private static List<string> MakePassTestData()//TODO:
        //{
        //    var ListData = new List<string>
        //    {
        //        "AssemblyVer " + State.AssemblyInfo,
        //        "TestSpecVer " + State.spec.TestSpecVer,
        //        System.DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH：mm：ss"),
        //        State.VmMainWindow.Operator,
        //        State.VmMainWindow.Opecode,
        //        State.VmTestStatus.Dc,
        //        State.VmTestStatus.FwVerApp,
        //        State.VmTestStatus.FwSumApp,
        //        State.VmTestStatus.FwVerBcr,
        //        State.VmTestStatus.FwSumBcr,
        //        //電源電圧
        //        State.VmTestResults.Vdd,
        //        State.VmTestResults.Vdd1,
        //        State.VmTestResults.Vcc,
        //        State.VmTestResults.Vr,
        //        State.VmTestResults.M12v,
        //        State.VmTestResults.Bt,

        //        //入力電流
        //        State.VmTestResults.Current,

        //        //内部温度
        //        State.VmTestResults.TempBcr,

        //        //RTC
        //        State.VmTestResults.ResRtcHost,
        //        State.VmTestResults.ResRtcTarget,
        //        State.VmTestResults.ResRtcErr,

        //        //AFD
        //        State.VmTestResults.Afd90K,
        //        State.VmTestResults.AfdOpen,

        //        //Flame Rod
        //        State.VmTestResults.Fr120M,
        //        State.VmTestResults.FrOpen,

        //        //高水位
        //        State.VmTestResults.ResHi6kAd,
        //        State.VmTestResults.ResHi13kAd,

        //        //低水位
        //        State.VmTestResults.ResLo6kAd,
        //        State.VmTestResults.ResLo13kAd,

        //        //蒸気温度サーミスタ
        //        State.VmTestResults.Temp160,
        //        State.VmTestResults.Temp190,
        //        State.VmTestResults.Temp230,

        //        //逆火温度サーミスタ
        //        State.VmTestResults.Temp110,
        //        State.VmTestResults.Temp100,
        //        State.VmTestResults.Temp88,

        //        //燃焼シーケンスガス
        //        State.VmTestResults.PrepurgeGas,
        //        State.VmTestResults.IgTryGas,
        //        State.VmTestResults.MainTryGas,
        //        State.VmTestResults.FlameResGas,

        //        //燃焼シーケンス油
        //        State.VmTestResults.PrepurgeOil,
        //        State.VmTestResults.PreIgOil,
        //        State.VmTestResults.IgTryOil,
        //        State.VmTestResults.FlameResOil,

        //        //クロック検査
        //        State.VmTestResults.Clock_S_M,
        //        State.VmTestResults.Clock_M_S,

        //    };

        //    return ListData;
        //}

        //public static bool SaveTestData()
        //{
        //    try
        //    {
        //        var dataList = new List<string>();
        //        dataList = MakePassTestData();

        //        var OkDataFilePath = State.PathForPassData + State.VmMainWindow.Opecode + ".csv";

        //        if (!System.IO.File.Exists(OkDataFilePath))
        //        {
        //            //既存検査データがなければ新規作成
        //            File.Copy(Constants.fileName_FormatPass, OkDataFilePath);
        //        }

        //        // リストデータをすべてカンマ区切りで連結する
        //        string stCsvData = string.Join(",", dataList);

        //        // appendをtrueにすると，既存のファイルに追記
        //        // falseにすると，ファイルを新規作成する
        //        var append = true;

        //        // 出力用のファイルを開く
        //        using (var sw = new System.IO.StreamWriter(OkDataFilePath, append, Encoding.GetEncoding("Shift_JIS")))
        //        {
        //            sw.WriteLine(stCsvData);
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public static bool SaveNgData(List<string> dataList)
        //{
        //    try
        //    {
        //        var NgDataFilePath = State.PathForFailData + State.VmMainWindow.Opecode + ".csv";
        //        if (!File.Exists(NgDataFilePath))
        //        {
        //            //既存検査データがなければ新規作成
        //            File.Copy(Constants.fileName_FormatFail, NgDataFilePath);
        //        }

        //        var stArrayData = dataList.ToArray();
        //        // リストデータをすべてカンマ区切りで連結する
        //        string stCsvData = string.Join(",", stArrayData);

        //        // appendをtrueにすると，既存のファイルに追記
        //        //         falseにすると，ファイルを新規作成する
        //        var append = true;

        //        // 出力用のファイルを開く
        //        using (var sw = new System.IO.StreamWriter(NgDataFilePath, append, Encoding.GetEncoding("Shift_JIS")))
        //        {
        //            sw.WriteLine(stCsvData);
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}


        public static void CheckAll周辺機器フラグ()
        {
            Flags.AllOk周辺機器接続 = (Flags.StateMbed && cam1.CamState && cam2.CamState);
        }

        /// <summary>
        /// 周辺機器の初期化
        /// </summary>
        public static void InitDevices()//TODO:
        {

            Flags.Initializing周辺機器 = true;

            Task.Run(() =>
            {
                Flags.DoGetDeviceName = true;
                while (Flags.DoGetDeviceName)
                {
                    FindSerialPort.GetDeviceNames();
                    Thread.Sleep(400);
                }

            });


            //LPC1768の初期化
            bool StopMbed = false;
            Task.Run(() =>
            {
                while (true)
                {
                    if (Flags.StopInit周辺機器)
                        break;

                    Flags.StateMbed = LPC1768.Init();
                    if (Flags.StateMbed)
                        break;

                    Thread.Sleep(500);
                }
                StopMbed = true;
            });



            //カメラの初期化
            //Win10でカメラ複数使用の場合、非同期で初期化をするとカメラのプロパティ画面が表示されてしまう
            //カメラは1ケづつ順番に初期化した方が良い
            bool StopCamera1 = false;
            bool StopCamera2 = false;
            Task.Run(() =>
            {
                while (true)
                {
                    if (Flags.StopInit周辺機器)
                        break;

                    cam1.InitCamera();
                    if (Flags.StateCamera1 = cam1.CamState)
                        break;

                    Thread.Sleep(500);
                }
                StopCamera1 = true;

                while (true)
                {
                    if (Flags.StopInit周辺機器)
                        break;

                    cam2.InitCamera();
                    if (Flags.StateCamera2 = cam2.CamState)
                        break;

                    Thread.Sleep(500);
                }
                StopCamera2 = true;
            });

            Task.Run(() =>
            {
            });


            Task.Run(() =>
            {
                while (true)
                {
                    CheckAll周辺機器フラグ();
                    var IsAllStopped = StopMbed && StopCamera1 && StopCamera2;

                    if (Flags.AllOk周辺機器接続 || IsAllStopped) break;
                    Thread.Sleep(400);

                }
                Flags.DoGetDeviceName = false;
                Thread.Sleep(500);
                Flags.Initializing周辺機器 = false;
            });

        }



        public static void GetBuzzData()
        {
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
                    State.VmTestResults.VolLev = General.wv.Vol.ToString("F2");
                    State.VmTestResults.Freq = General.wv.Freq.ToString("F0") + "Hz";
                    //State.VmTestStatus.DataList1 = General.wv.VolPoints;
                    //State.VmTestStatus.DataList2 = General.wv.FreqPoints;
                    //Thread.Sleep(125);
            //    }
            //});
        }


        public static bool CheckPressIsClose()
        {
            LPC1768.SendData("R,P22");
            return (LPC1768.RecieveData.Contains("L"));
        }

        public static void StampOn() => LPC1768.SendData("STAMP");


        public static void ResetIo()
        {
            LPC1768.SendData("ResetIo");
        }

        public static void SetBz(bool sw)
        {
            if (sw)
                LPC1768.SendData("BzOn");
            else
                LPC1768.SendData("BzOff");
        }

        public static void PushSw1(bool sw) => LPC1768.SendData("SW1," + (sw ? "1" : "0"));
        public static void PushSw2(bool sw) => LPC1768.SendData("SW2," + (sw ? "1" : "0"));
        public static void PushSw3(bool sw) => LPC1768.SendData("SW3," + (sw ? "1" : "0"));
        public static void PushSw4(bool sw) => LPC1768.SendData("SW4," + (sw ? "1" : "0"));
        public static void PushSw5(bool sw) => LPC1768.SendData("SW5," + (sw ? "1" : "0"));
        public static void PushSw6(bool sw) => LPC1768.SendData("SW6," + (sw ? "1" : "0"));
        public static void PushSw7(bool sw) => LPC1768.SendData("SW7," + (sw ? "1" : "0"));



    }

}

