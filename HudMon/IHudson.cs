
using System.Collections.Generic;
namespace HudMon
{
    public interface IHudson
    {
        /// <summary>
        /// Retrive Job instance from Hudson server
        /// </summary>
        /// <param name="jobName">name of job for retrieval</param>
        /// <returns><typeparamref name="Hudson.Job"/> instance</returns>
        Hudson.Job RetrieveJob(string jobName);

        /// <summary>
        /// Retrieve all available jobs from Hudson Server
        /// </summary>
        /// <returns>List of jobs</returns>
        List<Hudson.SimpleJob> RetrieveJobs();

        /// <summary>
        /// Retrieve information about Hudson server/node
        /// </summary>
        /// <returns>Node information</returns>
        Hudson.Hudson RetrieveHudson();

        /// <summary>
        /// Trigger job building
        /// </summary>
        /// <param name="job">Job which should be build</param>
        void BuildJob(Hudson.Job job);

        /// <summary>
        /// Connection information to Hudson server
        /// </summary>
        HudsonConnection Connection { get; set; }
    }
}
