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

namespace UdpCLientFinalForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GreyOutClientOperations();
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            hostTextBox.Text = "127.0.0.2";
            nameTextBox.Text = "Testing";
            portTextBox.Text = "5080";

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                CustomClient customClient = new CustomClient(nameTextBox.Text, hostTextBox.Text, Int32.Parse(portTextBox.Text));
                clients.Add(customClient);
                IPEndPoint serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);

                bus = Encoding.ASCII.GetBytes("client " + customClient.ClientName + " : Requesting connection ...");
                customClient.UdpClient.Connect(serverIpTest);
                customClient.UdpClient.Send(bus, bus.Length);
                bus = customClient.UdpClient.Receive(ref serverIpTest);

                bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

                registeredUsersBox.Text += myString + Environment.NewLine;
                Console.WriteLine("Exiting connection...");
                customClient.UdpClient.Close();

            }
            catch(Exception excep)
            {
                richTextBox1.Text += excep.Message + Environment.NewLine;
            }


        }

        private void updateButton_CheckedChanged(object sender, EventArgs e)
        {
            if (updateButton.Checked)
            {
                messageLabel.Enabled = false;
                richMessageBox.Enabled = false;
                subjectLabel.Enabled = false;
                subjectBox.Enabled = false;

                newHostClient.Enabled = true;
                hostClientBox.Enabled = true;
                newPortClient.Enabled = true;
                portClientBox.Enabled = true;
            }
        }

        private void publishButton_CheckedChanged(object sender, EventArgs e)
        {
            if (publishButton.Checked)
            {
                messageLabel.Enabled = true;
                richMessageBox.Enabled = true;
                subjectLabel.Enabled = true;
                subjectBox.Enabled = true;

                newHostClient.Enabled = false;
                hostClientBox.Enabled = false;
                newPortClient.Enabled = false;
                portClientBox.Enabled = false;
            }
        }

        public void GreyOutClientOperations()
        {
            messageLabel.Enabled = false;
            richMessageBox.Enabled = false;
            subjectLabel.Enabled = false;
            subjectBox.Enabled = false;

            newHostClient.Enabled = false;
            hostClientBox.Enabled = false;
            newPortClient.Enabled = false;
            portClientBox.Enabled = false;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (updateButton.Checked)
            {
                ; 
            }
            else if (publishButton.Checked)
            {
                ;
            }

        }
    }
}
