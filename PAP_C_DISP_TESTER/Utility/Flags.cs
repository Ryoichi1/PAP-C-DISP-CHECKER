using System.Windows.Media;

namespace PAP_C_DISP_TESTER
{
    public static class Flags
    {
        static SolidColorBrush OnBrush = new SolidColorBrush();
        static SolidColorBrush OffBrush = new SolidColorBrush();
        static SolidColorBrush NgBrush = new SolidColorBrush();

        public static bool DoGetDeviceName { get; set; }
        public static bool OtherPage { get; set; }

        //試験開始時に初期化が必要なフラグ
        public static bool StopInit周辺機器 { get; set; }
        public static bool Initializing周辺機器 { get; set; }
        public static bool Testing { get; set; }
        public static bool PowOn { get; set; }//メイン電源ON/OFF
        public static bool ShowErrInfo { get; set; }
        public static bool AddDecision { get; set; }
        public static bool EnableTestStart { get; set; }

        //タブレットへの通知に使用する*********************
        public static bool DoMeasureTime { get; set; }
        public static bool ShowDecision { get; set; }
        public static bool TestDecision { get; set; }
        //***********************************************

        static Flags()
        {
            OffBrush.Color = Colors.Transparent;

            OnBrush.Color = Colors.DodgerBlue;
            OnBrush.Opacity = Constants.PanelOpacity;

            NgBrush.Color = Colors.Magenta;
            NgBrush.Opacity = Constants.PanelOpacity;

        }




        //周辺機器のステータス

        private static bool _StateMbed;
        public static bool StateMbed
        {
            get { return _StateMbed; }
            set
            {
                _StateMbed = value;
                State.VmTestStatus.ColorMbed = value ? OnBrush : NgBrush;
            }
        }


        private static bool _StateMic;
        public static bool StateMic
        {
            get { return _StateMic; }
            set
            {
                _StateMic = value;
                State.VmTestStatus.ColorMic = value ? OnBrush : NgBrush;
            }
        }

        private static bool _StateCamera1;
        public static bool StateCamera1
        {
            get { return _StateCamera1; }
            set
            {
                _StateCamera1 = value;
                State.VmTestStatus.ColorCamera1 = value ? OnBrush : NgBrush;
            }
        }

        private static bool _StateCamera2;
        public static bool StateCamera2
        {
            get { return _StateCamera2; }
            set
            {
                _StateCamera2 = value;
                State.VmTestStatus.ColorCamera2 = value ? OnBrush : NgBrush;
            }
        }


        private static bool _IsPressClose;
        public static bool IsPressClose
        {
            get { return _IsPressClose; }

            set
            {
                _IsPressClose = value;

            }
        }


        private static bool _Retry;
        public static bool Retry
        {
            get { return _Retry; }
            set
            {
                _Retry = value;
                State.VmTestStatus.RetryOpacity = value ? 0.8 : 0.1;
            }
        }



        public static bool AllOk周辺機器接続 { get; set; }

        //フラグ
        private static bool _SetOperator;
        public static bool SetOperator
        {
            get { return _SetOperator; }
            set
            {
                _SetOperator = value;
                if (value)
                {
                    if (State.VmMainWindow.Operator == "畔上")
                    {
                        State.VmTestStatus.UnitTestEnable = true;
                        State.VmMainWindow.Opecode = "1-11-1111-111";
                        State.VmMainWindow.Model = "RBC250A100/C";
                    }
                    else
                    {
                        //一般作業者には、単体テスト選択できないようにする
                        State.VmTestStatus.UnitTestEnable = false;
                        State.VmTestStatus.CheckUnitTest = false;
                        State.VmTestStatus.CbUnitTestIndex = -1;
                    }


                    if (SetOpecode)
                        return;

                    //工番入力許可する
                    State.VmMainWindow.ReadOnlyOpecode = false;
                }
                else
                {
                    State.VmMainWindow.Operator = "";
                    State.VmTestStatus.UnitTestEnable = false;
                    State.VmTestStatus.CheckUnitTest = false;
                    State.VmTestStatus.CbUnitTestIndex = -1;

                    State.VmMainWindow.ReadOnlyOpecode = true;//工番 入力不可とする
                    State.VmMainWindow.ReadOnlyModel = true;//型番 入力不可とする

                    State.VmMainWindow.SelectIndexOperatorCb = -1;
                }
            }
        }


        private static bool _SetOpecode;
        public static bool SetOpecode
        {
            get { return _SetOpecode; }

            set
            {
                _SetOpecode = value;

                if (value)
                {
                    State.VmMainWindow.ReadOnlyOpecode = true;//工番が確定したので、編集不可とする
                    State.VmMainWindow.ReadOnlyModel = false;//型番入力を許可する
                }
                else
                {
                    State.VmMainWindow.ReadOnlyOpecode = false;
                    State.VmMainWindow.Opecode = "";
                }

            }
        }

        private static bool _SetModel;
        public static bool SetModel
        {
            get { return _SetModel; }

            set
            {
                _SetModel = value;

                if (value)
                {
                    State.VmMainWindow.ReadOnlyModel = true;
                }
                else
                {
                    State.VmMainWindow.ReadOnlyModel = false;
                    State.VmMainWindow.Model = "";
                }

            }
        }



    }
}
