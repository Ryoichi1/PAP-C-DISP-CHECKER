using Microsoft.Practices.Prism.Mvvm;

namespace PAP_C_DISP_TESTER
{
    public class ViewModelCamera1Point : BindableBase
    {
        private string _BlobPoint;
        public string BlobPoint { get { return _BlobPoint; } set { SetProperty(ref _BlobPoint, value); } }

        private string _LD10;
        public string LD10 { get { return _LD10; } set { SetProperty(ref _LD10, value); } }

        private string _LD11;
        public string LD11 { get { return _LD11; } set { SetProperty(ref _LD11, value); } }

        private string _LD12;
        public string LD12 { get { return _LD12; } set { SetProperty(ref _LD12, value); } }


    }
}
