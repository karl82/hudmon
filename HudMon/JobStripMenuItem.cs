using System.Windows.Forms;

namespace HudMon
{
    class JobStripMenuItem : ToolStripMenuItem
    {
        public JobStripMenuItem(Hudson.Job job)
            : base(job.DisplayName)
        {
            this.Job = job;
        }

        public Hudson.Job Job { get; set; }
    }
}
