
using System;
namespace HudMon
{
    /// <summary>Abstract class on which can be based implementations of IHudson</summary>
    abstract partial class BaseHudson : IHudson
    {
        /// <summary>
        /// Hudson Server URL
        /// </summary>
        /// <remarks>Encapsulates Connection.Url</remarks>
        protected string Url
        {
            get
            {
                return Connection.Url;
            }
        }
        /// <summary>
        /// Creates API uri for job 
        /// </summary>
        /// <param name="jobName">name of job</param>
        /// <returns>Uri representing job API path</returns>
        protected Uri CreateJobUri(string jobName)
        {
            return new Uri(Url + "/job/" + jobName + ApiPath);
        }

        /// <summary>
        /// Creates API uri for Hudson server
        /// </summary>
        /// <returns>Uri representing server API path</returns>
        protected Uri CreateBaseUri()
        {
            return new Uri(Url + ApiPath);
        }

        /// <summary>
        /// Suffix for API URL
        /// </summary>
        protected abstract string ApiPath { get; }

        #region IHudson Members

        public abstract Hudson.Job RetrieveJob(string jobName);

        public abstract System.Collections.Generic.List<Hudson.SimpleJob> RetrieveJobs();

        public abstract Hudson.Hudson RetrieveHudson();

        public abstract void BuildJob(Hudson.Job job);

        public virtual HudsonConnection Connection { get; set; }

        #endregion
    }
}
