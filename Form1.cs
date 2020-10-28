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
                IPEndPoint serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);

                if (hostTextBox.Text.Equals("127.0.0.2"))
                {
                    if (portTextBox.Text.Equals(5080.ToString()))
                    {
                        throw new InvalidCastException("Address cannot be the same as another Server");
                    }
                }
                CustomClient customClient = new CustomClient(nameTextBox.Text, hostTextBox.Text, Int32.Parse(portTextBox.Text));
                clients.Add(customClient);

                bus = Encoding.ASCII.GetBytes("client " + customClient.ClientName + " : Requesting connection ...");
                //customClient.UdpClient.Connect(serverIpTest);
                customClient.UdpClient.Send(bus, bus.Length, serverIpTest);
                bus = customClient.UdpClient.Receive(ref serverIpTest);

                bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

                registeredUsersBox.Text += myString + Environment.NewLine;

                createButton.Enabled = false;
                removeButton.Enabled = true;
                subjectGroupBox.Enabled = true;
                clientOperationBox.Enabled = true;
                Console.WriteLine("Exiting connection...");
                //customClient.UdpClient.Close();

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
            removeButton.Enabled = false;
            subjectGroupBox.Enabled = false;
            clientOperationBox.Enabled = false;

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
                try
                {
                    IPEndPoint serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);
                    string updateMsg = String.Format("UPDATE,6,{0},{1},{2}", nameClientBox.Text, hostClientBox.Text, portClientBox.Text);
                    bus = Encoding.ASCII.GetBytes(updateMsg);
                    clients.Last().RestartClient();
                    clients.Last().UdpClient.Send(bus, bus.Length, serverIpTest);
                    bus = clients.Last().UdpClient.Receive(ref serverIpTest);

                    bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                    string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

                    if (Int64.Parse(myString) == 7)
                    {
                        richTextBox1.Text += String.Format("Update for {0} changed ip address to {1}:{2}", nameClientBox.Text, hostClientBox.Text, portClientBox.Text) + Environment.NewLine;
                        clients.Last().ChangeIP(hostClientBox.Text, Int32.Parse(portClientBox.Text));
                    }
                    else
                    {
                        richTextBox1.Text += "Update rejected " + Environment.NewLine;
                    }
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ermo)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    richTextBox1.Text += ermo.Message + Environment.NewLine;
                }


            }
            else if (publishButton.Checked)
            {
                ;
            }

        }

        private void removeButton_Click(object sender, EventArgs e)
        {

            try
            {
                IPEndPoint serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);
                string updateMsg = String.Format("DE-REGISTER,4,{0},{1},{2}", nameTextBox.Text, hostTextBox.Text, portTextBox.Text);
                bus = Encoding.ASCII.GetBytes(updateMsg);
                clients.Last().RestartClient();
                clients.Last().UdpClient.Send(bus, bus.Length, serverIpTest);
                bus = clients.Last().UdpClient.Receive(ref serverIpTest);

                bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

                if (Int64.Parse(myString) == 7)
                {
                    richTextBox1.Text += String.Format("Destroying for {0} changed ip address to {1}:{2}", nameTextBox.Text, hostTextBox.Text, portTextBox.Text) + Environment.NewLine;
                    clients.Last().CloseConnection(serverIpTest);
                    clients.Clear();
                    createButton.Enabled = true;
                    removeButton.Enabled = false;
                    subjectGroupBox.Enabled = false;
                    clientOperationBox.Enabled = false;
                }
                else
                {
                    richTextBox1.Text += "Destruction rejected " + Environment.NewLine;
                }

            }
            catch (Exception excep)
            {
                richTextBox1.Text += excep.Message + Environment.NewLine;
            }
        }
    }
}
