using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonymousChatClient
{
    enum AllTabPages
    {
        Connection,
        Chat,
        ChangePassword,
        Login
    }
    public partial class ConnectionForm : Form
    {
        ClientSocket client;
        List<TabPage> allTabs;
        string ChatToken { get; set; }

        public bool CanChatStart
        {
            set
            {
                Invoke((MethodInvoker)delegate
                {
                    if (value)
                    {
                        SwitchTabPages(AllTabPages.Chat);
                        client.RequestChatUsers();
                    }
                });
            }
        }

        public string Status
        {
            set
            {
                Invoke((MethodInvoker)delegate
                {
                    status1.Text = value;
                });
            }
        }
        public ConnectionForm()
        {
            InitializeComponent();

            client = new ClientSocket(this);
            allTabs = new List<TabPage>();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtServerIpAddress.Text))
                {
                    MessageBox.Show("Please Input Server IP Address.");
                }
                else
                {
                    client.ConnectToServer(IPAddress.Parse(txtServerIpAddress.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage page in tabControl1.TabPages)
                {
                    allTabs.Add(page);
                    tabControl1.TabPages.Remove(page);
                }

                SwitchTabPages(AllTabPages.Connection);
                btnChatSend.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SwitchTabPages(AllTabPages tab)
        {

            if (tabControl1.TabPages.Count > 0)
            {
                foreach (TabPage page in tabControl1.TabPages)
                {
                    tabControl1.TabPages.Remove(page);
                }
            }
            tabControl1.TabPages.Add(allTabs[(int)tab]);
            tabControl1.SelectedIndex = 0;

        }

        private void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLoginUsername.Text))
                {
                    MessageBox.Show("Username can't be blank.");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtLoginPassword.Text))
                    {
                        MessageBox.Show("Password Can't be blank.");
                    }
                    else
                    {
                        client.RequestUserValidation(txtLoginUsername.Text, txtLoginPassword.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UserValidated(bool value)
        {
            Invoke((MethodInvoker)delegate
            {
                if (value)
                {
                    btnLoginSubmit.Enabled = false;
                    Status = "User Verified. Wait for server to start chat.";
                }
            });

        }

        public void ConnectionStatus(bool value)
        {
            Invoke((MethodInvoker)delegate
            {
                if (value)
                    SwitchTabPages(AllTabPages.Login);
            });

        }

        public void ChatUsers(List<string> users)
        {
            Invoke((MethodInvoker)delegate
            {
                lstChatUsers.Items.Clear();
                foreach (string str in users)
                {
                    lstChatUsers.Items.Add(str);
                }
            });
        }

        public void ReceiveChatToken(string token)
        {
            Invoke((MethodInvoker)delegate
            {
                this.ChatToken = token;
                lblTokenStatus.Text = "Token Available.";
                
                btnChatSend.Enabled = true;
            });
        }

        private void btnChatRequestToken_Click(object sender, EventArgs e)
        {
            try
            {
                client.RequestToken();
                btnChatRequestToken.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChatSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtChatMsg.Text))
                {
                    client.SendChat(txtChatMsg.Text, ChatToken);
                    ChatToken = "";
                    lblTokenStatus.Text = "Token Unavilable.";
                    txtChatMsg.Clear();
                    btnChatRequestToken.Enabled = true;
                    btnChatSend.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ReceiveMsg(string msg, Usertype utype)
        {
            Invoke((MethodInvoker)delegate
            {
                string msgToAdd = utype.ToString() + ": " + msg + "\r\n";
                lstChatMsg.Items.Add(msgToAdd);
            });
        }
    }
}
