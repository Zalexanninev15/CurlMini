using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace CurlMini
{
    public partial class MainForm : Form
    {
        int rec, run, ml;

        public MainForm()
        {
            InitializeComponent();
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\CurlMini"))
            {
                requestBox.Text = Convert.ToString(reg.GetValue("LastRequest"));
            }
            string releaseId = "";
            using (RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                releaseId = Convert.ToString(reg.GetValue("ReleaseId"));
            }
            if ((releaseId == "") || (Convert.ToInt32(releaseId) < 1802))
            {
                Version.Text = "Not supported";
                Version.ForeColor = Color.Red;
        }
            if (Convert.ToInt32(releaseId) > 1802)
            {
                Version.Text = releaseId;
                Version.ForeColor = Color.Green;
            }
            if (File.Exists("requests.log"))
            {
                recentList.Items.AddRange(File.ReadAllLines("requests.log")); 
            }    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Zalexanninev15/CurlMini");
        }

        async void Send_Click(object sender, EventArgs e)
        {
            if (requestBox.Text != "")
            {
                try
                {
                    Ping ping = new Ping();
                    PingReply pingReply = null;
                    pingReply = ping.Send("google.com");
                    if ((pingReply.Status != IPStatus.HardwareError) || (pingReply.Status != IPStatus.IcmpError))
                    {
                        if ((Version.Text != "Not supported") && (Version.Text != "%VER%"))
                        {
                            statusLabel.Text = "Sending...";
                            oldBox.Text = newBox.Text;
                            newBox.Clear();
                            try
                            {
                                ProcessStartInfo psiOpt111 = new ProcessStartInfo(@"cmd.exe", "/C curl " + requestBox.Text + " && exit");
                                psiOpt111.WindowStyle = ProcessWindowStyle.Hidden;
                                psiOpt111.RedirectStandardOutput = true;
                                psiOpt111.UseShellExecute = false;
                                psiOpt111.CreateNoWindow = true;
                                Process procCommand111 = Process.Start(psiOpt111);
                                StreamReader srIncoming111 = procCommand111.StandardOutput;
                                newBox.Text = srIncoming111.ReadToEnd();
                                recentList.Items.Add(requestBox.Text);
                                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\CurlMini"))
                                {
                                    reg.SetValue("LastRequest", requestBox.Text);
                                }
                                statusLabel.Text = "Ok!";
                            }
                            catch { statusLabel.Text = "Error"; }
                        }
                        else
                        {
                            statusLabel.Text = "Error";
                            MessageBox.Show("Your Windows version is not Windows 10 build 1803 or higher!", "The request cannot be executed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch { statusLabel.Text = "Error"; MessageBox.Show("No Internet access!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                statusLabel.Text = "Error"; MessageBox.Show("You must fill in the text field with the request!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            requestBox.Clear();
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\CurlMini"))
            {
                reg.SetValue("LastRequest", requestBox.Text);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (rec == 1)
            {
                recentPanel.Visible = false;
                panel1.Visible = false;
                pictureBox3.BackColor = Color.FromArgb(67108864);
                rec = 2;
            }
            if (rec == 0)
            {
                panel1.Visible = true;
                pictureBox3.BackColor = panel1.BackColor;
                recentPanel.Visible = true;
                rec = 1;
            }
            if (rec == 2)
                rec = 0;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            recentList.Items.Clear();
            if (File.Exists("requests.log"))
                File.Delete("requests.log");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("requests.log"))
                File.Delete("requests.log");
            using (var sw = new StreamWriter(new FileStream("requests.log", FileMode.Create)))
            {
                if (recentList != null)
                {
                    foreach (var item in recentList.Items) 
                    {
                        sw.WriteLine(Convert.ToString(item));
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            requestBox.Text = Clipboard.GetText();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (ml == 1)
            {
                requestBox.Multiline = false;
                requestBox.Size = new Size(475, 23);
                ml = 2;
            }
            if (ml == 0)
            {
                requestBox.Multiline = true;
                requestBox.Size = new Size(475, 220);
                ml = 1;
            }
            if (ml == 2)
                ml = 0;
        }

        private void recentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (run == 1)
                requestBox.Text = @Convert.ToString(recentList.SelectedItem);
            if (run == 0)
            {
                run = 1;
            }
        }
    }
}
