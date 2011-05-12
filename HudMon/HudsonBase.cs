
namespace HudMon
{
    abstract partial class BaseHudson : IHudson
    {
        protected string Url
        {
            get
            {
                return Connection.Url;
            }
        }

        protected string CreateJobUrl(string jobName)
        {
            return Url + "/job/" + jobName + ApiPath;
        }

        protected string CreateBaseUrl()
        {
            return Url + ApiPath;
        }

        protected abstract string ApiPath { get; }

        #region IHudson Members

        public abstract Hudson.Job RetrieveJob(string jobName);

        public abstract System.Collections.Generic.List<Hudson.SimpleJob> RetrieveJobs();

        public abstract Hudson.Hudson RetrieveHudson();

        public abstract void BuildJob(Hudson.Job job);

        public HudsonConnection Connection { get; set; }

        #endregion
    }
}
