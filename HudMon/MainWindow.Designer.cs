namespace HudMon
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.jobsListView = new System.Windows.Forms.ListView();
            this.jobNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buildsListView = new System.Windows.Forms.ListView();
            this.buildNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buildUrlColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hudsonBuildsSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helloWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.hudsonJobsSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hudsonBuildsSource)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.notifyContextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hudsonJobsSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.jobsListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buildsListView);
            this.splitContainer1.Size = new System.Drawing.Size(666, 419);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 0;
            // 
            // jobsListView
            // 
            this.jobsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.jobNameColumn});
            this.jobsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobsListView.Location = new System.Drawing.Point(0, 0);
            this.jobsListView.MultiSelect = false;
            this.jobsListView.Name = "jobsListView";
            this.jobsListView.ShowItemToolTips = true;
            this.jobsListView.Size = new System.Drawing.Size(221, 419);
            this.jobsListView.TabIndex = 0;
            this.jobsListView.UseCompatibleStateImageBehavior = false;
            this.jobsListView.View = System.Windows.Forms.View.Details;
            this.jobsListView.SelectedIndexChanged += new System.EventHandler(this.jobsListView_SelectedIndexChanged);
            this.jobsListView.DoubleClick += new System.EventHandler(this.jobsListView_DoubleClick);
            // 
            // jobNameColumn
            // 
            this.jobNameColumn.Text = global::HudMon.Properties.Settings.Default.Name;
            this.jobNameColumn.Width = 250;
            // 
            // buildsListView
            // 
            this.buildsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.buildNumberColumn,
            this.buildUrlColumn});
            this.buildsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildsListView.FullRowSelect = true;
            this.buildsListView.Location = new System.Drawing.Point(0, 0);
            this.buildsListView.MultiSelect = false;
            this.buildsListView.Name = "buildsListView";
            this.buildsListView.Size = new System.Drawing.Size(441, 419);
            this.buildsListView.TabIndex = 0;
            this.buildsListView.UseCompatibleStateImageBehavior = false;
            this.buildsListView.View = System.Windows.Forms.View.Details;
            this.buildsListView.DoubleClick += new System.EventHandler(this.buildsListView_DoubleClick);
            // 
            // buildNumberColumn
            // 
            this.buildNumberColumn.Text = "#";
            // 
            // buildUrlColumn
            // 
            this.buildUrlColumn.Text = "Url";
            this.buildUrlColumn.Width = 378;
            // 
            // hudsonBuildsSource
            // 
            this.hudsonBuildsSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.hudsonBuildsSource_ListChanged);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(666, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterURLToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // enterURLToolStripMenuItem
            // 
            this.enterURLToolStripMenuItem.Name = "enterURLToolStripMenuItem";
            this.enterURLToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.enterURLToolStripMenuItem.Text = "Enter URL...";
            this.enterURLToolStripMenuItem.Click += new System.EventHandler(this.enterURLToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Hudson Monitor";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyContextMenuStrip
            // 
            this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.helloWorldToolStripMenuItem});
            this.notifyContextMenuStrip.Name = "contextMenuStrip1";
            this.notifyContextMenuStrip.Size = new System.Drawing.Size(93, 32);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(89, 6);
            // 
            // helloWorldToolStripMenuItem
            // 
            this.helloWorldToolStripMenuItem.Name = "helloWorldToolStripMenuItem";
            this.helloWorldToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.helloWorldToolStripMenuItem.Text = "Exit";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 421);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(666, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // hudsonJobsSource
            // 
            this.hudsonJobsSource.DataSource = typeof(HudMon.Hudson.Job);
            this.hudsonJobsSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.hudsonJobsSource_ListChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 443);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainWindow";
            this.Text = "Hudson Monitor";
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hudsonBuildsSource)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.notifyContextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hudsonJobsSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource hudsonJobsSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView jobsListView;
        private System.Windows.Forms.ColumnHeader jobNameColumn;
        private System.Windows.Forms.ListView buildsListView;
        private System.Windows.Forms.ColumnHeader buildNumberColumn;
        private System.Windows.Forms.ColumnHeader buildUrlColumn;
        private System.Windows.Forms.BindingSource hudsonBuildsSource;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterURLToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem helloWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    }
}

