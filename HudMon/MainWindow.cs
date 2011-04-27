using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HudMon
{
    public partial class MainWindow : Form
    {
        HudsonFactory hudsonFactory;

        private BindingList<Hudson.Job> jobs = new BindingList<HudMon.Hudson.Job>();
        private BindingList<Hudson.Build> builds = new BindingList<HudMon.Hudson.Build>();
        private string url_;

        public string Url
        {
            get {
                return url_;
            }
            set
            {
                url_ = value;
                Text = url_;

                CreateHudsonFactory();
                RetrieveJobs();
            }
        }

        public MainWindow(string url)
        {
            Initialize();

            Url = url;
        }

        private void Initialize()
        {
            InitializeComponent();

            hudsonJobsSource.DataSource = jobs;
            hudsonBuildsSource.DataSource = builds;
        }

        public MainWindow()
        {
            Initialize();
        }

        private void CreateHudsonFactory()
        {
            hudsonFactory = new JsonHudsonFactory(Url);
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
                    MakeJobListViewItemForNewEntry(e.NewIndex);
                    break;
                case ListChangedType.ItemChanged:
                    UpdateJobListViewItem(e.NewIndex);
                    break;
            }
        }

        private void UpdateJobListViewItem(int index)
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

        private void MakeJobListViewItemForNewEntry(int index)
        {
            ListViewItem item = new ListViewItem();
            CopyJobToListViewItem(index, item);
            jobsListView.Items.Insert(index, item);
        }

        private void jobsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            builds.Clear();

            ListView.SelectedIndexCollection indexes = jobsListView.SelectedIndices;

            if (indexes.Count > 0)
            {
                Hudson.Job selectedJob = jobs[indexes[0]];

                foreach (Hudson.Build build in selectedJob.Builds)
                {
                    builds.Add(build);
                }
            }
        }

        private void hudsonBuildsSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    MakeBuildListViewItemForNewEntry(e.NewIndex);
                    break;
                case ListChangedType.ItemChanged:
                    UpdateBuildListViewItem(e.NewIndex);
                    break;
                case ListChangedType.Reset:
                    ClearBuildListView();
                    break;
            }
        }

        private void ClearBuildListView()
        {
            buildsListView.Items.Clear();
        }

        private void UpdateBuildListViewItem(int index)
        {
            throw new NotImplementedException();
        }

        private void MakeBuildListViewItemForNewEntry(int index)
        {
            ListViewItem item = new ListViewItem();
            CopyBuildToListViewItem(index, item);
            buildsListView.Items.Insert(index, item);
        }

        private void CopyBuildToListViewItem(int index, ListViewItem item)
        {
            Hudson.Build build = builds[index];
            item.SubItems.Clear();
            item.SubItems[0].Text = build.Number.ToString();
            item.SubItems.Add(build.Url);
        }

        private void buildsListView_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = buildsListView.SelectedIndices;

            if (indexes.Count > 0)
            {
                Hudson.Build selectedBuild = builds[indexes[0]];
                Execute(selectedBuild.Url);
            }

        }

        private void Execute(string what)
        {
            Process.Start(what);
        }

        private void jobsListView_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = jobsListView.SelectedIndices;

            if (indexes.Count > 0)
            {
                Hudson.Job selectedJob = jobs[indexes[0]];

                Execute(selectedJob.Url);
            }
        }

        private void enterURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AskForUrl();
        }

        private void AskForUrl()
        {
            string url = Url;

            if (FormUtils.InputBox("Hudson URL", "Enter Hudson Server URL", ref url) == DialogResult.OK)
            {
                Url = url;
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

    }
}
