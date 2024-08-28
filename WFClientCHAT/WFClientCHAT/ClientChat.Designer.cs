namespace WFServerCHAT
{
    partial class ClientChat
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCorpoChat = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIPAddress1 = new System.Windows.Forms.TextBox();
            this.txtIPAddress2 = new System.Windows.Forms.TextBox();
            this.txtIPAddress3 = new System.Windows.Forms.TextBox();
            this.txtIPAddress4 = new System.Windows.Forms.TextBox();
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtUsersList = new System.Windows.Forms.TextBox();
            this.btnConnectServerConf = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCorpoChat
            // 
            this.txtCorpoChat.BackColor = System.Drawing.Color.Azure;
            this.txtCorpoChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorpoChat.Location = new System.Drawing.Point(84, 74);
            this.txtCorpoChat.Multiline = true;
            this.txtCorpoChat.Name = "txtCorpoChat";
            this.txtCorpoChat.ReadOnly = true;
            this.txtCorpoChat.Size = new System.Drawing.Size(360, 249);
            this.txtCorpoChat.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.Azure;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(84, 345);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(277, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // txtNickname
            // 
            this.txtNickname.BackColor = System.Drawing.Color.Azure;
            this.txtNickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNickname.Location = new System.Drawing.Point(84, 42);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(98, 20);
            this.txtNickname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nickname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Messaggio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Indirizzo IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Porta:";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.Azure;
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(286, 14);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(42, 20);
            this.txtPort.TabIndex = 11;
            this.txtPort.Text = "8888";
            // 
            // txtIPAddress1
            // 
            this.txtIPAddress1.BackColor = System.Drawing.Color.Azure;
            this.txtIPAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPAddress1.Location = new System.Drawing.Point(71, 14);
            this.txtIPAddress1.Name = "txtIPAddress1";
            this.txtIPAddress1.Size = new System.Drawing.Size(29, 20);
            this.txtIPAddress1.TabIndex = 13;
            this.txtIPAddress1.Text = "127";
            // 
            // txtIPAddress2
            // 
            this.txtIPAddress2.BackColor = System.Drawing.Color.Azure;
            this.txtIPAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPAddress2.Location = new System.Drawing.Point(113, 14);
            this.txtIPAddress2.Name = "txtIPAddress2";
            this.txtIPAddress2.Size = new System.Drawing.Size(29, 20);
            this.txtIPAddress2.TabIndex = 14;
            this.txtIPAddress2.Text = "0";
            // 
            // txtIPAddress3
            // 
            this.txtIPAddress3.BackColor = System.Drawing.Color.Azure;
            this.txtIPAddress3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPAddress3.Location = new System.Drawing.Point(155, 14);
            this.txtIPAddress3.Name = "txtIPAddress3";
            this.txtIPAddress3.Size = new System.Drawing.Size(29, 20);
            this.txtIPAddress3.TabIndex = 15;
            this.txtIPAddress3.Text = "0";
            // 
            // txtIPAddress4
            // 
            this.txtIPAddress4.BackColor = System.Drawing.Color.Azure;
            this.txtIPAddress4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPAddress4.Location = new System.Drawing.Point(197, 14);
            this.txtIPAddress4.Name = "txtIPAddress4";
            this.txtIPAddress4.Size = new System.Drawing.Size(29, 20);
            this.txtIPAddress4.TabIndex = 16;
            this.txtIPAddress4.Text = "1";
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Location = new System.Drawing.Point(362, 11);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(72, 26);
            this.btnConnectServer.TabIndex = 4;
            this.btnConnectServer.Text = "Connetti";
            this.btnConnectServer.UseVisualStyleBackColor = true;
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Enabled = false;
            this.btnSendMessage.Image = global::WFServerCHAT.Properties.Resources.icon_send;
            this.btnSendMessage.Location = new System.Drawing.Point(372, 331);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnSendMessage.Size = new System.Drawing.Size(72, 36);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtUsersList
            // 
            this.txtUsersList.BackColor = System.Drawing.Color.Azure;
            this.txtUsersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsersList.Location = new System.Drawing.Point(367, 74);
            this.txtUsersList.Multiline = true;
            this.txtUsersList.Name = "txtUsersList";
            this.txtUsersList.ReadOnly = true;
            this.txtUsersList.Size = new System.Drawing.Size(86, 249);
            this.txtUsersList.TabIndex = 17;
            this.txtUsersList.Visible = false;
            // 
            // btnConnectServerConf
            // 
            this.btnConnectServerConf.Location = new System.Drawing.Point(324, 40);
            this.btnConnectServerConf.Name = "btnConnectServerConf";
            this.btnConnectServerConf.Size = new System.Drawing.Size(122, 26);
            this.btnConnectServerConf.TabIndex = 18;
            this.btnConnectServerConf.Text = "Connetti da Conf.";
            this.btnConnectServerConf.UseVisualStyleBackColor = true;
            this.btnConnectServerConf.Click += new System.EventHandler(this.btnConnectServerConf_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.btnConnectServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIPAddress4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIPAddress3);
            this.groupBox1.Controls.Add(this.txtIPAddress1);
            this.groupBox1.Controls.Add(this.txtIPAddress2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 41);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(142, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = ".";
            // 
            // ClientChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(465, 380);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConnectServerConf);
            this.Controls.Add(this.txtUsersList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtCorpoChat);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(481, 419);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(481, 419);
            this.Name = "ClientChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientChat_FormClosing);
            this.Load += new System.EventHandler(this.ClientChat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCorpoChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIPAddress1;
        private System.Windows.Forms.TextBox txtIPAddress2;
        private System.Windows.Forms.TextBox txtIPAddress3;
        private System.Windows.Forms.TextBox txtIPAddress4;
        private System.Windows.Forms.TextBox txtUsersList;
        private System.Windows.Forms.Button btnConnectServerConf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

