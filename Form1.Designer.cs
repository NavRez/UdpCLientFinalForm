using System.Collections.Generic;

namespace UdpCLientFinalForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registerGroup = new System.Windows.Forms.GroupBox();
            this.labelRegisterResults = new System.Windows.Forms.Label();
            this.registeredUsersBox = new System.Windows.Forms.RichTextBox();
            this.defaultButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.clientOperationBox = new System.Windows.Forms.GroupBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.subjectBox = new System.Windows.Forms.TextBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.richMessageBox = new System.Windows.Forms.RichTextBox();
            this.newPortClient = new System.Windows.Forms.Label();
            this.newHostClient = new System.Windows.Forms.Label();
            this.nameClient = new System.Windows.Forms.Label();
            this.publishButton = new System.Windows.Forms.RadioButton();
            this.updateButton = new System.Windows.Forms.RadioButton();
            this.portClientBox = new System.Windows.Forms.TextBox();
            this.hostClientBox = new System.Windows.Forms.TextBox();
            this.nameClientBox = new System.Windows.Forms.TextBox();
            this.registerGroup.SuspendLayout();
            this.clientOperationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerGroup
            // 
            this.registerGroup.Controls.Add(this.labelRegisterResults);
            this.registerGroup.Controls.Add(this.registeredUsersBox);
            this.registerGroup.Controls.Add(this.defaultButton);
            this.registerGroup.Controls.Add(this.createButton);
            this.registerGroup.Controls.Add(this.labelPort);
            this.registerGroup.Controls.Add(this.labelHost);
            this.registerGroup.Controls.Add(this.portTextBox);
            this.registerGroup.Controls.Add(this.hostTextBox);
            this.registerGroup.Controls.Add(this.labelName);
            this.registerGroup.Controls.Add(this.nameTextBox);
            this.registerGroup.Location = new System.Drawing.Point(12, 12);
            this.registerGroup.Name = "registerGroup";
            this.registerGroup.Size = new System.Drawing.Size(314, 248);
            this.registerGroup.TabIndex = 0;
            this.registerGroup.TabStop = false;
            this.registerGroup.Text = "Register Clients";
            // 
            // labelRegisterResults
            // 
            this.labelRegisterResults.AutoSize = true;
            this.labelRegisterResults.Location = new System.Drawing.Point(7, 92);
            this.labelRegisterResults.Name = "labelRegisterResults";
            this.labelRegisterResults.Size = new System.Drawing.Size(139, 20);
            this.labelRegisterResults.TabIndex = 9;
            this.labelRegisterResults.Text = "Registration Results";
            // 
            // registeredUsersBox
            // 
            this.registeredUsersBox.Location = new System.Drawing.Point(7, 115);
            this.registeredUsersBox.Name = "registeredUsersBox";
            this.registeredUsersBox.Size = new System.Drawing.Size(190, 120);
            this.registeredUsersBox.TabIndex = 8;
            this.registeredUsersBox.Text = "";
            // 
            // defaultButton
            // 
            this.defaultButton.Location = new System.Drawing.Point(216, 215);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(94, 29);
            this.defaultButton.TabIndex = 7;
            this.defaultButton.Text = "Default";
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(216, 179);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(94, 29);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(236, 28);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(35, 20);
            this.labelPort.TabIndex = 5;
            this.labelPort.Text = "Port";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(132, 28);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(40, 20);
            this.labelHost.TabIndex = 4;
            this.labelHost.Text = "Host";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(216, 51);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(89, 27);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "8080";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(111, 51);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(86, 27);
            this.hostTextBox.TabIndex = 2;
            this.hostTextBox.Text = "127.0.0.1";
            this.hostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(24, 28);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(7, 51);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(84, 27);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Text = "Test";
            this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(380, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(365, 227);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // clientOperationBox
            // 
            this.clientOperationBox.Controls.Add(this.submitButton);
            this.clientOperationBox.Controls.Add(this.subjectBox);
            this.clientOperationBox.Controls.Add(this.subjectLabel);
            this.clientOperationBox.Controls.Add(this.messageLabel);
            this.clientOperationBox.Controls.Add(this.richMessageBox);
            this.clientOperationBox.Controls.Add(this.newPortClient);
            this.clientOperationBox.Controls.Add(this.newHostClient);
            this.clientOperationBox.Controls.Add(this.nameClient);
            this.clientOperationBox.Controls.Add(this.publishButton);
            this.clientOperationBox.Controls.Add(this.updateButton);
            this.clientOperationBox.Controls.Add(this.portClientBox);
            this.clientOperationBox.Controls.Add(this.hostClientBox);
            this.clientOperationBox.Controls.Add(this.nameClientBox);
            this.clientOperationBox.Location = new System.Drawing.Point(13, 290);
            this.clientOperationBox.Name = "clientOperationBox";
            this.clientOperationBox.Size = new System.Drawing.Size(304, 227);
            this.clientOperationBox.TabIndex = 2;
            this.clientOperationBox.TabStop = false;
            this.clientOperationBox.Text = "Client Operations";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(210, 192);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(94, 29);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // subjectBox
            // 
            this.subjectBox.Location = new System.Drawing.Point(214, 150);
            this.subjectBox.Name = "subjectBox";
            this.subjectBox.Size = new System.Drawing.Size(84, 27);
            this.subjectBox.TabIndex = 0;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(231, 127);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(58, 20);
            this.subjectLabel.TabIndex = 5;
            this.subjectLabel.Text = "Subject";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(49, 127);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(96, 20);
            this.messageLabel.TabIndex = 9;
            this.messageLabel.Text = "Message Box";
            // 
            // richMessageBox
            // 
            this.richMessageBox.Location = new System.Drawing.Point(6, 150);
            this.richMessageBox.Name = "richMessageBox";
            this.richMessageBox.Size = new System.Drawing.Size(190, 71);
            this.richMessageBox.TabIndex = 8;
            this.richMessageBox.Text = "";
            // 
            // newPortClient
            // 
            this.newPortClient.AutoSize = true;
            this.newPortClient.Location = new System.Drawing.Point(232, 68);
            this.newPortClient.Name = "newPortClient";
            this.newPortClient.Size = new System.Drawing.Size(66, 20);
            this.newPortClient.TabIndex = 7;
            this.newPortClient.Text = "new Port";
            // 
            // newHostClient
            // 
            this.newHostClient.AutoSize = true;
            this.newHostClient.Location = new System.Drawing.Point(116, 68);
            this.newHostClient.Name = "newHostClient";
            this.newHostClient.Size = new System.Drawing.Size(71, 20);
            this.newHostClient.TabIndex = 6;
            this.newHostClient.Text = "new Host";
            // 
            // nameClient
            // 
            this.nameClient.AutoSize = true;
            this.nameClient.Location = new System.Drawing.Point(23, 68);
            this.nameClient.Name = "nameClient";
            this.nameClient.Size = new System.Drawing.Size(49, 20);
            this.nameClient.TabIndex = 5;
            this.nameClient.Text = "Name";
            // 
            // publishButton
            // 
            this.publishButton.AutoSize = true;
            this.publishButton.Location = new System.Drawing.Point(110, 27);
            this.publishButton.Name = "publishButton";
            this.publishButton.Size = new System.Drawing.Size(77, 24);
            this.publishButton.TabIndex = 4;
            this.publishButton.TabStop = true;
            this.publishButton.Text = "Publish";
            this.publishButton.UseVisualStyleBackColor = true;
            this.publishButton.CheckedChanged += new System.EventHandler(this.publishButton_CheckedChanged);
            // 
            // updateButton
            // 
            this.updateButton.AutoSize = true;
            this.updateButton.Location = new System.Drawing.Point(7, 27);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(79, 24);
            this.updateButton.TabIndex = 3;
            this.updateButton.TabStop = true;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.CheckedChanged += new System.EventHandler(this.updateButton_CheckedChanged);
            // 
            // portClientBox
            // 
            this.portClientBox.Location = new System.Drawing.Point(215, 91);
            this.portClientBox.Name = "portClientBox";
            this.portClientBox.Size = new System.Drawing.Size(83, 27);
            this.portClientBox.TabIndex = 2;
            // 
            // hostClientBox
            // 
            this.hostClientBox.Location = new System.Drawing.Point(110, 91);
            this.hostClientBox.Name = "hostClientBox";
            this.hostClientBox.Size = new System.Drawing.Size(86, 27);
            this.hostClientBox.TabIndex = 1;
            // 
            // nameClientBox
            // 
            this.nameClientBox.Location = new System.Drawing.Point(6, 91);
            this.nameClientBox.Name = "nameClientBox";
            this.nameClientBox.Size = new System.Drawing.Size(84, 27);
            this.nameClientBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.clientOperationBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.registerGroup);
            this.Name = "Form1";
            this.Text = "UdpClientManager";
            this.registerGroup.ResumeLayout(false);
            this.registerGroup.PerformLayout();
            this.clientOperationBox.ResumeLayout(false);
            this.clientOperationBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox registerGroup;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label labelRegisterResults;
        private System.Windows.Forms.RichTextBox registeredUsersBox;
        private System.Windows.Forms.Button defaultButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.TextBox portTextBox;

        private List<CustomClient> clients = new List<CustomClient>();
        private byte[] bus = new byte[1024];
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox clientOperationBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.RichTextBox richMessageBox;
        private System.Windows.Forms.Label newPortClient;
        private System.Windows.Forms.Label newHostClient;
        private System.Windows.Forms.Label nameClient;
        private System.Windows.Forms.RadioButton publishButton;
        private System.Windows.Forms.RadioButton updateButton;
        private System.Windows.Forms.TextBox portClientBox;
        private System.Windows.Forms.TextBox hostClientBox;
        private System.Windows.Forms.TextBox nameClientBox;
        private System.Windows.Forms.TextBox subjectBox;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Button submitButton;
    }
}

