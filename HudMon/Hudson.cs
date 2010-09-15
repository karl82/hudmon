using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HudMon
{
    namespace Hudson
    {
        class Hudson
        {
            public string NodeDescription { get; set; }
            public string NodeName { get; set; }
            public List<SimpleJob> Jobs { get; set; }
        }
    }
}
