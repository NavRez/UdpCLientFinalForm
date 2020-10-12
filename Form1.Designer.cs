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
            this.registerGroup.SuspendLayout();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.registerGroup);
            this.Name = "Form1";
            this.Text = "UdpClientManager";
            this.registerGroup.ResumeLayout(false);
            this.registerGroup.PerformLayout();
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
    }
}

