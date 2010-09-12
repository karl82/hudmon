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
        public string CreateJobUrl(string jobName)
        {
            return Url + "/job/" + jobName + ApiPath;
        }
        protected abstract string ApiPath { get; }
    }
}
