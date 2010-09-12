
using Newtonsoft.Json;
using System.Net;
using System.IO;
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

        override protected string ApiPath { get { return JSON_API_STRING;} }
    }
}
