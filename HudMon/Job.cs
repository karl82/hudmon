using System.Collections.Generic;

namespace HudMon
{
    namespace Hudson
    {
        /// <summary>
        /// Class representing Hudson's job
        /// </summary>
        public class Job
        {
            public string Description { get; set; }

            public string DisplayName { get; set; }

            public string Name { get; set; }

            public string Url { get; set; }

            public bool Buildable { get; set; }

            public List<Build> Builds { get; set; }

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

            public override string ToString()
            {
                return Url.ToString();
            }
        }

        /// <summary>
        /// Represents simple job with it's name and url
        /// </summary>
        public class SimpleJob
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}