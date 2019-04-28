using System.Threading.Tasks;

namespace PAP_C_DISP_TESTER.TestItems
{
    public static class Test5v
    {

        public static async Task<bool> Check5v()
        {
            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {
                        LPC1768.SendData("R,P27");
                        return LPC1768.RecieveData.Contains("L");

                    }
                    catch
                    {
                        return false;
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
