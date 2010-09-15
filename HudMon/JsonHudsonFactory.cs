
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace HudMon
{
    class JsonHudsonFactory : HudsonFactory
    {
        const string JSON_API_STRING = "/api/json";

        public JsonHudsonFactory(string url)
        {
            Url = url;
        }

        public override Hudson.Job RetrieveJob(string jobName)
        {
            WebClient client = new WebClient();
            string jsonMessage = client.DownloadString(CreateJobUrl(jobName));

            JsonSerializer jsonSerializer = new JsonSerializer();

            Hudson.Job job = jsonSerializer.Deserialize<Hudson.Job>(new JsonTextReader(new StringReader(jsonMessage)));

            return job;
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

        override protected string ApiPath { get { return JSON_API_STRING;} }
    }
}
