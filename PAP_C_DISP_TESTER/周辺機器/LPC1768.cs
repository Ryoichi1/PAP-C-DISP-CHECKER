using System.IO.Ports;
using System.Linq;

namespace PAP_C_DISP_TESTER
{
    public static class LPC1768
    {
        const string ID_LPC1768 = "PAP-C-DISP_V1.0";
        private const string ComName = "mbed Serial Port ";
        //変数の宣言（インスタンスメンバーになります）
        private static SerialPort port;
        public static string RecieveData { get; set; }//LPC1768から受信した生データ


        static LPC1768()
        {
            port = new SerialPort();
        }


        public static bool Init()
        {
            var result = false;
            try
            {
                var comNum = FindSerialPort.GetComNo(ComName);
                if (comNum.Count() != 1) return false;

                if (!port.IsOpen)
                {
                    //Agilent34401A用のシリアルポート設定
                    port.PortName = comNum[0]; //この時点で既にポートが開いている場合COM番号は設定できず例外となる（イニシャライズは１回のみ有効）
                    port.BaudRate = 115200;
                    port.DataBits = 8;
                    port.Parity = System.IO.Ports.Parity.None;
                    port.StopBits = System.IO.Ports.StopBits.One;
                    port.NewLine = ("\r\n");
                    port.Open();
                }

                //クエリ送信
                if (!SendData("*IDN?", setLog:false)) return false;
                return result = RecieveData.Contains(ID_LPC1768);
            }
            catch
            {
                return result = false;
            }
            finally
            {
                if (!result)
                {
                    ClosePort();
                }
            }
        }

        public static bool SendData(string cmd, int Wait = 1000, bool setLog = true)
        {
            //送信処理
            try
            {
                ClearBuff();//受信バッファのクリア
                port.WriteLine(cmd);// \r\n は自動的に付加されます

                return ReadRecieveData();
            }
            catch
            {
                return false;
            }
        }

        public static bool ReadRecieveData(int time = 1000, bool setLog = true)
        {

            RecieveData = "";//念のため初期化
            port.ReadTimeout = time;
            try
            {
                RecieveData = port.ReadTo("\r\n");
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// データ受信（引数の文字列が含まれるか判定も行う）
        /// </summary>
        /// <param name="time"></param>
        /// <param name="EndCode"></param>
        /// <returns></returns>
        public static bool ReadRecieveData(int time, string EndCode, bool setLog = true)
        {

            RecieveData = "";//念のため初期化
            port.ReadTimeout = time;
            try
            {
                RecieveData = port.ReadTo(EndCode);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool ClosePort()
        {
            try
            {
                //ポートが開いているかどうかの判定
                if (port.IsOpen)
                {
                    SendData("ResetIo");//製品を初期化して終了
                    port.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void ClearBuff()
        {
            if (port.IsOpen)
                port.DiscardInBuffer();
        }




















    }

}

