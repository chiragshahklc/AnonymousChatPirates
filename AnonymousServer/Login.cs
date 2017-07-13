using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonymousServer
{
    enum AllTabPages
    {
        Login,
        Group,
        Chat,
        Members,
        ChangePassword,
        Token
    }
    public partial class Login : Form
    {
        LoginClass lclass;
        List<TabPage> allTabs;
        ServerSocket server;
        List<ClientSockets> clients;
        public string GetLog
        {
            set
            {
                Invoke((MethodInvoker)delegate
                {
                    lstLog.Items.Add(value);
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

        public string GetConnectedUsers
        {
            set
            {
                Invoke((MethodInvoker)delegate
                {
                    lblConnectedUsers.Text = value;
                });
            }
        }
        private bool canStartChat;
        public bool CanStartChat
        {
            get
            {
                return this.canStartChat;
            }
            set
            {
                this.canStartChat = value;
                Invoke((MethodInvoker)delegate
                {
                    if (this.canStartChat)
                        btnStartChat.Enabled = true;
                    else
                        btnStartChat.Enabled = false;
                });
            }
        }

        private int tokenRequested = 0;
        public int TokenRequested
        {
            set
            {
                Invoke((MethodInvoker)delegate
                {
                    tokenRequested += value;
                    //btnChatSendToken.Enabled = true;
                    label11.Text = "Total Token Request: " + tokenRequested;

                    if (tokenRequested <= 0)
                        btnChatSendToken.Enabled = false;
                    else
                        btnChatSendToken.Enabled = true;
                });
            }
        }
        public Login()
        {
            InitializeComponent();

            lclass = new LoginClass();
            allTabs = new List<TabPage>();
            server = new ServerSocket(this);
            clients = new List<ClientSockets>();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        lclass.SetValues(txtUsername.Text, txtPassword.Text, Usertype.Manager);
                        if (lclass.CheckLogin())
                        {
                            Status = "Login Successful.";
                            SwitchTabPages(AllTabPages.Group);
                            DisplayMenubars(false, true, false, true, true);
                            RefreshMembersList();
                        }
                        else
                        {
                            Status = "Login Failed.";
                        }
                    }
                    else
                    {
                        Status = "Password is null.";
                    }
                }
                else
                {
                    Status = "Username is null.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshMembersList()
        {
            lstMembersUserList.Items.Clear();
            var list = server.GetUserList();
            foreach (var x in list)
            {
                lstMembersUserList.Items.Add(x.username);
            }
        }

        public void ConnectedUserList(string name)
        {
            Invoke((MethodInvoker)delegate
            {
                lstUsers.Items.Add(name);
            });
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage page in tabControl1.TabPages)
                {
                    allTabs.Add(page);
                    tabControl1.TabPages.Remove(page);
                }

                SwitchTabPages(AllTabPages.Login);
                DisplayMenubars(true, false, false, false, false);

                this.ActiveControl = txtUsername;
                btnStartChat.Enabled = false;
                btnChatSendToken.Enabled = false;
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

        private void btnStartGroup_Click(object sender, EventArgs e)
        {

            try
            {
                server.StartServer();
                btnStartGroup.Enabled = false;
                //Status = "Server Started";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnStartChat_Click(object sender, EventArgs e)
        {
            try
            {
                server.RequestBroadcast(MessageType.StartGroupChat);
                SwitchTabPages(AllTabPages.Chat);
                DisplayMenubars(false, false, true, false, true);
                var ulist = lclass.ChatUsers();
                lstChatMembers.Items.Clear();
                foreach (var tmp in ulist)
                {
                    lstChatMembers.Items.Add(tmp.name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMembersSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMembersName.Text))
                {
                    Status = "Name can't be empty.";
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtMembersUserName.Text))
                    {
                        Status = "Username can't be empty.";
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtMembersPassword.Text))
                        {
                            Status = "Password can't be empty.";
                        }
                        else
                        {
                            Usertype type;
                            if (cbIsManager.Checked)
                                type = Usertype.Manager;
                            else
                                type = Usertype.Employee;
                            lclass.SaveUser(txtMembersName.Text, txtMembersUserName.Text, txtMembersPassword.Text, type);
                            server.UpdateConnectedUsersLabel();
                            RefreshMembersList();

                            txtMembersName.Clear();
                            txtMembersPassword.Clear();
                            txtMembersUserName.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmMembers_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabPages.Members);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// To hide or show menus in menubar.
        /// </summary>
        /// <param name="login">To display login menu.</param>
        /// <param name="group">To display group menu.</param>
        /// <param name="chat">To display chat menu.</param>
        /// <param name="members">To display members menu.</param>
        /// <param name="changepassword">To display change password menu.</param>
        /// <returns></returns>
        private void DisplayMenubars(bool login, bool group, bool chat, bool members, bool changepassword)
        {
            tsmLogin.Visible = login;
            tsmGroup.Visible = group;
            tsmChat.Visible = chat;
            tsmMembers.Visible = members;
            tsmChangePassword.Visible = false;
        }

        private void tsmGroup_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabPages.Group);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabPages.Login);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmChat_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabPages.Chat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabPages.ChangePassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MsgReceive(string msg, Usertype type)
        {
            Invoke((MethodInvoker)delegate
            {
                string msgToAdd = type.ToString() + ": " + msg + "\r\n";
                lstChatMsg.Items.Add(msgToAdd);
            });
        }

        private void btnChatSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtChatMsg.Text))
                {
                    var data = new SendMethods().ChatMsg(txtChatMsg.Text, Usertype.Manager);
                    server.BroadcastToEveryone(data);
                    string msgToAdd = Usertype.Manager.ToString() + ": " + txtChatMsg.Text + "\r\n";
                    lstChatMsg.Items.Add(msgToAdd);
                    txtChatMsg.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMembersDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMembersUserList.SelectedIndex >= 0)
                {
                    var flag = new LoginClass().DeleteUser(lstMembersUserList.SelectedItem.ToString());
                    if (flag)
                    {
                        RefreshMembersList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCPSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCPOld.Text))
            {
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtCPNew.Text))
                {
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtCPRetype.Text))
                    {
                    }
                    else
                    {

                    }
                }
            }
        }

        private void btnChatSendToken_Click(object sender, EventArgs e)
        {
            server.SendToken(StaticMethods.TokensList[0].user);
            StaticMethods.TokensList.RemoveAt(0);
        }
    }
}
