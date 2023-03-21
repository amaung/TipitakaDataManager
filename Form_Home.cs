using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tipitaka_DB;
using Tipitaka_DBTables;
using TipitakaDataManager.Properties;

namespace TipitakaDataManager
{
    public partial class Form_Home : Form
    {
        Form1 parent;
        ClientTipitakaDB? clientTipitakaDB;
        ClientTipitakaDBLogin? clientTipitakaDBLogin;
        ClientActivityLog? clientActivityLog;
        bool showPassword = true;
        public Form_Home(Form1 parent)
        {
            this.parent = parent;
            clientTipitakaDB = parent.clientTipitakaDB as ClientTipitakaDB;
            clientTipitakaDBLogin = parent.clientTipitakaDBLogin as ClientTipitakaDBLogin;
            clientActivityLog= parent.clientActivityLog as ClientActivityLog;

            InitializeComponent();
            textBox_LoginStatus.Text = String.Empty;
            button_Login.Focus();
            label_Date.Text = DateTime.Now.ToString("MMM dd, yyyy");
            button_ShowPswd.Image = Resources.showPasswordEye;
#if DEBUG
            textBox_UserID.Text = "tipitaka.manager@gmail.com";
            textBox_Password.Text = "12345";
#endif
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            bool loginFail = false;
            textBox_LoginStatus.Text = String.Empty;
            if (textBox_UserID.Text.Length == 0 || textBox_Password.Text.Length == 0)
            {
                MessageBox.Show("User ID or password missing.");
                return;
            }
            textBox_LoginStatus.Text = "Please wait while logging ...";
            this.Cursor = Cursors.WaitCursor;
            if (clientActivityLog != null && clientTipitakaDBLogin != null)
            {
                UserProfile? userProfile = clientTipitakaDBLogin.Login(textBox_UserID.Text, textBox_Password.Text, "A");
                if ((clientTipitakaDBLogin.StatusCode == 200 || clientTipitakaDBLogin.StatusCode == 204 ) && userProfile != null)
                {
                    if (userProfile.UserClass == "A" || userProfile.UserClass == "D")
                    {
                        switch (userProfile.Status)
                        {
                            case "Suspended":
                                MessageBox.Show("Your account has been suspended. Please check with the administrator.");
                                textBox_LoginStatus.Text = "Account suspended.";
                                loginFail = true;
                                break;
                            case "Blocked":
                                MessageBox.Show("Your account is blocked.  Please check with the administrator.");
                                textBox_LoginStatus.Text = "Non-active account.";
                                loginFail = true;
                                break;
                            case "Active":
                                if (clientActivityLog != null)
                                {
                                    if (userProfile.UserClass != "D")
                                        clientActivityLog!.AddActivityLog(userProfile.RowKey, "Logged in.");
                                    DateTimeOffset dto = userProfile.LastLogin;
                                    textBox_LoginStatus.Text = userProfile.RowKey + " logged in successfully.\r\n";
                                    if (userProfile.JoinedDate == userProfile.LastLogin)
                                    {
                                        textBox_LoginStatus.Text += "Welcome to Tipitaka Data Manager.";
                                    }
                                    else
                                    {
                                        textBox_LoginStatus.Text += "Your last login was on " + dto.ToLocalTime().ToString();
                                        textBox_LoginStatus.Text += "\r\nConnected to " + clientTipitakaDBLogin.GetCloudStorageName();
                                    }
                                }
                                break;
                            case "IncorrectPassword":
                                MessageBox.Show("Incorrect password.");
                                textBox_LoginStatus.Text = "Login failed.";
                                loginFail = true;
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not authorized to use this application.");
                        textBox_LoginStatus.Text = "Unauthorized user.";
                        loginFail = true;
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                    textBox_LoginStatus.Text = "Login failed.";
                    loginFail = true;
                }
                this.Cursor = Cursors.Default;
                if (!loginFail)
                {
                    parent.EnableButtons();
                    parent.LoadInitialData();
                    button_Login.Enabled = false;
                }
                textBox_LoginStatus.Focus();
            }
        }

        private void button_ShowPswd_Click(object sender, EventArgs e)
        {
            if (showPassword)
            {
                textBox_Password.PasswordChar= '\0';
                button_ShowPswd.Image = Resources.hidePasswordEye;
            }
            else
            {
                textBox_Password.PasswordChar = '*';
                button_ShowPswd.Image = Resources.showPasswordEye;
            }
            showPassword =! showPassword;
        }

        private void PasswordChanged(object sender, EventArgs e)
        {
            textBox_LoginStatus.Text = string.Empty;
        }
    }
}
