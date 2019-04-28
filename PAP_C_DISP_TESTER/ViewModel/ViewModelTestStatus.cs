using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;


namespace PAP_C_DISP_TESTER
{
    public class ViewModelTestStatus : BindableBase
    {
        //テストログ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        private string _TestLog;
        public string TestLog
        {
            get { return _TestLog; }
            set { SetProperty(ref _TestLog, value); }
        }


        //判定表示、進捗表示プログレスリング■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        //判定表示 可視性
        private Visibility _DecisionVisibility;
        public Visibility DecisionVisibility
        {
            get { return _DecisionVisibility; }
            set { SetProperty(ref _DecisionVisibility, value); }
        }
        //判定表示　PASS or FAIL
        private string _Decision;
        public string Decision
        {
            get { return _Decision; }
            set { SetProperty(ref _Decision, value); }
        }
        //判定表示の色
        private Brush _ColorDecision;
        public Brush ColorDecision
        {
            get { return _ColorDecision; }
            set { SetProperty(ref _ColorDecision, value); }
        }
        //判定表示の効果
        private DropShadowEffect _EffectDecision;
        public DropShadowEffect EffectDecision
        {
            get { return _EffectDecision; }
            set { SetProperty(ref _EffectDecision, value); }
        }



        //エラー詳細 可視性
        private Visibility _ErrInfoVisibility;
        public Visibility ErrInfoVisibility
        {
            get { return _ErrInfoVisibility; }
            set { SetProperty(ref _ErrInfoVisibility, value); }
        }

        //エラー詳細表示ボタンの可視切り替え
        private Visibility _EnableButtonErrInfo = Visibility.Hidden;
        public Visibility EnableButtonErrInfo
        {
            get { return _EnableButtonErrInfo; }

            set
            {
                SetProperty(ref _EnableButtonErrInfo, value);
            }
        }

        //FAIL判定時に表示するエラー情報
        private string _FailInfo;
        public string FailInfo
        {
            get { return _FailInfo; }
            set { SetProperty(ref _FailInfo, value); }
        }

        //FAIL判定時に表示する試験スペック
        private string _Spec;
        public string Spec
        {
            get { return _Spec; }
            set { SetProperty(ref _Spec, value); }
        }

        //FAIL判定時に表示する計測値
        private string _MeasValue;
        public string MeasValue
        {
            get { return _MeasValue; }
            set { SetProperty(ref _MeasValue, value); }
        }

        //プログレスリングの可視性
        private Visibility _RingVisibility;
        public Visibility RingVisibility
        {
            get { return _RingVisibility; }
            set { SetProperty(ref _RingVisibility, value); }
        }

        //プログレスリングのEndAngle
        private int _進捗度;
        public int 進捗度
        {
            get { return _進捗度; }
            set { SetProperty(ref _進捗度, value); }
        }

        //テスト時間
        private string _TestTime;
        public string TestTime
        {
            get { return _TestTime; }
            set { SetProperty(ref _TestTime, value); }
        }


        private string _OkCount;
        public string OkCount
        {
            get { return _OkCount; }
            set { SetProperty(ref _OkCount, value); }
        }

        private string _NgCount;
        public string NgCount
        {
            get { return _NgCount; }
            set { SetProperty(ref _NgCount, value); }
        }

        private double _RetryOpacity = 0.1;
        public double RetryOpacity
        {
            get { return _RetryOpacity; }
            set { SetProperty(ref _RetryOpacity, value); }
        }


        //テストオプション（FW書き込みパス、単体試験選択）■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        //試験中はテスト設定パネルを操作できないようにするためのプロパティ
        private bool _TestSettingEnable = true;
        public bool TestSettingEnable
        {

            get { return _TestSettingEnable; }
            set { SetProperty(ref _TestSettingEnable, value); }
        }

        //テストFW書き込みパス チェックボックスがチェックされているかどうかの判定
        private bool? _CheckWriteTestFwPass = false;
        public bool? CheckWriteTestFwPass
        {
            get { return _CheckWriteTestFwPass; }
            set { SetProperty(ref _CheckWriteTestFwPass, value); }
        }



        //単体試験チェックボックスとコンボボックスの可視切り替え
        //これ重要！！！ 
        //EnableUnitTestをhiddenにした時点で、CheckUnitTestは必ずfalseになる
        //畔上以外の作業者を選択時は、EnableUnitTestがhiddenになるため、
        //絶対に一項目試験はできなくなり、通しで試験をするようになる

        private bool _UnitTestEnable;
        public bool UnitTestEnable
        {
            get { return _UnitTestEnable; }

            set
            {
                SetProperty(ref _UnitTestEnable, value);
            }
        }

        //単体試験チェックボックスがチェックされているかどうかの判定
        private bool? _CheckUnitTest = false;
        public bool? CheckUnitTest
        {
            get { return _CheckUnitTest; }
            set { SetProperty(ref _CheckUnitTest, value); }
        }

        //単体試験コンボボックスのアイテムソース
        private List<string> _UnitTestItems;
        public List<string> UnitTestItems
        {

            get { return _UnitTestItems; }
            set { SetProperty(ref _UnitTestItems, value); }

        }

        //単体試験コンボボックスの選択されたアイテム
        private string _UnitTestName;
        public string UnitTestName
        {

            get { return _UnitTestName; }
            set { SetProperty(ref _UnitTestName, value); }

        }

        //単体試験コンボボックスの選択されたアイテム
        private int _CbUnitTestIndex = -1;
        public int CbUnitTestIndex
        {

            get { return _CbUnitTestIndex; }
            set { SetProperty(ref _CbUnitTestIndex, value); }

        }

        //作業者へのメッセージ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }

        //デートコード■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        private string _Dc;
        public string Dc
        {
            get { return _Dc; }
            set { SetProperty(ref _Dc, value); }
        }


        //周辺機器ステータス表示部■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        private Brush _ColorMbed;
        public Brush ColorMbed
        {
            get { return _ColorMbed; }
            set { SetProperty(ref _ColorMbed, value); }
        }


        private Brush _ColorCamera1;
        public Brush ColorCamera1
        {
            get { return _ColorCamera1; }
            set { SetProperty(ref _ColorCamera1, value); }
        }

        private Brush _ColorCamera2;
        public Brush ColorCamera2
        {
            get { return _ColorCamera2; }
            set { SetProperty(ref _ColorCamera2, value); }
        }

        private Brush _ColorMic;
        public Brush ColorMic
        {
            get { return _ColorMic; }
            set { SetProperty(ref _ColorMic, value); }
        }




    }
}
