
using System;
using System.Net;
namespace HudMon
{
    class HudsonWebClient
    {
        private WebClient wc = new WebClient();

        public HudsonWebClient(HudsonConnection connection)
        {
            this.Credential = new NetworkCredential(connection.Username, connection.Password);
        }

        public ICredentials Credential { get; private set; }

        public string DownloadString(Uri uri)
        {
            wc.Credentials = Credential.GetCredential(uri, "Basic");

            return wc.DownloadString(uri);
        }
    }
}
