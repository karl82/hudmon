using System;
using System.Windows.Forms;

namespace HudMon
{
    public partial class HudsonConnectionForm : Form
    {
        public HudsonConnectionForm()
        {
            InitializeComponent();
        }

        public HudsonConnectionForm(HudsonConnection connection)
        {
            InitializeComponent();

            Connection = connection;
        }

        public HudsonConnection Connection
        {
            get
            {
                HudsonConnection hc = new HudsonConnection();

                hc.Url = urlBox.Text;
                hc.Username = usernameBox.Text;
                hc.Password = passwordBox.Text;

                return hc;
            }

            set
            {
                urlBox.Text = value.Url;
                usernameBox.Text = value.Username;
                passwordBox.Text = "";
            }
        }

        private void HudsonConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                try
                {
                    var uri = new Uri(urlBox.Text);
                }
                catch (UriFormatException ex)
                {
                    MessageBox.Show(this, ex.Message, "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true;

                    urlBox.Focus();
                }

            }
        }
    }
}
