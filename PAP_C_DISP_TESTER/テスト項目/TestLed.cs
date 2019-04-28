using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Threading.Thread;
using static PAP_C_DISP_TESTER.GeneralFuncForTest;
using static PAP_C_DISP_TESTER.General;


namespace PAP_C_DISP_TESTER.TestItems
{

    static class TestLed
    {
        const int WIDTH = 640;
        const int HEIGHT = 360;

        private static IplImage source = new IplImage(WIDTH, HEIGHT, BitDepth.U8, 3);

        private static (int x, int y) GetRef_XY(string refPoint)
        {
            var X = 0;
            var Y = 0;

            X = Int32.Parse(refPoint.Split(',').ToArray()[0]);
            Y = Int32.Parse(refPoint.Split(',').ToArray()[1]);
            return (X, Y);
        }


        public static async Task<bool> CheckLD10_12()
        {
            double errPoint = 5;
            var resultAll = false;
            var reX = false;
            var reY = false;

            try
            {
                State.SetCam1Point();
                General.cam1.Start();
                State.SetCam1Prop();
                Thread.Sleep(1500);
                return await Task<bool>.Run(() =>
                {
                    Flags.AddDecision = false;
                    MakeAllSpec();

                    General.cam1.ResetFlag();//カメラのフラグを初期化 リトライ時にフラグが初期化できてないとだめ
                                             //例 ＮＧリトライ時は、General.cam.FlagFrame = trueになっていてNGフレーム表示の無限ループにいる
                    General.cam1.FlagLabeling = true;
                    Thread.Sleep(1000);

                    return resultAll = Ld10_12Lists.All(l =>
                    {
                        //テストログの更新
                        State.VmTestStatus.TestLog += $"\n    {l.Name.ToString()}チェック";
                        LPC1768.SendData(l.Cmd);

                        var tm = new GeneralTimer(3000);
                        tm.Start();
                        while (true)
                        {
                            if (tm.FlagTimeout) return false;

                            if (General.cam1.blobs == null) continue;
                            var blobInfo = General.cam1.blobs.Clone();

                            if (blobInfo.Count() != 1) continue;

                            var blob = blobInfo.ToList()[0];

                            var refX = GetRef_XY(l.RefPoint).x;
                            var refY = GetRef_XY(l.RefPoint).y;

                            reX = refX - errPoint < blob.Value.Centroid.X && blob.Value.Centroid.X < refX + errPoint;
                            reY = refY - errPoint < blob.Value.Centroid.Y && blob.Value.Centroid.Y < refY + errPoint;

                            var result = reX && reY;
                            if (result)
                            {
                                State.VmTestStatus.TestLog += "---PASS";
                            }
                            else
                            {
                                State.VmTestStatus.TestLog += "---FAIL";
                                Sleep(1000);//NGの場合、確認できるように少しウェイトを入れる
                            }
                            LPC1768.SendData("Stop");
                            Sleep(250);//
                            return result;
                        }
                    });


                });

            }
            finally
            {
                LPC1768.SendData("Stop");
                await cam1.Stop();
                await Task.Delay(400);

                if (!resultAll)
                {
                    var PointComment = "";
                    var AreaComment = "";
                    if (!reX || !reY)
                        PointComment = "座標NG,";

                    State.VmTestStatus.Spec = "規格値 : ";
                    State.VmTestStatus.MeasValue = "計測値 : " + PointComment + AreaComment;
                }
            }
        }
        public static async Task<bool> CheckLD1_9()
        {
            double errPoint = 5;
            var resultAll = false;
            var reX = false;
            var reY = false;

            try
            {
                State.SetCam2Point();
                General.cam2.Start();
                State.SetCam2Prop();
                Thread.Sleep(1500);
                return await Task<bool>.Run(() =>
                {
                    Flags.AddDecision = false;
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



                    General.cam2.ResetFlag();//カメラのフラグを初期化 リトライ時にフラグが初期化できてないとだめ
                                             //例 ＮＧリトライ時は、General.cam.FlagFrame = trueになっていてNGフレーム表示の無限ループにいる
                    General.cam2.FlagLabeling = true;
                    Thread.Sleep(1000);

                    return resultAll = listLd1_9.All(L =>
                    {
                        return L.All(l =>
                        {
                            //テストログの更新
                            State.VmTestStatus.TestLog += $"\n    {l.Name} {l.SegName.ToString()}チェック";
                            LPC1768.SendData(l.Cmd);

                            var tm = new GeneralTimer(3000);
                            tm.Start();
                            while (true)
                            {
                                if (tm.FlagTimeout) return false;

                                if (General.cam2.blobs == null) continue;
                                var blobInfo = General.cam2.blobs.Clone();

                                if (blobInfo.Count() != 1) continue;

                                var blob = blobInfo.ToList()[0];

                                var refX = GetRef_XY(l.RefPoint).x;
                                var refY = GetRef_XY(l.RefPoint).y;

                                reX = refX - errPoint < blob.Value.Centroid.X && blob.Value.Centroid.X < refX + errPoint;
                                reY = refY - errPoint < blob.Value.Centroid.Y && blob.Value.Centroid.Y < refY + errPoint;

                                var result = reX && reY;
                                if (result)
                                {
                                    State.VmTestStatus.TestLog += "---PASS";
                                }
                                else
                                {
                                    State.VmTestStatus.TestLog += "---FAIL";
                                    Sleep(1000);//NGの場合、確認できるように少しウェイトを入れる
                                }
                                LPC1768.SendData("Stop");
                                Sleep(250);//
                                return result;
                            }

                        });
                    });


                });

            }
            finally
            {
                LPC1768.SendData("Stop");
                await cam2.Stop();
                await Task.Delay(400);
                if (!resultAll)
                {
                    var PointComment = "";
                    if (!reX || !reY)
                        PointComment = "座標NG,";

                    State.VmTestStatus.Spec = "規格値 : ";
                    State.VmTestStatus.MeasValue = "計測値 : " + PointComment;
                }
            }
        }
        public static async Task<bool> CheckLD13_15()
        {
            double errPoint = 5;
            var resultAll = false;
            var reX = false;
            var reY = false;

            try
            {
                State.SetCam2Point();
                General.cam2.Start();
                State.SetCam2Prop();
                Thread.Sleep(1500);
                return await Task<bool>.Run(() =>
                {
                    Flags.AddDecision = false;
                    MakeAllSpec();

                    General.cam2.ResetFlag();//カメラのフラグを初期化 リトライ時にフラグが初期化できてないとだめ
                                             //例 ＮＧリトライ時は、General.cam.FlagFrame = trueになっていてNGフレーム表示の無限ループにいる
                    General.cam2.FlagLabeling = true;
                    Thread.Sleep(1000);

                    return resultAll = Ld13_15Lists.All(l =>
                    {
                        //テストログの更新
                        State.VmTestStatus.TestLog += $"\n    {l.Name.ToString()}チェック";
                        LPC1768.SendData(l.Cmd);

                        var tm = new GeneralTimer(3000);
                        tm.Start();
                        while (true)
                        {
                            if (tm.FlagTimeout) return false;

                            if (General.cam2.blobs == null) continue;
                            var blobInfo = General.cam2.blobs.Clone();

                            if (blobInfo.Count() != 1) continue;

                            var blob = blobInfo.ToList()[0];

                            var refX = GetRef_XY(l.RefPoint).x;
                            var refY = GetRef_XY(l.RefPoint).y;

                            reX = refX - errPoint < blob.Value.Centroid.X && blob.Value.Centroid.X < refX + errPoint;
                            reY = refY - errPoint < blob.Value.Centroid.Y && blob.Value.Centroid.Y < refY + errPoint;

                            var result = reX && reY;
                            if (result)
                            {
                                State.VmTestStatus.TestLog += "---PASS";
                            }
                            else
                            {
                                State.VmTestStatus.TestLog += "---FAIL";
                                Sleep(1000);//NGの場合、確認できるように少しウェイトを入れる
                            }
                            LPC1768.SendData("Stop");
                            Sleep(250);//
                            return result;
                        }
                    });


                });

            }
            finally
            {
                LPC1768.SendData("Stop");
                await cam2.Stop();
                await Task.Delay(400);

                if (!resultAll)
                {
                    var PointComment = "";
                    var AreaComment = "";
                    if (!reX || !reY)
                        PointComment = "座標NG,";

                    State.VmTestStatus.Spec = "規格値 : ";
                    State.VmTestStatus.MeasValue = "計測値 : " + PointComment + AreaComment;
                }
            }
        }

    }




}




