using System.Collections.Generic;

namespace HudMon
{
    namespace Hudson
    {
        public class Hudson
        {
            public string NodeDescription { get; set; }
            public string NodeName { get; set; }
            public List<SimpleJob> Jobs { get; set; }
        }
    }
}
