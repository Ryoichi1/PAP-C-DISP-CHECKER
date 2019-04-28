using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAP_C_DISP_TESTER
{
    public class TestSpec
    {
        //検査規格のバージョン
        public string TestSpecVer { get; set; }

        public double BzFreqMax { get; set; }
        public double BzFreqMin { get; set; }
        public double BzVolMax { get; set; }
        public double BzVolMin { get; set; }

    }
}
