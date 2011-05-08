
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace HudMon
{
    class JsonHudsonFactory : HudsonFactory
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(JsonHudsonFactory));
        private WebClient client = new WebClient();

        const string JSON_API_STRING = "/api/json";
        const string BUILD_PATH = "/build";

        public JsonHudsonFactory(string url)
        {
            Url = url;
        }

        public override Hudson.Job RetrieveJob(string jobName)
        {
            string jsonMessage = client.DownloadString(CreateJobUrl(jobName));

            JsonSerializer jsonSerializer = new JsonSerializer();

            Hudson.Job job = jsonSerializer.Deserialize<Hudson.Job>(new JsonTextReader(new StringReader(jsonMessage)));

            return job;
        }

        public override void BuildJob(Hudson.Job job)
        {
            logger.Debug("Trying to build job: " + job);

            string response = client.DownloadString(job.Url + BUILD_PATH);

            logger.Debug("response" + response);
        }

        public override List<Hudson.SimpleJob> RetrieveJobs()
        {
            Hudson.Hudson hudson = RetrieveHudson();

            if (hudson != null)
            {
                return hudson.Jobs;
            }
            else
            {
                return new List<Hudson.SimpleJob>();
            }
        }

        public override Hudson.Hudson RetrieveHudson()
        {
            WebClient client = new WebClient();
            string jsonMessage = client.DownloadString(CreateBaseUrl());

            JsonSerializer jsonSerializer = new JsonSerializer();

            Hudson.Hudson hudson = jsonSerializer.Deserialize<Hudson.Hudson>(new JsonTextReader(new StringReader(jsonMessage)));

            return hudson;
        }

        override protected string ApiPath { get { return JSON_API_STRING; } }
    }
}
