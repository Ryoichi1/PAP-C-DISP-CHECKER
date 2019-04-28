using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PAP_C_DISP_TESTER.General;
using static PAP_C_DISP_TESTER.UiControl;
using static System.Threading.Thread;

namespace PAP_C_DISP_TESTER.TestItems
{
    public static class TestSw
    {
        public enum NAME { KS1, KS2, KS3, KS4, KS5, KS6, KS7, }

        public static List<SwSpec> ListSwSpec;

        public class SwSpec
        {
            public NAME name;
            public bool reFromCn6;
            public bool reFromCn7;
        }


        private static void InitList()
        {
            ListSwSpec = new List<SwSpec>();
            foreach (var n in Enum.GetValues(typeof(NAME)))
            {
                ListSwSpec.Add(new SwSpec { name = (NAME)n });
            }
        }

        private static void SetVmInOn(NAME name, bool Cn6, bool Cn7)
        {
            switch (name)
            {
                case NAME.KS1:
                    State.VmTestResults.ColKs1InCn6 = Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs1InCn7 = Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS2:
                    State.VmTestResults.ColKs2InCn6 = Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs2InCn7 = Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS3:
                    State.VmTestResults.ColKs3InCn6 = Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs3InCn7 = Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS4:
                    State.VmTestResults.ColKs4InCn6 = Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs4InCn7 = Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS5:
                    State.VmTestResults.ColKs5InCn6 = Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs5InCn7 = Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS6:
                    State.VmTestResults.ColKs6InCn6 = Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs6InCn7 = Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS7:
                    State.VmTestResults.ColKs7InCn6 = Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs7InCn7 = Cn7 ? OnBrush : OffBrush;
                    break;
            }
        }
        private static void SetVmInOff(NAME name, bool Cn6, bool Cn7)
        {
            switch (name)
            {
                case NAME.KS1:
                    State.VmTestResults.ColKs1InCn6 = !Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs1InCn7 = !Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS2:
                    State.VmTestResults.ColKs2InCn6 = !Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs2InCn7 = !Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS3:
                    State.VmTestResults.ColKs3InCn6 = !Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs3InCn7 = !Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS4:
                    State.VmTestResults.ColKs4InCn6 = !Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs4InCn7 = !Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS5:
                    State.VmTestResults.ColKs5InCn6 = !Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs5InCn7 = !Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS6:
                    State.VmTestResults.ColKs6InCn6 = !Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs6InCn7 = !Cn7 ? OnBrush : OffBrush;
                    break;
                case NAME.KS7:
                    State.VmTestResults.ColKs7InCn6 = !Cn6 ? OnBrush : OffBrush;
                    State.VmTestResults.ColKs7InCn7 = !Cn7 ? OnBrush : OffBrush;
                    break;
            }
        }
        private static void SetVmEx(NAME name)
        {
            switch (name)
            {
                case NAME.KS1:
                    State.VmTestResults.ColKs1Ex = OnBrush;
                    break;
                case NAME.KS2:
                    State.VmTestResults.ColKs2Ex = OnBrush;
                    break;
                case NAME.KS3:
                    State.VmTestResults.ColKs3Ex = OnBrush;
                    break;
                case NAME.KS4:
                    State.VmTestResults.ColKs4Ex = OnBrush;
                    break;
                case NAME.KS5:
                    State.VmTestResults.ColKs5Ex = OnBrush;
                    break;
                case NAME.KS6:
                    State.VmTestResults.ColKs6Ex = OnBrush;
                    break;
                case NAME.KS7:
                    State.VmTestResults.ColKs7Ex = OnBrush;
                    break;
            }
        }
        private static void SetVmExOff()
        {
            State.VmTestResults.ColKs1Ex = OffBrush;
            State.VmTestResults.ColKs2Ex = OffBrush;
            State.VmTestResults.ColKs3Ex = OffBrush;
            State.VmTestResults.ColKs4Ex = OffBrush;
            State.VmTestResults.ColKs5Ex = OffBrush;
            State.VmTestResults.ColKs6Ex = OffBrush;
            State.VmTestResults.ColKs7Ex = OffBrush;
        }

        public static async Task<bool> CheckSw()
        {
            bool result = false;
            Flags.AddDecision = false;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {
                        InitList();

                        result = ListSwSpec.All(l =>
                        {
                            //テストログの更新
                            State.VmTestStatus.TestLog += $"\n    {l.name.ToString()}ONチェック";
                            SetVmEx(l.name);
                            switch (l.name)
                            {
                                case NAME.KS1:
                                    LPC1768.SendData("SetKs1");
                                    PushSw1(true);
                                    CheckInputOn(l);
                                    PushSw1(false);
                                    break;
                                case NAME.KS2:
                                    LPC1768.SendData("SetKs2");
                                    PushSw2(true);
                                    CheckInputOn(l);
                                    PushSw2(false);
                                    break;
                                case NAME.KS3:
                                    LPC1768.SendData("SetKs3");
                                    PushSw3(true);
                                    CheckInputOn(l);
                                    PushSw3(false);
                                    break;
                                case NAME.KS4:
                                    LPC1768.SendData("SetKs4");
                                    PushSw4(true);
                                    CheckInputOn(l);
                                    PushSw4(false);
                                    break;
                                case NAME.KS5:
                                    LPC1768.SendData("SetKs5");
                                    PushSw5(true);
                                    CheckInputOn(l);
                                    PushSw5(false);
                                    break;
                                case NAME.KS6:
                                    LPC1768.SendData("SetKs6");
                                    PushSw6(true);
                                    CheckInputOn(l);
                                    PushSw6(false);
                                    break;
                                case NAME.KS7:
                                    LPC1768.SendData("SetKs7");
                                    PushSw7(true);
                                    CheckInputOn(l);
                                    PushSw7(false);
                                    break;
                            }

                            var re = l.reFromCn6 && l.reFromCn7;
                            if (re)
                                State.VmTestStatus.TestLog += "---PASS";
                            else
                                return false;

                            //テストログの更新
                            State.VmTestStatus.TestLog += $"\n    {l.name.ToString()}OFFチェック";
                            SetVmExOff();
                            CheckInputOff(l);

                            re = l.reFromCn6 && l.reFromCn7;
                            if (re)
                                State.VmTestStatus.TestLog += "---PASS";

                            return re;

                            //ローカル関数
                            void CheckInputOn(SwSpec s)
                            {
                                Sleep(300);
                                LPC1768.SendData("R,P26");
                                s.reFromCn6 = LPC1768.RecieveData.Contains("L");
                                LPC1768.SendData("R,P25");
                                s.reFromCn7 = LPC1768.RecieveData.Contains("L");
                                SetVmInOn(s.name, s.reFromCn6, s.reFromCn7);
                            }

                            void CheckInputOff(SwSpec s)
                            {
                                Sleep(100);
                                LPC1768.SendData("R,P26");
                                s.reFromCn6 = LPC1768.RecieveData.Contains("H");
                                LPC1768.SendData("R,P25");
                                s.reFromCn7 = LPC1768.RecieveData.Contains("H");
                                SetVmInOff(s.name, s.reFromCn6, s.reFromCn7);
                                Sleep(400);
                            }
                        });

                        return result;

                    }
                    catch
                    {
                        return result = false;
                    }

                });
            }
            finally
            {
            }
        }















    }
}
