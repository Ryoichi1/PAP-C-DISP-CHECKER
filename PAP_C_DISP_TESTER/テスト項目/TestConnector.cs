using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAP_C_DISP_TESTER.TestItems
{
    public static class TestConnector
    {
        public enum NAME { CN6, CN7 }

        public static List<CnSpec> ListCnSpec;

        public class CnSpec
        {
            public NAME name;
            public bool result;
        }



        private static void InitList()
        {
            ListCnSpec = new List<CnSpec>();
            foreach (var n in Enum.GetValues(typeof(NAME)))
            {
                ListCnSpec.Add(new CnSpec { name = (NAME)n });
            }
        }


        public static async Task<bool> CheckCn()
        {
            bool result = false;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {
                        InitList();

                        ListCnSpec.ForEach(l =>
                        {
                            var re = false;
                            switch (l.name)
                            {
                                case NAME.CN6:
                                    LPC1768.SendData("R,P24");//CN6
                                    re = LPC1768.RecieveData.Contains("L");
                                    break;
                                case NAME.CN7:
                                    LPC1768.SendData("R,P23");//CN7
                                    re = LPC1768.RecieveData.Contains("L");
                                    break;

                            }

                            l.result = re;
                        });

                        return result = ListCnSpec.All(l => l.result);

                    }
                    catch
                    {
                        return result = false;
                    }

                });
            }
            finally
            {
                if (!result)
                {
                    State.uriOtherInfoPage = new Uri("Page/ErrInfo/ErrInfoCnCheck.xaml", UriKind.Relative);
                    State.VmTestStatus.EnableButtonErrInfo = System.Windows.Visibility.Visible;
                }
            }
        }

    }
}
