using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Media;


namespace PAP_C_DISP_TESTER
{
    public class ViewModelTestResult : BindableBase
    {


        //マイク
        private string _Freq;
        public string Freq
        {
            get { return _Freq; }
            set { this.SetProperty(ref this._Freq, value); }
        }

        private string _VolLev;
        public string VolLev
        {
            get { return _VolLev; }
            set { this.SetProperty(ref this._VolLev, value); }
        }

        private Brush _ColBzVol;
        public Brush ColBzVol { get { return _ColBzVol; } set { SetProperty(ref _ColBzVol, value); } }

        private Brush _ColBzFreq;
        public Brush ColBzFreq { get { return _ColBzFreq; } set { SetProperty(ref _ColBzFreq, value); } }


        //160℃
        private string _Temp100;
        public string Temp100 { get { return _Temp100; } set { SetProperty(ref _Temp100, value); } }

        private Brush _ColTemp100;
        public Brush ColTemp100 { get { return _ColTemp100; } set { SetProperty(ref _ColTemp100, value); } }



        private Brush _ColKs1Ex;
        public Brush ColKs1Ex { get { return _ColKs1Ex; } set { SetProperty(ref _ColKs1Ex, value); } }

        private Brush _ColKs2Ex;
        public Brush ColKs2Ex { get { return _ColKs2Ex; } set { SetProperty(ref _ColKs2Ex, value); } }

        private Brush _ColKs3Ex;
        public Brush ColKs3Ex { get { return _ColKs3Ex; } set { SetProperty(ref _ColKs3Ex, value); } }

        private Brush _ColKs4Ex;
        public Brush ColKs4Ex { get { return _ColKs4Ex; } set { SetProperty(ref _ColKs4Ex, value); } }

        private Brush _ColKs5Ex;
        public Brush ColKs5Ex { get { return _ColKs5Ex; } set { SetProperty(ref _ColKs5Ex, value); } }

        private Brush _ColKs6Ex;
        public Brush ColKs6Ex { get { return _ColKs6Ex; } set { SetProperty(ref _ColKs6Ex, value); } }

        private Brush _ColKs7Ex;
        public Brush ColKs7Ex { get { return _ColKs7Ex; } set { SetProperty(ref _ColKs7Ex, value); } }

        //KS1-7 from Cn6
        private Brush _ColKs1InCn6;
        public Brush ColKs1InCn6 { get { return _ColKs1InCn6; } set { SetProperty(ref _ColKs1InCn6, value); } }

        private Brush _ColKs2InCn6;
        public Brush ColKs2InCn6 { get { return _ColKs2InCn6; } set { SetProperty(ref _ColKs2InCn6, value); } }

        private Brush _ColKs3InCn6;
        public Brush ColKs3InCn6 { get { return _ColKs3InCn6; } set { SetProperty(ref _ColKs3InCn6, value); } }

        private Brush _ColKs4InCn6;
        public Brush ColKs4InCn6 { get { return _ColKs4InCn6; } set { SetProperty(ref _ColKs4InCn6, value); } }

        private Brush _ColKs5InCn6;
        public Brush ColKs5InCn6 { get { return _ColKs5InCn6; } set { SetProperty(ref _ColKs5InCn6, value); } }

        private Brush _ColKs6InCn6;
        public Brush ColKs6InCn6 { get { return _ColKs6InCn6; } set { SetProperty(ref _ColKs6InCn6, value); } }

        private Brush _ColKs7InCn6;
        public Brush ColKs7InCn6 { get { return _ColKs7InCn6; } set { SetProperty(ref _ColKs7InCn6, value); } }

        //KS1-7 from Cn7
        private Brush _ColKs1InCn7;
        public Brush ColKs1InCn7 { get { return _ColKs1InCn7; } set { SetProperty(ref _ColKs1InCn7, value); } }

        private Brush _ColKs2InCn7;
        public Brush ColKs2InCn7 { get { return _ColKs2InCn7; } set { SetProperty(ref _ColKs2InCn7, value); } }

        private Brush _ColKs3InCn7;
        public Brush ColKs3InCn7 { get { return _ColKs3InCn7; } set { SetProperty(ref _ColKs3InCn7, value); } }

        private Brush _ColKs4InCn7;
        public Brush ColKs4InCn7 { get { return _ColKs4InCn7; } set { SetProperty(ref _ColKs4InCn7, value); } }

        private Brush _ColKs5InCn7;
        public Brush ColKs5InCn7 { get { return _ColKs5InCn7; } set { SetProperty(ref _ColKs5InCn7, value); } }

        private Brush _ColKs6InCn7;
        public Brush ColKs6InCn7 { get { return _ColKs6InCn7; } set { SetProperty(ref _ColKs6InCn7, value); } }

        private Brush _ColKs7InCn7;
        public Brush ColKs7InCn7 { get { return _ColKs7InCn7; } set { SetProperty(ref _ColKs7InCn7, value); } }

    }
}







