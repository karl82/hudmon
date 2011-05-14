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

            SetBackColorByLastBuild();
        }

        private void SetBackColorByLastBuild()
        {
            if (Job.LastBuild.Equals(Job.LastFailedBuild))
            {
                BackColor = System.Drawing.Color.Red;
            }

            if (Job.LastBuild.Equals(Job.LastUnstableBuild))
            {
                BackColor = System.Drawing.Color.Yellow;
            }

            if (Job.LastBuild.Equals(Job.LastSuccessfulBuild))
            {
                BackColor = System.Drawing.Color.Green;
            }
        }

        public Hudson.Job Job { get; set; }
    }
}
