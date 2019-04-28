using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAP_C_DISP_TESTER
{
    public delegate Task<bool> TestProc();

    public class TestDetail
    {
        public int StepNo;//
        public int Key;//同じカテゴリの試験項目に、同一Keyを設定する Keyは 0 からスタート
        public string Value;//検査項目名
        public TestProc testProc;//テストメソッドへのデリゲート

        public TestDetail(int key, string value, TestProc proc)
        {
            this.Key = key;
            this.Value = value;
            this.testProc = proc;
        }
    }

    public static class State
    {

        //データソース（バインディング用）
        public static ViewModelMainWindow VmMainWindow = new ViewModelMainWindow();
        public static ViewModelTestStatus VmTestStatus = new ViewModelTestStatus();
        public static ViewModelTestResult VmTestResults = new ViewModelTestResult();
        public static Main TestCommand = new Main();
        public static ViewModelCamera1Point VmCam1Point = new ViewModelCamera1Point();
        public static ViewModelCamera2Point VmCam2Point = new ViewModelCamera2Point();

        //パブリックメンバ
        public static Configuration setting { get; set; }
        public static TestSpec spec { get; set; }

        public static Camera1Property cam1Prop { get; set; }
        public static Camera2Property cam2Prop { get; set; }

        public static string MachineName { get; set; }

        public static double CurrentThemeOpacity { get; set; }

        public static string CurrDir { get; set; }

        public static string AssemblyInfo { get; set; }

        public static Uri uriOtherInfoPage { get; set; }


        //リトライ履歴保存用リスト
        public static List<string> RetryLogList = new List<string>();

        public static List<TestDetail> テスト項目;

        static State()
        {
            SetTestProp();
        }


        /// <summary>
        /// 試験項目の設定
        /// </summary>
        static void SetTestProp()
        {
            テスト項目 = new List<TestDetail>()
            {

                new TestDetail(1, "コネクタ実装チェック", TestItems.TestConnector.CheckCn),
                new TestDetail(2, "5Vチェック", TestItems.Test5v.Check5v),
                new TestDetail(3, "スイッチチェック", TestItems.TestSw.CheckSw),
                new TestDetail(4, "ブザーチェック", TestItems.TestBz.CheckBz),
                new TestDetail(5, "U4 SOUT出力チェック", TestItems.TestU4.CheckSOUT),
                new TestDetail(6, "LD10_12チェック", TestItems.TestLed.CheckLD10_12),
                new TestDetail(7, "LD1_9チェック", TestItems.TestLed.CheckLD1_9),
                new TestDetail(8, "LD13_15チェック", TestItems.TestLed.CheckLD13_15),

            };

            int i = 0;
            var oldKey = 0;

            テスト項目.ForEach(t =>
            {
                if (oldKey != t.Key)
                {
                    oldKey = t.Key;
                    i = 0;//初期化
                }

                t.StepNo = t.Key * 10 + i++;

            });
        }


        //個別設定のロード
        public static void LoadConfigData()
        {
            //各種設定ファイルのロード
            setting = Deserialize<Configuration>(Constants.filePath_Configuration);
            spec = Deserialize<TestSpec>(Constants.filePath_TestSpec);
            cam1Prop = Deserialize<Camera1Property>(Constants.filePath_Cam1Prop);
            cam2Prop = Deserialize<Camera2Property>(Constants.filePath_Cam2Prop);


            //コンフィグ設定
            VmMainWindow.ListOperator = setting.作業者リスト;
            VmMainWindow.Theme = setting.PathTheme;
            VmMainWindow.ThemeOpacity = setting.OpacityTheme;

            if (setting.日付 != DateTime.Now.ToString("yyyyMMdd"))
            {
                setting.日付 = DateTime.Now.ToString("yyyyMMdd");
                setting.TodayOkCount = 0;
                setting.TodayNgCount = 0;
            }

            VmTestStatus.OkCount = setting.TodayOkCount.ToString() + "台";
            VmTestStatus.NgCount = setting.TodayNgCount.ToString() + "台";


        }

        public static void LoadTestSpec()//リトライ前にコールすると便利（デバッグ時、試験スペックを調整するときに使用する）
        {
            //TestSpecファイルのロード
            spec = Deserialize<TestSpec>(Constants.filePath_TestSpec);
        }

        //インスタンスをXMLデータに変換する
        public static bool Serialization<T>(T obj, string xmlFilePath)
        {
            try
            {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));
                //書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(xmlFilePath, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, obj);
                //ファイルを閉じる
                sw.Close();

                return true;

            }
            catch
            {
                return false;
            }

        }

        //XMLデータからインスタンスを生成する
        public static T Deserialize<T>(string xmlFilePath)
        {
            System.Xml.Serialization.XmlSerializer serializer;
            using (var sr = new System.IO.StreamReader(xmlFilePath, new System.Text.UTF8Encoding(false)))
            {
                serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sr);
            }
        }

        public static bool Save個別データ()
        {
            try
            {
                //Configファイルの保存
                setting.作業者リスト = VmMainWindow.ListOperator;
                setting.PathTheme = VmMainWindow.Theme;
                setting.OpacityTheme = VmMainWindow.ThemeOpacity;

                Serialization<Configuration>(setting, Constants.filePath_Configuration);

                //Ledプロパティの保存
                Serialization<Camera1Property>(State.cam1Prop, Constants.filePath_Cam1Prop);
                Serialization<Camera2Property>(State.cam2Prop, Constants.filePath_Cam2Prop);

                return true;
            }
            catch
            {
                return false;

            }

        }


        public static void SetCam1Prop()
        {
            if (!Flags.StateCamera1)//カメラのイニシャライズが完了しない状態でWbにアクセスすると例外が発生する
                return;

            General.cam1.Opening = cam1Prop.Opening;
            General.cam1.OpenCnt = cam1Prop.OpenCnt;
            General.cam1.CloseCnt = cam1Prop.CloseCnt;

            General.cam1.Brightness = cam1Prop.Brightness;
            General.cam1.Contrast = cam1Prop.Contrast;
            General.cam1.Hue = cam1Prop.Hue;
            General.cam1.Saturation = cam1Prop.Saturation;
            General.cam1.Sharpness = cam1Prop.Sharpness;
            General.cam1.Gamma = cam1Prop.Gamma;
            General.cam1.Gain = cam1Prop.Gain;
            General.cam1.Exposure = cam1Prop.Exposure;
            General.cam1.Wb = cam1Prop.Whitebalance;
            General.cam1.Theta = cam1Prop.Theta;
            General.cam1.BinLevel = cam1Prop.BinLevel;
        }

        public static void SetCam2Prop()
        {
            if (!Flags.StateCamera2)//カメラのイニシャライズが完了しない状態でWbにアクセスすると例外が発生する
                return;

            General.cam2.Opening = cam2Prop.Opening;
            General.cam2.OpenCnt = cam2Prop.OpenCnt;
            General.cam2.CloseCnt = cam2Prop.CloseCnt;

            General.cam2.Brightness = cam2Prop.Brightness;
            General.cam2.Contrast = cam2Prop.Contrast;
            General.cam2.Hue = cam2Prop.Hue;
            General.cam2.Saturation = cam2Prop.Saturation;
            General.cam2.Sharpness = cam2Prop.Sharpness;
            General.cam2.Gamma = cam2Prop.Gamma;
            General.cam2.Gain = cam2Prop.Gain;
            General.cam2.Exposure = cam2Prop.Exposure;
            General.cam2.Wb = cam2Prop.Whitebalance;
            General.cam2.Theta = cam2Prop.Theta;
            General.cam2.BinLevel = cam2Prop.BinLevel;
        }

        public static void SetCam1Point()
        {
           VmCam1Point.LD10 = cam1Prop.LD10;
           VmCam1Point.LD11 = cam1Prop.LD11;
           VmCam1Point.LD12 = cam1Prop.LD12;
        }

        public static void SetCam2Point()
        {
            //LD1
            VmCam2Point.LD1a = cam2Prop.LD1a;
            VmCam2Point.LD1b = cam2Prop.LD1b;
            VmCam2Point.LD1c = cam2Prop.LD1c;
            VmCam2Point.LD1d = cam2Prop.LD1d;
            VmCam2Point.LD1e = cam2Prop.LD1e;
            VmCam2Point.LD1f = cam2Prop.LD1f;
            VmCam2Point.LD1g = cam2Prop.LD1g;
            VmCam2Point.LD1h = cam2Prop.LD1h;
            VmCam2Point.LD1i = cam2Prop.LD1i;
            VmCam2Point.LD1j = cam2Prop.LD1j;
            VmCam2Point.LD1k = cam2Prop.LD1k;
            VmCam2Point.LD1l = cam2Prop.LD1l;
            VmCam2Point.LD1m = cam2Prop.LD1m;
            VmCam2Point.LD1n = cam2Prop.LD1n;
            VmCam2Point.LD1dp = cam2Prop.LD1dp;

            //LD2
            VmCam2Point.LD2a = cam2Prop.LD2a;
            VmCam2Point.LD2b = cam2Prop.LD2b;
            VmCam2Point.LD2c = cam2Prop.LD2c;
            VmCam2Point.LD2d = cam2Prop.LD2d;
            VmCam2Point.LD2e = cam2Prop.LD2e;
            VmCam2Point.LD2f = cam2Prop.LD2f;
            VmCam2Point.LD2g = cam2Prop.LD2g;
            VmCam2Point.LD2h = cam2Prop.LD2h;
            VmCam2Point.LD2i = cam2Prop.LD2i;
            VmCam2Point.LD2j = cam2Prop.LD2j;
            VmCam2Point.LD2k = cam2Prop.LD2k;
            VmCam2Point.LD2l = cam2Prop.LD2l;
            VmCam2Point.LD2m = cam2Prop.LD2m;
            VmCam2Point.LD2n = cam2Prop.LD2n;
            VmCam2Point.LD2dp = cam2Prop.LD2dp;

            //LD3
            VmCam2Point.LD3a = cam2Prop.LD3a;
            VmCam2Point.LD3b = cam2Prop.LD3b;
            VmCam2Point.LD3c = cam2Prop.LD3c;
            VmCam2Point.LD3d = cam2Prop.LD3d;
            VmCam2Point.LD3e = cam2Prop.LD3e;
            VmCam2Point.LD3f = cam2Prop.LD3f;
            VmCam2Point.LD3g = cam2Prop.LD3g;
            VmCam2Point.LD3h = cam2Prop.LD3h;
            VmCam2Point.LD3i = cam2Prop.LD3i;
            VmCam2Point.LD3j = cam2Prop.LD3j;
            VmCam2Point.LD3k = cam2Prop.LD3k;
            VmCam2Point.LD3l = cam2Prop.LD3l;
            VmCam2Point.LD3m = cam2Prop.LD3m;
            VmCam2Point.LD3n = cam2Prop.LD3n;
            VmCam2Point.LD3dp = cam2Prop.LD3dp;

            //LD4
            VmCam2Point.LD4a = cam2Prop.LD4a;
            VmCam2Point.LD4b = cam2Prop.LD4b;
            VmCam2Point.LD4c = cam2Prop.LD4c;
            VmCam2Point.LD4d = cam2Prop.LD4d;
            VmCam2Point.LD4e = cam2Prop.LD4e;
            VmCam2Point.LD4f = cam2Prop.LD4f;
            VmCam2Point.LD4g = cam2Prop.LD4g;
            VmCam2Point.LD4h = cam2Prop.LD4h;
            VmCam2Point.LD4i = cam2Prop.LD4i;
            VmCam2Point.LD4j = cam2Prop.LD4j;
            VmCam2Point.LD4k = cam2Prop.LD4k;
            VmCam2Point.LD4l = cam2Prop.LD4l;
            VmCam2Point.LD4m = cam2Prop.LD4m;
            VmCam2Point.LD4n = cam2Prop.LD4n;
            VmCam2Point.LD4dp = cam2Prop.LD4dp;

            //LD5
            VmCam2Point.LD5a = cam2Prop.LD5a;
            VmCam2Point.LD5b = cam2Prop.LD5b;
            VmCam2Point.LD5c = cam2Prop.LD5c;
            VmCam2Point.LD5d = cam2Prop.LD5d;
            VmCam2Point.LD5e = cam2Prop.LD5e;
            VmCam2Point.LD5f = cam2Prop.LD5f;
            VmCam2Point.LD5g = cam2Prop.LD5g;
            VmCam2Point.LD5h = cam2Prop.LD5h;
            VmCam2Point.LD5i = cam2Prop.LD5i;
            VmCam2Point.LD5j = cam2Prop.LD5j;
            VmCam2Point.LD5k = cam2Prop.LD5k;
            VmCam2Point.LD5l = cam2Prop.LD5l;
            VmCam2Point.LD5m = cam2Prop.LD5m;
            VmCam2Point.LD5n = cam2Prop.LD5n;
            VmCam2Point.LD5dp = cam2Prop.LD5dp;

            //LD6
            VmCam2Point.LD6a = cam2Prop.LD6a;
            VmCam2Point.LD6b = cam2Prop.LD6b;
            VmCam2Point.LD6c = cam2Prop.LD6c;
            VmCam2Point.LD6d = cam2Prop.LD6d;
            VmCam2Point.LD6e = cam2Prop.LD6e;
            VmCam2Point.LD6f = cam2Prop.LD6f;
            VmCam2Point.LD6g = cam2Prop.LD6g;
            VmCam2Point.LD6h = cam2Prop.LD6h;
            VmCam2Point.LD6i = cam2Prop.LD6i;
            VmCam2Point.LD6j = cam2Prop.LD6j;
            VmCam2Point.LD6k = cam2Prop.LD6k;
            VmCam2Point.LD6l = cam2Prop.LD6l;
            VmCam2Point.LD6m = cam2Prop.LD6m;
            VmCam2Point.LD6n = cam2Prop.LD6n;
            VmCam2Point.LD6dp = cam2Prop.LD6dp;

            //LD7
            VmCam2Point.LD7a = cam2Prop.LD7a;
            VmCam2Point.LD7b = cam2Prop.LD7b;
            VmCam2Point.LD7c = cam2Prop.LD7c;
            VmCam2Point.LD7d = cam2Prop.LD7d;
            VmCam2Point.LD7e = cam2Prop.LD7e;
            VmCam2Point.LD7f = cam2Prop.LD7f;
            VmCam2Point.LD7g = cam2Prop.LD7g;
            VmCam2Point.LD7h = cam2Prop.LD7h;
            VmCam2Point.LD7i = cam2Prop.LD7i;
            VmCam2Point.LD7j = cam2Prop.LD7j;
            VmCam2Point.LD7k = cam2Prop.LD7k;
            VmCam2Point.LD7l = cam2Prop.LD7l;
            VmCam2Point.LD7m = cam2Prop.LD7m;
            VmCam2Point.LD7n = cam2Prop.LD7n;
            VmCam2Point.LD7dp = cam2Prop.LD7dp;

            //LD8
            VmCam2Point.LD8a = cam2Prop.LD8a;
            VmCam2Point.LD8b = cam2Prop.LD8b;
            VmCam2Point.LD8c = cam2Prop.LD8c;
            VmCam2Point.LD8d = cam2Prop.LD8d;
            VmCam2Point.LD8e = cam2Prop.LD8e;
            VmCam2Point.LD8f = cam2Prop.LD8f;
            VmCam2Point.LD8g = cam2Prop.LD8g;
            VmCam2Point.LD8h = cam2Prop.LD8h;
            VmCam2Point.LD8i = cam2Prop.LD8i;
            VmCam2Point.LD8j = cam2Prop.LD8j;
            VmCam2Point.LD8k = cam2Prop.LD8k;
            VmCam2Point.LD8l = cam2Prop.LD8l;
            VmCam2Point.LD8m = cam2Prop.LD8m;
            VmCam2Point.LD8n = cam2Prop.LD8n;
            VmCam2Point.LD8dp = cam2Prop.LD8dp;

            //LD9
            VmCam2Point.LD9a = cam2Prop.LD9a;
            VmCam2Point.LD9b = cam2Prop.LD9b;
            VmCam2Point.LD9c = cam2Prop.LD9c;
            VmCam2Point.LD9d = cam2Prop.LD9d;
            VmCam2Point.LD9e = cam2Prop.LD9e;
            VmCam2Point.LD9f = cam2Prop.LD9f;
            VmCam2Point.LD9g = cam2Prop.LD9g;
            VmCam2Point.LD9h = cam2Prop.LD9h;
            VmCam2Point.LD9i = cam2Prop.LD9i;
            VmCam2Point.LD9j = cam2Prop.LD9j;
            VmCam2Point.LD9k = cam2Prop.LD9k;
            VmCam2Point.LD9l = cam2Prop.LD9l;
            VmCam2Point.LD9m = cam2Prop.LD9m;
            VmCam2Point.LD9n = cam2Prop.LD9n;
            VmCam2Point.LD9dp = cam2Prop.LD9dp;

            VmCam2Point.LD13 = cam2Prop.LD13;
            VmCam2Point.LD14 = cam2Prop.LD14;
            VmCam2Point.LD15 = cam2Prop.LD15;
        }

    }

}
