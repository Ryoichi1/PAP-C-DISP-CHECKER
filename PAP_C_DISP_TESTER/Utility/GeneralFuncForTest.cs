using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PAP_C_DISP_TESTER.General;
using static PAP_C_DISP_TESTER.Constants;
using static System.Threading.Thread;

namespace PAP_C_DISP_TESTER
{
    public static class GeneralFuncForTest
    {

        public static List<LdSpec> Ld1Lists;
        public static List<LdSpec> Ld2Lists;
        public static List<LdSpec> Ld3Lists;
        public static List<LdSpec> Ld4Lists;
        public static List<LdSpec> Ld5Lists;
        public static List<LdSpec> Ld6Lists;
        public static List<LdSpec> Ld7Lists;
        public static List<LdSpec> Ld8Lists;
        public static List<LdSpec> Ld9Lists;
        public static List<Ld10_12Spec> Ld10_12Lists;
        public static List<Ld13_15Spec> Ld13_15Lists;


        public class LdSpec
        {
            public LD1_9_NAME Name;
            public SEG_NAME SegName;
            public string Cmd;
            public string GetPoint;
            public string RefPoint;
            public bool Result;
        }
        public class Ld10_12Spec
        {
            public LD10_12_NAME Name;
            public string Cmd;
            public string GetPoint;
            public string RefPoint;
            public bool Result;
        }
        public class Ld13_15Spec
        {
            public LD13_15_NAME Name;
            public string Cmd;
            public string GetPoint;
            public string RefPoint;
            public bool Result;
        }


        public enum LD1_9_NAME
        {
            LD1, LD2, LD3, LD4, LD5, LD6, LD7, LD8, LD9,
        }
        public enum SEG_NAME
        {
            a, b, c, d, e, f, g, h, i, j, k, l, m, n, p,
        }

        public enum LD10_12_NAME
        {
            LD10, LD11, LD12,
        }
        public enum LD13_15_NAME
        {
            LD13, LD14, LD15,
        }


        public static void MakeAllSpec()
        {
            MakeLd1Spec();
            MakeLd2Spec();
            MakeLd3Spec();
            MakeLd4Spec();
            MakeLd5Spec();
            MakeLd6Spec();
            MakeLd7Spec();
            MakeLd8Spec();
            MakeLd9Spec();
            MakeLd10_12Spec();
            MakeLd13_15Spec();
        }


        public static void MakeLd1Spec()
        {
            Ld1Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD1a;
                        refP = State.cam2Prop.LD1a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD1b;
                        refP = State.cam2Prop.LD1b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD1c;
                        refP = State.cam2Prop.LD1c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD1d;
                        refP = State.cam2Prop.LD1d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD1e;
                        refP = State.cam2Prop.LD1e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD1f;
                        refP = State.cam2Prop.LD1f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD1g;
                        refP = State.cam2Prop.LD1g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD1h;
                        refP = State.cam2Prop.LD1h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD1i;
                        refP = State.cam2Prop.LD1i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD1j;
                        refP = State.cam2Prop.LD1j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD1k;
                        refP = State.cam2Prop.LD1k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD1l;
                        refP = State.cam2Prop.LD1l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD1m;
                        refP = State.cam2Prop.LD1m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD1n;
                        refP = State.cam2Prop.LD1n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD1p;
                        refP = State.cam2Prop.LD1dp;
                        break;

                }
                Ld1Lists.Add(new LdSpec() { Name = LD1_9_NAME.LD1, SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }
        public static void MakeLd2Spec()
        {
            Ld2Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD2a;
                        refP = State.cam2Prop.LD2a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD2b;
                        refP = State.cam2Prop.LD2b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD2c;
                        refP = State.cam2Prop.LD2c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD2d;
                        refP = State.cam2Prop.LD2d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD2e;
                        refP = State.cam2Prop.LD2e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD2f;
                        refP = State.cam2Prop.LD2f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD2g;
                        refP = State.cam2Prop.LD2g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD2h;
                        refP = State.cam2Prop.LD2h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD2i;
                        refP = State.cam2Prop.LD2i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD2j;
                        refP = State.cam2Prop.LD2j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD2k;
                        refP = State.cam2Prop.LD2k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD2l;
                        refP = State.cam2Prop.LD2l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD2m;
                        refP = State.cam2Prop.LD2m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD2n;
                        refP = State.cam2Prop.LD2n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD2p;
                        refP = State.cam2Prop.LD2dp;
                        break;

                }
                Ld2Lists.Add(new LdSpec() { Name = LD1_9_NAME.LD2, SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }

        public static void MakeLd3Spec()
        {
            Ld3Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD3a;
                        refP = State.cam2Prop.LD3a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD3b;
                        refP = State.cam2Prop.LD3b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD3c;
                        refP = State.cam2Prop.LD3c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD3d;
                        refP = State.cam2Prop.LD3d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD3e;
                        refP = State.cam2Prop.LD3e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD3f;
                        refP = State.cam2Prop.LD3f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD3g;
                        refP = State.cam2Prop.LD3g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD3h;
                        refP = State.cam2Prop.LD3h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD3i;
                        refP = State.cam2Prop.LD3i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD3j;
                        refP = State.cam2Prop.LD3j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD3k;
                        refP = State.cam2Prop.LD3k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD3l;
                        refP = State.cam2Prop.LD3l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD3m;
                        refP = State.cam2Prop.LD3m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD3n;
                        refP = State.cam2Prop.LD3n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD3p;
                        refP = State.cam2Prop.LD3dp;
                        break;

                }
                Ld3Lists.Add(new LdSpec() {Name = LD1_9_NAME.LD3,  SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }
        public static void MakeLd4Spec()
        {
            Ld4Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD4a;
                        refP = State.cam2Prop.LD4a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD4b;
                        refP = State.cam2Prop.LD4b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD4c;
                        refP = State.cam2Prop.LD4c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD4d;
                        refP = State.cam2Prop.LD4d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD4e;
                        refP = State.cam2Prop.LD4e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD4f;
                        refP = State.cam2Prop.LD4f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD4g;
                        refP = State.cam2Prop.LD4g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD4h;
                        refP = State.cam2Prop.LD4h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD4i;
                        refP = State.cam2Prop.LD4i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD4j;
                        refP = State.cam2Prop.LD4j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD4k;
                        refP = State.cam2Prop.LD4k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD4l;
                        refP = State.cam2Prop.LD4l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD4m;
                        refP = State.cam2Prop.LD4m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD4n;
                        refP = State.cam2Prop.LD4n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD4p;
                        refP = State.cam2Prop.LD4dp;
                        break;

                }
                Ld4Lists.Add(new LdSpec() {Name = LD1_9_NAME.LD4,  SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }
        public static void MakeLd5Spec()
        {
            Ld5Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD5a;
                        refP = State.cam2Prop.LD5a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD5b;
                        refP = State.cam2Prop.LD5b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD5c;
                        refP = State.cam2Prop.LD5c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD5d;
                        refP = State.cam2Prop.LD5d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD5e;
                        refP = State.cam2Prop.LD5e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD5f;
                        refP = State.cam2Prop.LD5f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD5g;
                        refP = State.cam2Prop.LD5g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD5h;
                        refP = State.cam2Prop.LD5h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD5i;
                        refP = State.cam2Prop.LD5i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD5j;
                        refP = State.cam2Prop.LD5j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD5k;
                        refP = State.cam2Prop.LD5k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD5l;
                        refP = State.cam2Prop.LD5l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD5m;
                        refP = State.cam2Prop.LD5m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD5n;
                        refP = State.cam2Prop.LD5n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD5p;
                        refP = State.cam2Prop.LD5dp;
                        break;

                }
                Ld5Lists.Add(new LdSpec() {Name = LD1_9_NAME.LD5,  SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }
        public static void MakeLd6Spec()
        {
            Ld6Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD6a;
                        refP = State.cam2Prop.LD6a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD6b;
                        refP = State.cam2Prop.LD6b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD6c;
                        refP = State.cam2Prop.LD6c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD6d;
                        refP = State.cam2Prop.LD6d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD6e;
                        refP = State.cam2Prop.LD6e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD6f;
                        refP = State.cam2Prop.LD6f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD6g;
                        refP = State.cam2Prop.LD6g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD6h;
                        refP = State.cam2Prop.LD6h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD6i;
                        refP = State.cam2Prop.LD6i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD6j;
                        refP = State.cam2Prop.LD6j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD6k;
                        refP = State.cam2Prop.LD6k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD6l;
                        refP = State.cam2Prop.LD6l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD6m;
                        refP = State.cam2Prop.LD6m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD6n;
                        refP = State.cam2Prop.LD6n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD6p;
                        refP = State.cam2Prop.LD6dp;
                        break;

                }
                Ld6Lists.Add(new LdSpec() {Name = LD1_9_NAME.LD6,  SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }
        public static void MakeLd7Spec()
        {
            Ld7Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD7a;
                        refP = State.cam2Prop.LD7a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD7b;
                        refP = State.cam2Prop.LD7b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD7c;
                        refP = State.cam2Prop.LD7c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD7d;
                        refP = State.cam2Prop.LD7d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD7e;
                        refP = State.cam2Prop.LD7e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD7f;
                        refP = State.cam2Prop.LD7f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD7g;
                        refP = State.cam2Prop.LD7g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD7h;
                        refP = State.cam2Prop.LD7h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD7i;
                        refP = State.cam2Prop.LD7i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD7j;
                        refP = State.cam2Prop.LD7j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD7k;
                        refP = State.cam2Prop.LD7k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD7l;
                        refP = State.cam2Prop.LD7l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD7m;
                        refP = State.cam2Prop.LD7m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD7n;
                        refP = State.cam2Prop.LD7n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD7p;
                        refP = State.cam2Prop.LD7dp;
                        break;

                }
                Ld7Lists.Add(new LdSpec() {Name = LD1_9_NAME.LD7,  SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }
        public static void MakeLd8Spec()
        {
            Ld8Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD8a;
                        refP = State.cam2Prop.LD8a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD8b;
                        refP = State.cam2Prop.LD8b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD8c;
                        refP = State.cam2Prop.LD8c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD8d;
                        refP = State.cam2Prop.LD8d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD8e;
                        refP = State.cam2Prop.LD8e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD8f;
                        refP = State.cam2Prop.LD8f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD8g;
                        refP = State.cam2Prop.LD8g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD8h;
                        refP = State.cam2Prop.LD8h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD8i;
                        refP = State.cam2Prop.LD8i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD8j;
                        refP = State.cam2Prop.LD8j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD8k;
                        refP = State.cam2Prop.LD8k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD8l;
                        refP = State.cam2Prop.LD8l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD8m;
                        refP = State.cam2Prop.LD8m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD8n;
                        refP = State.cam2Prop.LD8n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD8p;
                        refP = State.cam2Prop.LD8dp;
                        break;

                }
                Ld8Lists.Add(new LdSpec() {Name = LD1_9_NAME.LD8,  SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }
        public static void MakeLd9Spec()
        {
            Ld9Lists = new List<LdSpec>();
            foreach (var n in Enum.GetValues(typeof(SEG_NAME)))
            {
                var name = (SEG_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case SEG_NAME.a:
                        cmd = Cmd_LD9a;
                        refP = State.cam2Prop.LD9a;
                        break;
                    case SEG_NAME.b:
                        cmd = Cmd_LD9b;
                        refP = State.cam2Prop.LD9b;
                        break;
                    case SEG_NAME.c:
                        cmd = Cmd_LD9c;
                        refP = State.cam2Prop.LD9c;
                        break;
                    case SEG_NAME.d:
                        cmd = Cmd_LD9d;
                        refP = State.cam2Prop.LD9d;
                        break;
                    case SEG_NAME.e:
                        cmd = Cmd_LD9e;
                        refP = State.cam2Prop.LD9e;
                        break;
                    case SEG_NAME.f:
                        cmd = Cmd_LD9f;
                        refP = State.cam2Prop.LD9f;
                        break;
                    case SEG_NAME.g:
                        cmd = Cmd_LD9g;
                        refP = State.cam2Prop.LD9g;
                        break;
                    case SEG_NAME.h:
                        cmd = Cmd_LD9h;
                        refP = State.cam2Prop.LD9h;
                        break;
                    case SEG_NAME.i:
                        cmd = Cmd_LD9i;
                        refP = State.cam2Prop.LD9i;
                        break;
                    case SEG_NAME.j:
                        cmd = Cmd_LD9j;
                        refP = State.cam2Prop.LD9j;
                        break;
                    case SEG_NAME.k:
                        cmd = Cmd_LD9k;
                        refP = State.cam2Prop.LD9k;
                        break;
                    case SEG_NAME.l:
                        cmd = Cmd_LD9l;
                        refP = State.cam2Prop.LD9l;
                        break;
                    case SEG_NAME.m:
                        cmd = Cmd_LD9m;
                        refP = State.cam2Prop.LD9m;
                        break;
                    case SEG_NAME.n:
                        cmd = Cmd_LD9n;
                        refP = State.cam2Prop.LD9n;
                        break;
                    case SEG_NAME.p:
                        cmd = Cmd_LD9p;
                        refP = State.cam2Prop.LD9dp;
                        break;

                }
                Ld9Lists.Add(new LdSpec() {Name = LD1_9_NAME.LD9,  SegName = name, Cmd = cmd, RefPoint = refP });
            }
        }


        public static void MakeLd10_12Spec()
        {
            Ld10_12Lists = new List<Ld10_12Spec>();
            foreach (var n in Enum.GetValues(typeof(LD10_12_NAME)))
            {
                var name = (LD10_12_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case LD10_12_NAME.LD10:
                        cmd = Cmd_LD10;
                        refP = State.cam1Prop.LD10;
                        break;
                    case LD10_12_NAME.LD11:
                        cmd = Cmd_LD11;
                        refP = State.cam1Prop.LD11;
                        break;
                    case LD10_12_NAME.LD12:
                        cmd = Cmd_LD12;
                        refP = State.cam1Prop.LD12;
                        break;

                }
                Ld10_12Lists.Add(new Ld10_12Spec() { Name = name, Cmd = cmd, RefPoint = refP });
            }
        }

        public static void MakeLd13_15Spec()
        {
            Ld13_15Lists = new List<Ld13_15Spec>();
            foreach (var n in Enum.GetValues(typeof(LD13_15_NAME)))
            {
                var name = (LD13_15_NAME)n;
                var cmd = "";
                var refP = "";
                switch (name)
                {
                    case LD13_15_NAME.LD13:
                        cmd = Cmd_LD13;
                        refP = State.cam2Prop.LD13;
                        break;
                    case LD13_15_NAME.LD14:
                        cmd = Cmd_LD14;
                        refP = State.cam2Prop.LD14;
                        break;
                    case LD13_15_NAME.LD15:
                        cmd = Cmd_LD15;
                        refP = State.cam2Prop.LD15;
                        break;

                }
                Ld13_15Lists.Add(new Ld13_15Spec() { Name = name, Cmd = cmd, RefPoint = refP });
            }
        }





    }
}
