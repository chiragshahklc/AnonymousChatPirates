namespace AnonymousServer
{
    partial class Login
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMembers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCPOld = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCPNew = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCPRetype = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCPSubmit = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMembersUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMembersPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMembersName = new System.Windows.Forms.TextBox();
            this.btnMembersSave = new System.Windows.Forms.Button();
            this.btnMembersDelete = new System.Windows.Forms.Button();
            this.cbIsManager = new System.Windows.Forms.CheckBox();
            this.lstMembersUserList = new System.Windows.Forms.ListBox();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.txtChatMsg = new System.Windows.Forms.TextBox();
            this.btnChatSend = new System.Windows.Forms.Button();
            this.lstChatMembers = new System.Windows.Forms.ListBox();
            this.lstChatMsg = new System.Windows.Forms.ListBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChatSendToken = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.btnStartGroup = new System.Windows.Forms.Button();
            this.btnStartChat = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConnectedUsers = new System.Windows.Forms.Label();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.tabGroup.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLogin,
            this.tsmMembers,
            this.tsmGroup,
            this.tsmChat,
            this.tsmChangePassword});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmLogin
            // 
            this.tsmLogin.Name = "tsmLogin";
            this.tsmLogin.Size = new System.Drawing.Size(58, 24);
            this.tsmLogin.Text = "Login";
            this.tsmLogin.Click += new System.EventHandler(this.tsmLogin_Click);
            // 
            // tsmMembers
            // 
            this.tsmMembers.Name = "tsmMembers";
            this.tsmMembers.Size = new System.Drawing.Size(83, 24);
            this.tsmMembers.Text = "Members";
            this.tsmMembers.Click += new System.EventHandler(this.tsmMembers_Click);
            // 
            // tsmGroup
            // 
            this.tsmGroup.Name = "tsmGroup";
            this.tsmGroup.Size = new System.Drawing.Size(62, 24);
            this.tsmGroup.Text = "Group";
            this.tsmGroup.Click += new System.EventHandler(this.tsmGroup_Click);
            // 
            // tsmChat
            // 
            this.tsmChat.Name = "tsmChat";
            this.tsmChat.Size = new System.Drawing.Size(51, 24);
            this.tsmChat.Text = "Chat";
            this.tsmChat.Click += new System.EventHandler(this.tsmChat_Click);
            // 
            // tsmChangePassword
            // 
            this.tsmChangePassword.Name = "tsmChangePassword";
            this.tsmChangePassword.Size = new System.Drawing.Size(136, 24);
            this.tsmChangePassword.Text = "Change Password";
            this.tsmChangePassword.Click += new System.EventHandler(this.tsmChangePassword_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 649);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1089, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status1
            // 
            this.status1.Name = "status1";
            this.status1.Size = new System.Drawing.Size(0, 17);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCPSubmit);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtCPRetype);
            this.tabPage2.Controls.Add(this.txtCPNew);
            this.tabPage2.Controls.Add(this.txtCPOld);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1025, 541);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Change Password";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCPOld
            // 
            this.txtCPOld.Location = new System.Drawing.Point(482, 132);
            this.txtCPOld.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPOld.Name = "txtCPOld";
            this.txtCPOld.PasswordChar = '●';
            this.txtCPOld.Size = new System.Drawing.Size(221, 22);
            this.txtCPOld.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(375, 135);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Old Password:";
            // 
            // txtCPNew
            // 
            this.txtCPNew.Location = new System.Drawing.Point(482, 162);
            this.txtCPNew.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPNew.Name = "txtCPNew";
            this.txtCPNew.PasswordChar = '●';
            this.txtCPNew.Size = new System.Drawing.Size(221, 22);
            this.txtCPNew.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(370, 165);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "New Password:";
            // 
            // txtCPRetype
            // 
            this.txtCPRetype.Location = new System.Drawing.Point(482, 192);
            this.txtCPRetype.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPRetype.Name = "txtCPRetype";
            this.txtCPRetype.PasswordChar = '●';
            this.txtCPRetype.Size = new System.Drawing.Size(221, 22);
            this.txtCPRetype.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 195);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Retype New Password:";
            // 
            // btnCPSubmit
            // 
            this.btnCPSubmit.Location = new System.Drawing.Point(482, 221);
            this.btnCPSubmit.Name = "btnCPSubmit";
            this.btnCPSubmit.Size = new System.Drawing.Size(116, 33);
            this.btnCPSubmit.TabIndex = 29;
            this.btnCPSubmit.Text = "Submit";
            this.btnCPSubmit.UseVisualStyleBackColor = true;
            this.btnCPSubmit.Click += new System.EventHandler(this.btnCPSubmit_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstMembersUserList);
            this.tabPage1.Controls.Add(this.cbIsManager);
            this.tabPage1.Controls.Add(this.btnMembersDelete);
            this.tabPage1.Controls.Add(this.btnMembersSave);
            this.tabPage1.Controls.Add(this.txtMembersName);
            this.tabPage1.Controls.Add(this.txtMembersPassword);
            this.tabPage1.Controls.Add(this.txtMembersUserName);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1025, 541);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Members";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Username:";
            // 
            // txtMembersUserName
            // 
            this.txtMembersUserName.Location = new System.Drawing.Point(429, 77);
            this.txtMembersUserName.Name = "txtMembersUserName";
            this.txtMembersUserName.Size = new System.Drawing.Size(200, 22);
            this.txtMembersUserName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password:";
            // 
            // txtMembersPassword
            // 
            this.txtMembersPassword.Location = new System.Drawing.Point(429, 105);
            this.txtMembersPassword.Name = "txtMembersPassword";
            this.txtMembersPassword.Size = new System.Drawing.Size(200, 22);
            this.txtMembersPassword.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Name:";
            // 
            // txtMembersName
            // 
            this.txtMembersName.Location = new System.Drawing.Point(429, 49);
            this.txtMembersName.Name = "txtMembersName";
            this.txtMembersName.Size = new System.Drawing.Size(200, 22);
            this.txtMembersName.TabIndex = 14;
            // 
            // btnMembersSave
            // 
            this.btnMembersSave.Location = new System.Drawing.Point(429, 160);
            this.btnMembersSave.Name = "btnMembersSave";
            this.btnMembersSave.Size = new System.Drawing.Size(116, 33);
            this.btnMembersSave.TabIndex = 15;
            this.btnMembersSave.Text = "Save";
            this.btnMembersSave.UseVisualStyleBackColor = true;
            this.btnMembersSave.Click += new System.EventHandler(this.btnMembersSave_Click);
            // 
            // btnMembersDelete
            // 
            this.btnMembersDelete.Location = new System.Drawing.Point(193, 308);
            this.btnMembersDelete.Name = "btnMembersDelete";
            this.btnMembersDelete.Size = new System.Drawing.Size(116, 33);
            this.btnMembersDelete.TabIndex = 16;
            this.btnMembersDelete.Text = "Delete";
            this.btnMembersDelete.UseVisualStyleBackColor = true;
            this.btnMembersDelete.Click += new System.EventHandler(this.btnMembersDelete_Click);
            // 
            // cbIsManager
            // 
            this.cbIsManager.AutoSize = true;
            this.cbIsManager.Location = new System.Drawing.Point(429, 133);
            this.cbIsManager.Name = "cbIsManager";
            this.cbIsManager.Size = new System.Drawing.Size(94, 21);
            this.cbIsManager.TabIndex = 17;
            this.cbIsManager.Text = "Manager?";
            this.cbIsManager.UseVisualStyleBackColor = true;
            // 
            // lstMembersUserList
            // 
            this.lstMembersUserList.FormattingEnabled = true;
            this.lstMembersUserList.ItemHeight = 16;
            this.lstMembersUserList.Location = new System.Drawing.Point(6, 41);
            this.lstMembersUserList.Name = "lstMembersUserList";
            this.lstMembersUserList.Size = new System.Drawing.Size(181, 292);
            this.lstMembersUserList.TabIndex = 18;
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.label11);
            this.tabChat.Controls.Add(this.btnChatSendToken);
            this.tabChat.Controls.Add(this.label4);
            this.tabChat.Controls.Add(this.lstLog);
            this.tabChat.Controls.Add(this.lstChatMsg);
            this.tabChat.Controls.Add(this.lstChatMembers);
            this.tabChat.Controls.Add(this.btnChatSend);
            this.tabChat.Controls.Add(this.txtChatMsg);
            this.tabChat.Location = new System.Drawing.Point(4, 25);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(1025, 541);
            this.tabChat.TabIndex = 2;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // txtChatMsg
            // 
            this.txtChatMsg.Location = new System.Drawing.Point(174, 326);
            this.txtChatMsg.Name = "txtChatMsg";
            this.txtChatMsg.Size = new System.Drawing.Size(723, 22);
            this.txtChatMsg.TabIndex = 16;
            // 
            // btnChatSend
            // 
            this.btnChatSend.Location = new System.Drawing.Point(903, 321);
            this.btnChatSend.Name = "btnChatSend";
            this.btnChatSend.Size = new System.Drawing.Size(116, 33);
            this.btnChatSend.TabIndex = 17;
            this.btnChatSend.Text = "Send";
            this.btnChatSend.UseVisualStyleBackColor = true;
            this.btnChatSend.Click += new System.EventHandler(this.btnChatSend_Click);
            // 
            // lstChatMembers
            // 
            this.lstChatMembers.FormattingEnabled = true;
            this.lstChatMembers.ItemHeight = 16;
            this.lstChatMembers.Location = new System.Drawing.Point(7, 18);
            this.lstChatMembers.Name = "lstChatMembers";
            this.lstChatMembers.Size = new System.Drawing.Size(161, 292);
            this.lstChatMembers.TabIndex = 18;
            // 
            // lstChatMsg
            // 
            this.lstChatMsg.FormattingEnabled = true;
            this.lstChatMsg.ItemHeight = 16;
            this.lstChatMsg.Location = new System.Drawing.Point(174, 18);
            this.lstChatMsg.Name = "lstChatMsg";
            this.lstChatMsg.Size = new System.Drawing.Size(845, 292);
            this.lstChatMsg.TabIndex = 19;
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(392, 362);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(421, 132);
            this.lstLog.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Log:";
            // 
            // btnChatSendToken
            // 
            this.btnChatSendToken.Location = new System.Drawing.Point(6, 321);
            this.btnChatSendToken.Name = "btnChatSendToken";
            this.btnChatSendToken.Size = new System.Drawing.Size(161, 33);
            this.btnChatSendToken.TabIndex = 33;
            this.btnChatSendToken.Text = "Send Token";
            this.btnChatSendToken.UseVisualStyleBackColor = true;
            this.btnChatSendToken.Click += new System.EventHandler(this.btnChatSendToken_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Total Token Request: 0";
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.lblConnectedUsers);
            this.tabGroup.Controls.Add(this.label3);
            this.tabGroup.Controls.Add(this.lstUsers);
            this.tabGroup.Controls.Add(this.btnStartChat);
            this.tabGroup.Controls.Add(this.btnStartGroup);
            this.tabGroup.Location = new System.Drawing.Point(4, 25);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(1025, 541);
            this.tabGroup.TabIndex = 1;
            this.tabGroup.Text = "Group";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // btnStartGroup
            // 
            this.btnStartGroup.Location = new System.Drawing.Point(310, 61);
            this.btnStartGroup.Name = "btnStartGroup";
            this.btnStartGroup.Size = new System.Drawing.Size(217, 48);
            this.btnStartGroup.TabIndex = 4;
            this.btnStartGroup.Text = "Start Participation";
            this.btnStartGroup.UseVisualStyleBackColor = true;
            this.btnStartGroup.Click += new System.EventHandler(this.btnStartGroup_Click);
            // 
            // btnStartChat
            // 
            this.btnStartChat.Location = new System.Drawing.Point(310, 305);
            this.btnStartChat.Name = "btnStartChat";
            this.btnStartChat.Size = new System.Drawing.Size(217, 48);
            this.btnStartChat.TabIndex = 5;
            this.btnStartChat.Text = "Start Group Chat";
            this.btnStartChat.UseVisualStyleBackColor = true;
            this.btnStartChat.Click += new System.EventHandler(this.btnStartChat_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(6, 61);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(298, 292);
            this.lstUsers.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Users:";
            // 
            // lblConnectedUsers
            // 
            this.lblConnectedUsers.AutoSize = true;
            this.lblConnectedUsers.Location = new System.Drawing.Point(533, 77);
            this.lblConnectedUsers.Name = "lblConnectedUsers";
            this.lblConnectedUsers.Size = new System.Drawing.Size(121, 17);
            this.lblConnectedUsers.TabIndex = 8;
            this.lblConnectedUsers.Text = "Users Connected:";
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.btnSubmit);
            this.tabLogin.Controls.Add(this.txtPassword);
            this.tabLogin.Controls.Add(this.txtUsername);
            this.tabLogin.Controls.Add(this.label2);
            this.tabLogin.Controls.Add(this.label1);
            this.tabLogin.Location = new System.Drawing.Point(4, 25);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(1025, 541);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(484, 130);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 22);
            this.txtUsername.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(484, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 8;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(484, 186);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 30);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLogin);
            this.tabControl1.Controls.Add(this.tabGroup);
            this.tabControl1.Controls.Add(this.tabChat);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(32, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1033, 570);
            this.tabControl1.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 671);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabChat.ResumeLayout(false);
            this.tabChat.PerformLayout();
            this.tabGroup.ResumeLayout(false);
            this.tabGroup.PerformLayout();
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMembers;
        private System.Windows.Forms.ToolStripMenuItem tsmLogin;
        private System.Windows.Forms.ToolStripMenuItem tsmGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmChat;
        private System.Windows.Forms.ToolStripMenuItem tsmChangePassword;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCPSubmit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCPRetype;
        private System.Windows.Forms.TextBox txtCPNew;
        private System.Windows.Forms.TextBox txtCPOld;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lstMembersUserList;
        private System.Windows.Forms.CheckBox cbIsManager;
        private System.Windows.Forms.Button btnMembersDelete;
        private System.Windows.Forms.Button btnMembersSave;
        private System.Windows.Forms.TextBox txtMembersName;
        private System.Windows.Forms.TextBox txtMembersPassword;
        private System.Windows.Forms.TextBox txtMembersUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnChatSendToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.ListBox lstChatMsg;
        private System.Windows.Forms.ListBox lstChatMembers;
        private System.Windows.Forms.Button btnChatSend;
        private System.Windows.Forms.TextBox txtChatMsg;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.Label lblConnectedUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button btnStartChat;
        private System.Windows.Forms.Button btnStartGroup;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}