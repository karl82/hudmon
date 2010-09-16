using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HudMon
{
    namespace Hudson
    {
        class Build
        {
            public uint Number
            {
                get;
                set;
            }

            public string Url
            {
                get;
                set;
            }

            public override string ToString()
            {
                return Number.ToString();
            }
        }
    }
}
