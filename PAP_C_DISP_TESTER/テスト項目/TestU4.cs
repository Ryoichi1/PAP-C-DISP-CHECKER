using System.Linq;
using System.Threading.Tasks;
using static PAP_C_DISP_TESTER.General;
using static System.Threading.Thread;
using static PAP_C_DISP_TESTER.UiControl;

namespace PAP_C_DISP_TESTER.TestItems
{
    public static class TestU4
    {

        public static async Task<bool> CheckSOUT()
        {
            var result = false;
            var resultOn = false;
            var resultOff = false;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {
                        LPC1768.SendData("EX1");
                        LPC1768.SendData("R,P28");
                        resultOn = LPC1768.RecieveData.Contains("L");
                        Sleep(300);
                        LPC1768.SendData("EX0");
                        LPC1768.SendData("R,P28");
                        resultOff = LPC1768.RecieveData.Contains("H");

                        return result = resultOn && resultOff;

                    }
                    catch
                    {
                        return result = false;
                    }
                    finally
                    {
                    }

                });
            }
            finally
            {
            }
        }















    }
}
