using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Reflection;
using System.Net.NetworkInformation;

namespace CurlMini
{
    public partial class MainForm : Form
    {
        int rec, run, ml;

        public MainForm()
        {
            InitializeComponent();
            if (Directory.Exists(@Application.StartupPath + @"\curl32"))
                Directory.Delete("curl32", true);
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\CurlMini"))
            {
                requestBox.Text = Convert.ToString(reg.GetValue("LastRequest"));
            }
            try
            {
                ProcessStartInfo psiOpt111 = new ProcessStartInfo("curl");
                psiOpt111.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt111.UseShellExecute = false;
                psiOpt111.CreateNoWindow = true;
                Process procCommand111 = Process.Start(psiOpt111);
                statusLabel.ForeColor = Color.Green;
                curlLabelStatus.Text = "YES";
                curlLabelStatus.ForeColor = Color.Green;
            }
            catch
            {
                statusLabel.Text = "Error";
                statusLabel.ForeColor = Color.Red;
                curlLabelStatus.Text = "NO";
                curlLabelStatus.ForeColor = Color.Red;
                InstallCurl.Visible = true;
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
                        statusLabel.Text = "Sending...";
                        if ((curlLabelStatus.Text != "NO") && (curlLabelStatus.Text != "???"))
                        {
                            statusLabel.ForeColor = Color.Green;
                            oldBox.Text = newBox.Text;
                            newBox.Clear();
                            try
                            {
                                ProcessStartInfo psiOpt111 = new ProcessStartInfo("curl", @requestBox.Text);
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
                                statusLabel.ForeColor = Color.Green;
                                if (newBox.Text == "")
                                {
                                    statusLabel.Text = "There is no data to output";
                                    statusLabel.ForeColor = Color.Red;
                                }
                            }
                            catch { statusLabel.Text = "Error"; statusLabel.ForeColor = Color.Red; }
                        }
                        else
                        {
                            MessageBox.Show("Your Windows doesn't have the curl utility installed!", "The request cannot be executed", MessageBoxButtons.OK, MessageBoxIcon.Error); statusLabel.Text = "Error"; statusLabel.ForeColor = Color.Red;
                        }
                    }
                }
                catch { statusLabel.Text = "Error"; MessageBox.Show("No Internet access!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); statusLabel.ForeColor = Color.Red; }
            }
            else
            {
                statusLabel.Text = "Error"; MessageBox.Show("You must fill in the text field with the request!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); statusLabel.ForeColor = Color.Red;
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
            if (Directory.Exists(@Application.StartupPath + @"\curl32"))
                Directory.Delete("curl32", true);
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

        async void InstallCurl_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Installing the curl utility...";
            statusLabel.ForeColor = Color.Green;
            if (Directory.Exists(@Application.StartupPath + @"\curl32"))
                Directory.Delete("curl32", true);
            try
            {
                File.WriteAllBytes("curl.zip", Properties.Resources.curl);
            }
            catch  { }
            if (File.Exists(@Application.StartupPath + @"\curl.zip"))
            {
                try
                { 
                    ZipFile.ExtractToDirectory(@Application.StartupPath + @"\curl.zip", @Application.StartupPath + @"\");
                    File.Delete("curl.zip");
                    if (File.Exists(@Application.StartupPath + @"\curl32\curl.exe") && File.Exists(@Application.StartupPath + @"\curl32\install.cmd") && File.Exists(@Application.StartupPath + @"\curl32\curl-ca-bundle.crt") && File.Exists(@Application.StartupPath + @"\curl32\libcurl.def") && File.Exists(@Application.StartupPath + @"\curl32\libcurl.dll"))
                    {
                        try
                        {
                            ProcessStartInfo psiOpt = new ProcessStartInfo(@Application.StartupPath + @"\curl32\install.cmd");
                            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                            psiOpt.CreateNoWindow = true;
                            psiOpt.Verb = "runAs";
                            Process procCommand = Process.Start(psiOpt);
                            procCommand.WaitForExit();
                        }
                        catch { MessageBox.Show("Error installing the curl utility", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        this.TopMost = false;
                        panel2.Visible = true;
                        pictureBox7.Enabled = true;
                        Process.Start(@"C:\Windows\curl-ca-bundle.crt");
                        try
                        {
                            ProcessStartInfo psiOpt1111 = new ProcessStartInfo("curl");
                            psiOpt1111.WindowStyle = ProcessWindowStyle.Hidden;
                            psiOpt1111.CreateNoWindow = true;
                            Process procCommand1111 = Process.Start(psiOpt1111);
                            statusLabel.Text = "Ok!";
                            statusLabel.ForeColor = Color.Green;
                            curlLabelStatus.Text = "YES";
                            curlLabelStatus.ForeColor = Color.Green;
                            InstallCurl.Visible = false;
                        }
                        catch
                        {
                            statusLabel.Text = "Error";
                            statusLabel.ForeColor = Color.Red;
                            curlLabelStatus.Text = "NO";
                            curlLabelStatus.ForeColor = Color.Red;
                        }
                        if (Directory.Exists(@Application.StartupPath + @"\curl32"))
                            Directory.Delete("curl32", true);
                    }
                    else
                    {
                        statusLabel.Text = "Error";
                        statusLabel.ForeColor = Color.Red;
                        curlLabelStatus.Text = "NO";
                        curlLabelStatus.ForeColor = Color.Red;
                    }
                }
                catch
                {
                    MessageBox.Show("Error installing the curl utility", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (Directory.Exists(@Application.StartupPath + @"\curl32"))
                        Directory.Delete("curl32", true);
                    statusLabel.Text = "Error";
                    statusLabel.ForeColor = Color.Red;
                    curlLabelStatus.Text = "NO";
                    curlLabelStatus.ForeColor = Color.Red;

                }
            }
            else
            {
                MessageBox.Show("Data is corrupted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Error";
                statusLabel.ForeColor = Color.Red;
                curlLabelStatus.Text = "NO";
                curlLabelStatus.ForeColor = Color.Red;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            pictureBox7.Enabled = false;
            this.TopMost = true;
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
