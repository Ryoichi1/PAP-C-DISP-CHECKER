

namespace PAP_C_DISP_TESTER
{
    public class Camera1Property
    {
        public int BinLevel { get; set; }
        public bool Opening { get; set; }//オープニング処理 or クロージング処理
        public int OpenCnt { get; set; }//クロージング処理時の拡張回数
        public int CloseCnt { get; set; }//クロージング処理時の収縮回数

        //カメラプロパティ
        public int CamNumber { get; set; }
        public double Brightness { get; set; }
        public double Contrast { get; set; }
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Sharpness { get; set; }
        public double Gamma { get; set; }
        public double Gain { get; set; }
        public double Exposure { get; set; }
        public int Whitebalance { get; set; }
        public double Theta { get; set; }

        //LEDの座標
        public string LD10 { get; set; }
        public string LD11 { get; set; }
        public string LD12 { get; set; }

    }
}
