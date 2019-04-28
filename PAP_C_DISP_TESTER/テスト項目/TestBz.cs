using System.Linq;
using System.Threading.Tasks;
using static PAP_C_DISP_TESTER.General;
using static System.Threading.Thread;
using static PAP_C_DISP_TESTER.UiControl;
using System;

namespace PAP_C_DISP_TESTER.TestItems
{
    public static class TestBz
    {

        public static async Task<bool> CheckBz()
        {
            var result = false;
            var resultFreq = false;
            var resultVol = false;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {
                        SetBz(true);
                        Sleep(3000);
                        GetBuzzData();
                        var vol = Double.Parse(State.VmTestResults.VolLev);
                        var freq = Double.Parse(State.VmTestResults.Freq.Trim('H','z'));
                        resultVol = vol > State.spec.BzVolMin;
                        resultFreq = State.spec.BzFreqMin < freq && freq < State.spec.BzFreqMax;

                        State.VmTestResults.ColBzVol = resultVol ? OffBrush : NgBrush;
                        State.VmTestResults.ColBzFreq = resultFreq ? OffBrush : NgBrush;

                        var re = resultVol && resultFreq;
                        return re;

                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        SetBz(false);
                        Sleep(500);
                    }

                });
            }
            finally
            {
            }
        }















    }
}
