using System.Windows;
using Microsoft.Practices.Prism.Mvvm;
using System.Linq;

namespace PAP_C_DISP_TESTER
{
    public partial class ErrInfoCnCheck
    {
        public class vm : BindableBase
        {
            private Visibility _VisCN6 = Visibility.Hidden;
            public Visibility VisCN6 { get { return _VisCN6; } set { SetProperty(ref _VisCN6, value); } }

            private Visibility _VisCN7 = Visibility.Hidden;
            public Visibility VisCN7 { get { return _VisCN7; } set { SetProperty(ref _VisCN7, value); } }


            private string _NgList;
            public string NgList { get { return _NgList; } set { SetProperty(ref _NgList, value); } }

        }

        private vm viewmodel;

        public ErrInfoCnCheck()
        {
            InitializeComponent();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            viewmodel = new vm();
            this.DataContext = viewmodel;
            SetErrInfo();
        }
        private void SetErrInfo()
        {
            if (TestItems.TestConnector.ListCnSpec == null) return;
            var NgList = TestItems.TestConnector.ListCnSpec.Where(cn => !cn.result);

            foreach (var cn in NgList)
            {
                switch (cn.name)
                {
                    case TestItems.TestConnector.NAME.CN6:
                        viewmodel.VisCN6 = Visibility.Visible;
                        viewmodel.NgList += "CN6\r\n";
                        break;
                    case TestItems.TestConnector.NAME.CN7:
                        viewmodel.VisCN7 = Visibility.Visible;
                        viewmodel.NgList += "CN7\r\n";
                        break;
                }

            }
        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            State.VmMainWindow.TabIndex = 0;

        }


    }
}
