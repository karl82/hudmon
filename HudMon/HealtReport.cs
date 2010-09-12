using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HudMon
{
    namespace Hudson
    {
        class HealthReport
        {
            public string Description { get; set; }
            public string IconUrl { get; set; }
            public uint Score { get; set; }
        }
    }
}
