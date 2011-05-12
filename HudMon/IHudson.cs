
using System.Collections.Generic;
namespace HudMon
{
    public interface IHudson
    {
        Hudson.Job RetrieveJob(string jobName);
        List<Hudson.SimpleJob> RetrieveJobs();
        Hudson.Hudson RetrieveHudson();
        void BuildJob(Hudson.Job job);
        HudsonConnection Connection { get; set; }
    }
}
