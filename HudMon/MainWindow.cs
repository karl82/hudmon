using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HudMon
{
    public partial class MainWindow : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MainWindow));

        IHudson hudson;

        private BindingList<Hudson.Job> jobs = new BindingList<HudMon.Hudson.Job>();
        private BindingList<Hudson.Build> builds = new BindingList<HudMon.Hudson.Build>();

        public string Url
        {
            get
            {
                return Connection.Url;
            }
        }

        public HudsonConnection Connection
        {
            get
            {
                return hudson.Connection;
            }

            set
            {
                hudson.Connection = value;

                Text = Url;

                RefreshJobs();
            }
        }

        private void RefreshJobs()
        {
            try
            {
                ClearJobsAndBuilds();
                RetrieveJobs();

            }
            catch (WebException e)
            {
                logger.Error("Web problem during refreshing jobs", e);

                MessageBox.Show(this, e.Message + "\nRefresh or enter different URL", "Web Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearJobsAndBuilds();
            }
            finally
            {
                UpdateMenu();
                UpdateNotifyContextMenu();
            }
        }

        private void UpdateMenu()
        {
            refreshToolStripMenuItem.Enabled = IsNotUrlEmpty();
        }

        private bool IsNotUrlEmpty()
        {
            return !IsUrlEmpty();
        }

        private void UpdateNotifyContextMenu()
        {
            ContextMenuStrip tempNotifyContextMenu = CreateBasicNotifyContextMenu();

            if (jobs.Count > 0)
            {
                tempNotifyContextMenu.Items.Insert(0, new ToolStripSeparator());

                foreach (Hudson.Job job in jobs)
                {
                    ToolStripMenuItem jobStripMenuItem = new JobStripMenuItem(job);

                    jobStripMenuItem.Click += delegate(object sender, System.EventArgs e)
                    {
                        logger.Debug("Clicked: " + sender);
                        if (sender is JobStripMenuItem)
                        {
                            hudson.BuildJob(((JobStripMenuItem)sender).Job);
                        }
                    };

                    tempNotifyContextMenu.Items.Insert(0, jobStripMenuItem);
                }
            }

            notifyIcon.ContextMenuStrip = tempNotifyContextMenu;
        }


        private void exitMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void refreshMenuItem_Click(object sender, System.EventArgs e)
        {
            RefreshJobs();
        }

        private ContextMenuStrip CreateBasicNotifyContextMenu()
        {
            ContextMenuStrip basicNotifyContextMenu = new ContextMenuStrip();

            ToolStripMenuItem refreshMenuItem = new ToolStripMenuItem("Refresh", null, new EventHandler(refreshMenuItem_Click));
            if (IsUrlEmpty())
            {
                refreshMenuItem.Enabled = false;
            }
            basicNotifyContextMenu.Items.Add(refreshMenuItem);

            basicNotifyContextMenu.Items.Add(new ToolStripMenuItem("Exit", null, new EventHandler(exitMenuItem_Click)));

            return basicNotifyContextMenu;
        }

        private bool IsUrlEmpty()
        {
            return String.IsNullOrEmpty(Url);
        }

        public MainWindow(string url)
        {
            Initialize();

            // TODO: implement from CLI
            //           Url = url;
        }

        private void Initialize()
        {
            InitializeComponent();
            CreateHudson();

            UpdateNotifyContextMenu();

            hudsonJobsSource.DataSource = jobs;
            hudsonBuildsSource.DataSource = builds;
        }

        public MainWindow()
        {
            Initialize();
        }

        private void CreateHudson()
        {
            hudson = new JsonHudson();
        }

        private void ClearJobsAndBuilds()
        {
            builds.Clear();
            jobs.Clear();
        }

        private void RetrieveJobs()
        {
            List<Hudson.SimpleJob> tempJobs = hudson.RetrieveJobs();

            foreach (Hudson.SimpleJob simpleJob in tempJobs)
            {
                Hudson.Job job = hudson.RetrieveJob(simpleJob.Name);

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
                case ListChangedType.Reset:
                    logger.Debug("Reseting jobs");

                    ClearJobsListView();
                    break;
            }
        }

        private void ClearJobsListView()
        {
            jobsListView.Items.Clear();
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
            item.ToolTipText = CreateToolTipTextForJob(job);
        }

        private string CreateToolTipTextForJob(HudMon.Hudson.Job job)
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
            AskForConnection();
        }

        private void AskForConnection()
        {
            HudsonConnectionForm hcf = new HudsonConnectionForm(hudson.Connection);

            if (hcf.ShowDialog() == DialogResult.OK)
            {
                Connection = hcf.Connection;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshJobs();
        }

    }
}
