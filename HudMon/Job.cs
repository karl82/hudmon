using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HudMon
{
    namespace Hudson
    {
        class Job
        {
            //[JsonProperty]
            public string Description { get; set; }

            //[JsonProperty]
            public string DisplayName { get; set; }

            //[JsonProperty]
            public string Name { get; set; }

            //[JsonProperty]
            public string Url { get; set; }

            //[JsonProperty]
            public bool Buildable { get; set; }

            //[JsonProperty]
            //[JsonArray]
            public List<Build> Builds { get; set; }

            //[JsonProperty]
            public string Color { get; set; }

            public Build FirstBuild { get; set; }

            public List<HealthReport> HealthReport { get; set; }

            public bool InQueue { get; set; }
            public bool KeepDependencies { get; set; }
            public Build LastBuild { get; set; }
            public Build LastCompletedBuild { get; set; }
            public Build LastFailedBuild { get; set; }
            public Build LastSuccessfulBuild { get; set; }
            public Build LastUnstableBuild { get; set; }
            public uint NextBuildNumber { get; set; }
            public List<Module> Modules { get; set; }
        }
    }
}