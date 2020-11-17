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
            this.removeButton = new System.Windows.Forms.Button();
            this.labelRegisterResults = new System.Windows.Forms.Label();
            this.registeredUsersBox = new System.Windows.Forms.RichTextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.richLogBox = new System.Windows.Forms.RichTextBox();
            this.clientOperationBox = new System.Windows.Forms.GroupBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.subjectBox = new System.Windows.Forms.TextBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.richMessageBox = new System.Windows.Forms.RichTextBox();
            this.publishButton = new System.Windows.Forms.RadioButton();
            this.subjectGroupBox = new System.Windows.Forms.GroupBox();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.submitSubjectsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usCheck = new System.Windows.Forms.CheckBox();
            this.calculusCheck = new System.Windows.Forms.CheckBox();
            this.protocolsCheck = new System.Windows.Forms.CheckBox();
            this.mexicanCheck = new System.Windows.Forms.CheckBox();
            this.marioCheck = new System.Windows.Forms.CheckBox();
            this.zackFairCheck = new System.Windows.Forms.CheckBox();
            this.finalFantasyCheck = new System.Windows.Forms.CheckBox();
            this.pokemonCheck = new System.Windows.Forms.CheckBox();
            this.disneMarvelCheck = new System.Windows.Forms.CheckBox();
            this.cmpEngCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serverLabel2 = new System.Windows.Forms.LinkLabel();
            this.ServerLabel1 = new System.Windows.Forms.LinkLabel();
            this.serverHostBox2 = new System.Windows.Forms.TextBox();
            this.serverPortBox2 = new System.Windows.Forms.TextBox();
            this.serverHostLabel1 = new System.Windows.Forms.Label();
            this.serverHostBox1 = new System.Windows.Forms.TextBox();
            this.serverPortLabel2 = new System.Windows.Forms.Label();
            this.serverPortBox1 = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.registerGroup.SuspendLayout();
            this.clientOperationBox.SuspendLayout();
            this.subjectGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerGroup
            // 
            this.registerGroup.Controls.Add(this.removeButton);
            this.registerGroup.Controls.Add(this.labelRegisterResults);
            this.registerGroup.Controls.Add(this.registeredUsersBox);
            this.registerGroup.Controls.Add(this.updateButton);
            this.registerGroup.Controls.Add(this.createButton);
            this.registerGroup.Controls.Add(this.nameLabel);
            this.registerGroup.Controls.Add(this.nameTextBox);
            this.registerGroup.Location = new System.Drawing.Point(12, 12);
            this.registerGroup.Name = "registerGroup";
            this.registerGroup.Size = new System.Drawing.Size(374, 272);
            this.registerGroup.TabIndex = 0;
            this.registerGroup.TabStop = false;
            this.registerGroup.Text = "Register Clients";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(279, 163);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(94, 29);
            this.removeButton.TabIndex = 10;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // labelRegisterResults
            // 
            this.labelRegisterResults.AutoSize = true;
            this.labelRegisterResults.Location = new System.Drawing.Point(8, 112);
            this.labelRegisterResults.Name = "labelRegisterResults";
            this.labelRegisterResults.Size = new System.Drawing.Size(139, 20);
            this.labelRegisterResults.TabIndex = 9;
            this.labelRegisterResults.Text = "Registration Results";
            // 
            // registeredUsersBox
            // 
            this.registeredUsersBox.Location = new System.Drawing.Point(7, 144);
            this.registeredUsersBox.Name = "registeredUsersBox";
            this.registeredUsersBox.Size = new System.Drawing.Size(266, 120);
            this.registeredUsersBox.TabIndex = 8;
            this.registeredUsersBox.Text = "";
            // 
            // defaultButton
            // 
            this.updateButton.Location = new System.Drawing.Point(279, 234);
            this.updateButton.Name = "defaultButton";
            this.updateButton.Size = new System.Drawing.Size(94, 29);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(279, 198);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(94, 29);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // labelName
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(24, 28);
            this.nameLabel.Name = "labelName";
            this.nameLabel.Size = new System.Drawing.Size(49, 20);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
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
            // richLogBox
            // 
            this.richLogBox.Location = new System.Drawing.Point(6, 139);
            this.richLogBox.Name = "richLogBox";
            this.richLogBox.Size = new System.Drawing.Size(392, 124);
            this.richLogBox.TabIndex = 1;
            this.richLogBox.Text = "";
            // 
            // clientOperationBox
            // 
            this.clientOperationBox.Controls.Add(this.submitButton);
            this.clientOperationBox.Controls.Add(this.subjectBox);
            this.clientOperationBox.Controls.Add(this.subjectLabel);
            this.clientOperationBox.Controls.Add(this.messageLabel);
            this.clientOperationBox.Controls.Add(this.richMessageBox);
            this.clientOperationBox.Controls.Add(this.publishButton);
            this.clientOperationBox.Location = new System.Drawing.Point(13, 290);
            this.clientOperationBox.Name = "clientOperationBox";
            this.clientOperationBox.Size = new System.Drawing.Size(373, 227);
            this.clientOperationBox.TabIndex = 2;
            this.clientOperationBox.TabStop = false;
            this.clientOperationBox.Text = "Client Operations";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(279, 192);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(94, 29);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // subjectBox
            // 
            this.subjectBox.Location = new System.Drawing.Point(283, 150);
            this.subjectBox.Name = "subjectBox";
            this.subjectBox.Size = new System.Drawing.Size(84, 27);
            this.subjectBox.TabIndex = 0;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(300, 127);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(58, 20);
            this.subjectLabel.TabIndex = 5;
            this.subjectLabel.Text = "Subject";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(96, 127);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(96, 20);
            this.messageLabel.TabIndex = 9;
            this.messageLabel.Text = "Message Box";
            // 
            // richMessageBox
            // 
            this.richMessageBox.Location = new System.Drawing.Point(6, 150);
            this.richMessageBox.Name = "richMessageBox";
            this.richMessageBox.Size = new System.Drawing.Size(265, 71);
            this.richMessageBox.TabIndex = 8;
            this.richMessageBox.Text = "";
            // 
            // publishButton
            // 
            this.publishButton.AutoSize = true;
            this.publishButton.Location = new System.Drawing.Point(141, 27);
            this.publishButton.Name = "publishButton";
            this.publishButton.Size = new System.Drawing.Size(77, 24);
            this.publishButton.TabIndex = 4;
            this.publishButton.TabStop = true;
            this.publishButton.Text = "Publish";
            this.publishButton.UseVisualStyleBackColor = true;
            this.publishButton.Checked = true;
            this.publishButton.CheckedChanged += new System.EventHandler(this.publishButton_CheckedChanged);

            // 
            // subjectGroupBox
            // 
            this.subjectGroupBox.Controls.Add(this.subjectTextBox);
            this.subjectGroupBox.Controls.Add(this.submitSubjectsButton);
            this.subjectGroupBox.Controls.Add(this.label1);
            this.subjectGroupBox.Controls.Add(this.usCheck);
            this.subjectGroupBox.Controls.Add(this.calculusCheck);
            this.subjectGroupBox.Controls.Add(this.protocolsCheck);
            this.subjectGroupBox.Controls.Add(this.mexicanCheck);
            this.subjectGroupBox.Controls.Add(this.marioCheck);
            this.subjectGroupBox.Controls.Add(this.zackFairCheck);
            this.subjectGroupBox.Controls.Add(this.finalFantasyCheck);
            this.subjectGroupBox.Controls.Add(this.pokemonCheck);
            this.subjectGroupBox.Controls.Add(this.disneMarvelCheck);
            this.subjectGroupBox.Controls.Add(this.cmpEngCheck);
            this.subjectGroupBox.Location = new System.Drawing.Point(418, 290);
            this.subjectGroupBox.Name = "subjectGroupBox";
            this.subjectGroupBox.Size = new System.Drawing.Size(415, 227);
            this.subjectGroupBox.TabIndex = 3;
            this.subjectGroupBox.TabStop = false;
            this.subjectGroupBox.Text = "Subjects";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(7, 192);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.ReadOnly = true;
            this.subjectTextBox.Size = new System.Drawing.Size(95, 27);
            this.subjectTextBox.TabIndex = 12;
            this.subjectTextBox.Text = "Test";
            this.subjectTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // submitSubjectsButton
            // 
            this.submitSubjectsButton.Location = new System.Drawing.Point(288, 192);
            this.submitSubjectsButton.Name = "submitSubjectsButton";
            this.submitSubjectsButton.Size = new System.Drawing.Size(94, 29);
            this.submitSubjectsButton.TabIndex = 10;
            this.submitSubjectsButton.Text = "Submit";
            this.submitSubjectsButton.UseVisualStyleBackColor = true;
            this.submitSubjectsButton.Click += new System.EventHandler(this.submitSubjectsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current User";
            // 
            // usCheck
            // 
            this.usCheck.AutoSize = true;
            this.usCheck.Location = new System.Drawing.Point(288, 140);
            this.usCheck.Name = "usCheck";
            this.usCheck.Size = new System.Drawing.Size(99, 24);
            this.usCheck.TabIndex = 4;
            this.usCheck.Text = "US Politics";
            this.usCheck.UseVisualStyleBackColor = true;
            // 
            // calculusCheck
            // 
            this.calculusCheck.AutoSize = true;
            this.calculusCheck.Location = new System.Drawing.Point(288, 110);
            this.calculusCheck.Name = "calculusCheck";
            this.calculusCheck.Size = new System.Drawing.Size(85, 24);
            this.calculusCheck.TabIndex = 4;
            this.calculusCheck.Text = "Calculus";
            this.calculusCheck.UseVisualStyleBackColor = true;
            // 
            // protocolsCheck
            // 
            this.protocolsCheck.AutoSize = true;
            this.protocolsCheck.Location = new System.Drawing.Point(288, 80);
            this.protocolsCheck.Name = "protocolsCheck";
            this.protocolsCheck.Size = new System.Drawing.Size(93, 24);
            this.protocolsCheck.TabIndex = 4;
            this.protocolsCheck.Text = "Protocols";
            this.protocolsCheck.UseVisualStyleBackColor = true;
            // 
            // mexicanCheck
            // 
            this.mexicanCheck.AutoSize = true;
            this.mexicanCheck.Location = new System.Drawing.Point(6, 80);
            this.mexicanCheck.Name = "mexicanCheck";
            this.mexicanCheck.Size = new System.Drawing.Size(138, 24);
            this.mexicanCheck.TabIndex = 4;
            this.mexicanCheck.Text = "Mexican Studies";
            this.mexicanCheck.UseVisualStyleBackColor = true;
            // 
            // marioCheck
            // 
            this.marioCheck.AutoSize = true;
            this.marioCheck.Location = new System.Drawing.Point(288, 20);
            this.marioCheck.Name = "marioCheck";
            this.marioCheck.Size = new System.Drawing.Size(70, 24);
            this.marioCheck.TabIndex = 0;
            this.marioCheck.Text = "Mario";
            this.marioCheck.UseVisualStyleBackColor = true;
            // 
            // zackFairCheck
            // 
            this.zackFairCheck.AutoSize = true;
            this.zackFairCheck.Location = new System.Drawing.Point(7, 140);
            this.zackFairCheck.Name = "zackFairCheck";
            this.zackFairCheck.Size = new System.Drawing.Size(89, 24);
            this.zackFairCheck.TabIndex = 4;
            this.zackFairCheck.Text = "Zack Fair";
            this.zackFairCheck.UseVisualStyleBackColor = true;
            // 
            // finalFantasyCheck
            // 
            this.finalFantasyCheck.AutoSize = true;
            this.finalFantasyCheck.Location = new System.Drawing.Point(7, 110);
            this.finalFantasyCheck.Name = "finalFantasyCheck";
            this.finalFantasyCheck.Size = new System.Drawing.Size(114, 24);
            this.finalFantasyCheck.TabIndex = 4;
            this.finalFantasyCheck.Text = "Final Fantasy";
            this.finalFantasyCheck.UseVisualStyleBackColor = true;
            // 
            // pokemonCheck
            // 
            this.pokemonCheck.AutoSize = true;
            this.pokemonCheck.Location = new System.Drawing.Point(288, 50);
            this.pokemonCheck.Name = "pokemonCheck";
            this.pokemonCheck.Size = new System.Drawing.Size(92, 24);
            this.pokemonCheck.TabIndex = 4;
            this.pokemonCheck.Text = "Pokemon";
            this.pokemonCheck.UseVisualStyleBackColor = true;
            // 
            // disneMarvelCheck
            // 
            this.disneMarvelCheck.AutoSize = true;
            this.disneMarvelCheck.Location = new System.Drawing.Point(7, 50);
            this.disneMarvelCheck.Name = "disneMarvelCheck";
            this.disneMarvelCheck.Size = new System.Drawing.Size(124, 24);
            this.disneMarvelCheck.TabIndex = 4;
            this.disneMarvelCheck.Text = "Disney Marvel";
            this.disneMarvelCheck.UseVisualStyleBackColor = true;
            // 
            // cmpEngCheck
            // 
            this.cmpEngCheck.AutoSize = true;
            this.cmpEngCheck.Location = new System.Drawing.Point(7, 20);
            this.cmpEngCheck.Name = "cmpEngCheck";
            this.cmpEngCheck.Size = new System.Drawing.Size(178, 24);
            this.cmpEngCheck.TabIndex = 0;
            this.cmpEngCheck.Text = "computer engineering";
            this.cmpEngCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serverLabel2);
            this.groupBox1.Controls.Add(this.ServerLabel1);
            this.groupBox1.Controls.Add(this.serverHostBox2);
            this.groupBox1.Controls.Add(this.serverPortBox2);
            this.groupBox1.Controls.Add(this.serverHostLabel1);
            this.groupBox1.Controls.Add(this.serverHostBox1);
            this.groupBox1.Controls.Add(this.serverPortLabel2);
            this.groupBox1.Controls.Add(this.serverPortBox1);
            this.groupBox1.Controls.Add(this.logLabel);
            this.groupBox1.Controls.Add(this.richLogBox);
            this.groupBox1.Location = new System.Drawing.Point(413, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 272);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup and Log";
            // 
            // serverLabel2
            // 
            this.serverLabel2.AutoSize = true;
            this.serverLabel2.Location = new System.Drawing.Point(32, 76);
            this.serverLabel2.Name = "serverLabel2";
            this.serverLabel2.Size = new System.Drawing.Size(69, 20);
            this.serverLabel2.TabIndex = 6;
            this.serverLabel2.TabStop = true;
            this.serverLabel2.Text = "Server 2 :";
            // 
            // ServerLabel1
            // 
            this.ServerLabel1.AutoSize = true;
            this.ServerLabel1.Location = new System.Drawing.Point(32, 39);
            this.ServerLabel1.Name = "ServerLabel1";
            this.ServerLabel1.Size = new System.Drawing.Size(69, 20);
            this.ServerLabel1.TabIndex = 6;
            this.ServerLabel1.TabStop = true;
            this.ServerLabel1.Text = "Server 1 :";
            // 
            // serverHostBox2
            // 
            this.serverHostBox2.Location = new System.Drawing.Point(116, 69);
            this.serverHostBox2.Name = "serverHostBox2";
            this.serverHostBox2.Size = new System.Drawing.Size(86, 27);
            this.serverHostBox2.TabIndex = 2;
            this.serverHostBox2.Text = "192.168.2.187";
            this.serverHostBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverPortBox2
            // 
            this.serverPortBox2.Location = new System.Drawing.Point(221, 69);
            this.serverPortBox2.Name = "serverPortBox2";
            this.serverPortBox2.Size = new System.Drawing.Size(89, 27);
            this.serverPortBox2.TabIndex = 3;
            this.serverPortBox2.Text = "3333";
            this.serverPortBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverHostLabel1
            // 
            this.serverHostLabel1.AutoSize = true;
            this.serverHostLabel1.Location = new System.Drawing.Point(137, 13);
            this.serverHostLabel1.Name = "serverHostLabel1";
            this.serverHostLabel1.Size = new System.Drawing.Size(40, 20);
            this.serverHostLabel1.TabIndex = 4;
            this.serverHostLabel1.Text = "Host";
            // 
            // serverHostBox1
            // 
            this.serverHostBox1.Location = new System.Drawing.Point(116, 36);
            this.serverHostBox1.Name = "serverHostBox1";
            this.serverHostBox1.Size = new System.Drawing.Size(86, 27);
            this.serverHostBox1.TabIndex = 2;
            this.serverHostBox1.Text = "192.168.2.187";
            this.serverHostBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverPortLabel2
            // 
            this.serverPortLabel2.AutoSize = true;
            this.serverPortLabel2.Location = new System.Drawing.Point(241, 13);
            this.serverPortLabel2.Name = "serverPortLabel2";
            this.serverPortLabel2.Size = new System.Drawing.Size(35, 20);
            this.serverPortLabel2.TabIndex = 5;
            this.serverPortLabel2.Text = "Port";
            // 
            // serverPortBox1
            // 
            this.serverPortBox1.Location = new System.Drawing.Point(221, 36);
            this.serverPortBox1.Name = "serverPortBox1";
            this.serverPortBox1.Size = new System.Drawing.Size(89, 27);
            this.serverPortBox1.TabIndex = 3;
            this.serverPortBox1.Text = "4444";
            this.serverPortBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(6, 112);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(40, 20);
            this.logLabel.TabIndex = 2;
            this.logLabel.Text = "Logs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 529);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.subjectGroupBox);
            this.Controls.Add(this.clientOperationBox);
            this.Controls.Add(this.registerGroup);
            this.Name = "Form1";
            this.Text = "UdpClientManager";
            this.registerGroup.ResumeLayout(false);
            this.registerGroup.PerformLayout();
            this.clientOperationBox.ResumeLayout(false);
            this.clientOperationBox.PerformLayout();
            this.subjectGroupBox.ResumeLayout(false);
            this.subjectGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox registerGroup;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label labelRegisterResults;
        private System.Windows.Forms.RichTextBox registeredUsersBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button createButton;


        private List<CustomClient> clients = new List<CustomClient>();
        private byte[] bus = new byte[1024];
        private System.Windows.Forms.RichTextBox richLogBox;
        private System.Windows.Forms.GroupBox clientOperationBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.RichTextBox richMessageBox;
        private System.Windows.Forms.RadioButton publishButton;
        private System.Windows.Forms.TextBox subjectBox;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.GroupBox subjectGroupBox;
        private System.Windows.Forms.Button submitSubjectsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox usCheck;
        private System.Windows.Forms.CheckBox calculusCheck;
        private System.Windows.Forms.CheckBox protocolsCheck;
        private System.Windows.Forms.CheckBox mexicanCheck;
        private System.Windows.Forms.CheckBox marioCheck;
        private System.Windows.Forms.CheckBox zackFairCheck;
        private System.Windows.Forms.CheckBox finalFantasyCheck;
        private System.Windows.Forms.CheckBox pokemonCheck;
        private System.Windows.Forms.CheckBox disneMarvelCheck;
        private System.Windows.Forms.CheckBox cmpEngCheck;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label serverHostLabel1;
        private System.Windows.Forms.TextBox serverHostBox1;
        private System.Windows.Forms.Label serverPortLabel2;
        private System.Windows.Forms.TextBox serverPortBox1;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.LinkLabel serverLabel2;
        private System.Windows.Forms.LinkLabel ServerLabel1;
        private System.Windows.Forms.TextBox serverHostBox2;
        private System.Windows.Forms.TextBox serverPortBox2;
        private System.Windows.Forms.TextBox subjectTextBox;
    }
}

