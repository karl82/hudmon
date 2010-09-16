namespace HudMon
{
    partial class Form1
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
            this.hudsonJobBuildsSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.jobsListView = new System.Windows.Forms.ListView();
            this.jobNameColumn = new System.Windows.Forms.ColumnHeader();
            this.buildsListView = new System.Windows.Forms.ListView();
            this.hudsonJobsSource = new System.Windows.Forms.BindingSource(this.components);
            this.buildsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hudsonJobBuildsSource)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hudsonJobsSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hudsonJobBuildsSource
            // 
            this.hudsonJobBuildsSource.DataSource = this.buildsBindingSource;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.jobsListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buildsListView);
            this.splitContainer1.Size = new System.Drawing.Size(666, 443);
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
            this.jobsListView.Size = new System.Drawing.Size(221, 443);
            this.jobsListView.TabIndex = 0;
            this.jobsListView.UseCompatibleStateImageBehavior = false;
            this.jobsListView.View = System.Windows.Forms.View.Details;
            // 
            // jobNameColumn
            // 
            this.jobNameColumn.Text = global::HudMon.Properties.Settings.Default.Name;
            this.jobNameColumn.Width = 250;
            // 
            // buildsListView
            // 
            this.buildsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildsListView.Location = new System.Drawing.Point(0, 0);
            this.buildsListView.Name = "buildsListView";
            this.buildsListView.Size = new System.Drawing.Size(441, 443);
            this.buildsListView.TabIndex = 0;
            this.buildsListView.UseCompatibleStateImageBehavior = false;
            this.buildsListView.View = System.Windows.Forms.View.Details;
            // 
            // hudsonJobsSource
            // 
            this.hudsonJobsSource.DataSource = typeof(HudMon.Hudson.Job);
            this.hudsonJobsSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.hudsonJobsSource_ListChanged);
            // 
            // buildsBindingSource
            // 
            this.buildsBindingSource.DataMember = "Builds";
            this.buildsBindingSource.DataSource = this.hudsonJobsSource;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 443);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.hudsonJobBuildsSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hudsonJobsSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource hudsonJobsSource;
        private System.Windows.Forms.BindingSource hudsonJobBuildsSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView jobsListView;
        private System.Windows.Forms.ColumnHeader jobNameColumn;
        private System.Windows.Forms.ListView buildsListView;
        private System.Windows.Forms.BindingSource buildsBindingSource;
    }
}

