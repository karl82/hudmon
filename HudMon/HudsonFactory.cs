using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HudMon
{
    abstract class HudsonFactory
    {
        public string Url { get; protected set; }
        public abstract Hudson.Job RetrieveJob(string jobName);
        public abstract List<Hudson.SimpleJob> RetrieveJobs();
        public abstract Hudson.Hudson RetrieveHudson();

        public string CreateJobUrl(string jobName)
        {
            return Url + "/job/" + jobName + ApiPath;
        }

        public string CreateBaseUrl()
        {
            return Url + ApiPath;
        }

        protected abstract string ApiPath { get; }
    }
}
