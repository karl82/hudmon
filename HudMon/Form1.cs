using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HudMon
{
    public partial class Form1 : Form
    {
        HudsonFactory hudsonFactory = new JsonHudsonFactory("http://endor/hudson/");

        private BindingList<Hudson.Job> jobs = new BindingList<HudMon.Hudson.Job>();
        public Form1()
        {
            InitializeComponent();

            hudsonJobsSource.DataSource = jobs;

            RetrieveJobs();
        }

        private void RetrieveJobs()
        {
            List<Hudson.SimpleJob> tempJobs = hudsonFactory.RetrieveJobs();
            foreach (Hudson.SimpleJob simpleJob in tempJobs)
            {
                Hudson.Job job = hudsonFactory.RetrieveJob(simpleJob.Name);

                jobs.Add(job);
            }
        }

        private void hudsonJobsSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    MakeListViewItemForNewEntry(e.NewIndex);
                    break;
                case ListChangedType.ItemChanged:
                    UpdateListViewItem(e.NewIndex);
                    break;
            }
        }

        private void UpdateListViewItem(int index)
        {
            ListViewItem item = jobsListView.Items[index];
            CopyJobToListViewItem(index, item);
        }

        private void CopyJobToListViewItem(int index, ListViewItem item)
        {
            Hudson.Job job = jobs[index];
            item.SubItems[0].Text = job.DisplayName;
            item.ToolTipText = CreateToolTipForJob(job);
        }

        private string CreateToolTipForJob(HudMon.Hudson.Job job)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Name: ").Append(job.Name).AppendLine();
            sb.Append("URL: ").Append(job.Url).AppendLine();
            sb.Append("Buildable: ").Append(job.Buildable).AppendLine();
            sb.Append("Next Build: ").Append(job.NextBuildNumber).AppendLine();
            sb.Append("Last Build: ").Append(job.LastBuild).AppendLine();
            sb.Append("Last Completed Build: ").Append(job.LastCompletedBuild).AppendLine();
            sb.Append("Last Failed Build: ").Append(job.LastFailedBuild).AppendLine();
            sb.Append("Last Sucessful Build: ").Append(job.LastSuccessfulBuild).AppendLine();
            sb.Append("Last Failed Build: ").Append(job.NextBuildNumber).AppendLine();

            return sb.ToString();
        }

        private void MakeListViewItemForNewEntry(int index)
        {
            ListViewItem item = new ListViewItem();
            CopyJobToListViewItem(index, item);
            jobsListView.Items.Insert(index, item);
        }
    }
}
