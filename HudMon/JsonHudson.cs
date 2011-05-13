
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace HudMon
{
    class JsonHudson : BaseHudson
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(JsonHudson));
        private WebClient client = new WebClient();

        const string JSON_API_STRING = "/api/json";
        const string BUILD_PATH = "/build";
        private HudsonConnection _Connection;

        public override HudsonConnection Connection
        {
            get
            {
                return _Connection;
            }
            set
            {
                _Connection = value;

                client.Credentials = new NetworkCredential(Connection.Username, Connection.Password);
            }
        }

        public JsonHudson()
        {
            this.Connection = new HudsonConnection();
        }

        public JsonHudson(HudsonConnection connection)
        {
            this.Connection = connection;
        }

        public override Hudson.Job RetrieveJob(string jobName)
        {
            string jsonMessage = client.DownloadString(CreateJobUrl(jobName));

            JsonSerializer jsonSerializer = new JsonSerializer();

            Hudson.Job job = jsonSerializer.Deserialize<Hudson.Job>(new JsonTextReader(new StringReader(jsonMessage)));

            logger.Debug("Retrieved job:" + job);

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
            string jsonMessage = client.DownloadString(CreateBaseUrl());

            JsonSerializer jsonSerializer = new JsonSerializer();

            Hudson.Hudson hudson = jsonSerializer.Deserialize<Hudson.Hudson>(new JsonTextReader(new StringReader(jsonMessage)));

            return hudson;
        }

        override protected string ApiPath { get { return JSON_API_STRING; } }
    }
}
