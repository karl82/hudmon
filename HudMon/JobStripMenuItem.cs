using System.Windows.Forms;

namespace HudMon
{
    class JobStripMenuItem : ToolStripMenuItem
    {
        public JobStripMenuItem(Hudson.Job job)
            : base(job.DisplayName)
        {
            this.Job = job;

            if (Job.Buildable == false)
            {
                Enabled = false;
            }
        }

        public Hudson.Job Job { get; set; }
    }
}
