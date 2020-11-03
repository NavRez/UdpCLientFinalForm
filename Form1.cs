﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UdpCLientFinalForm
{
    public partial class Form1 : Form
    {

        IPEndPoint serverIpTest = null;
        CustomClient customClient = null;
        Thread SocketListenerThread = null;

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
            var newPort = Int32.Parse(portTextBox.Text) + 1;
            portTextBox.Text = newPort.ToString();

            try
            {
                serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);

                if (hostTextBox.Text.Equals("127.0.0.2"))
                {
                    if (portTextBox.Text.Equals(5080.ToString()))
                    {
                        throw new InvalidCastException("Address cannot be the same as another Server");
                    }
                }

                
                customClient = new CustomClient(nameTextBox.Text, hostTextBox.Text, Int32.Parse(portTextBox.Text));
                clients.Add(customClient);

                //customClient.UdpClient.Connect(serverIpTest);

                //SocketListenerThread = new Thread(new ThreadStart(SocketListener));
                //SocketListenerThread.IsBackground = true;
                //SocketListenerThread.Start();

                string updateMsg = String.Format("REGISTER,1,{0},{1},{2}", nameTextBox.Text, hostTextBox.Text, portTextBox.Text);
                bus = Encoding.ASCII.GetBytes(updateMsg);
                customClient.UdpClient.Send(bus, bus.Length, serverIpTest);
                bus = customClient.UdpClient.Receive(ref serverIpTest);

                bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

                string[] array = myString.Split(",");

                string val = array[0];

                if (val.Equals("REGISTERED"))
                {
                    hostTextBox.Enabled = false;
                    nameTextBox.Enabled = false;
                    portTextBox.Enabled = false;

                    createButton.Enabled = false;
                    removeButton.Enabled = true;
                    subjectGroupBox.Enabled = true;
                    clientOperationBox.Enabled = true;


                    registeredUsersBox.Text += myString + Environment.NewLine;
                    customClient.UdpClient.Close();
                    Console.WriteLine("Exiting connection...");
                }
                else
                {
                    customClient.CloseConnection(serverIpTest);
                    registeredUsersBox.Text += "REGISTER-DENIED" + Environment.NewLine;
                }

            }
            catch (Exception excep)
            {
                richTextBox1.Text += excep.Message + Environment.NewLine;
            }
        }


        
        
        //Function ran on a thread to listen for server updates
        private void SocketListener() 
        {
            int sleepVal = 2000; //2 seconds per check
           
            while (true)
            {
                if (customClient.UdpClient != null)
                {
                    try
                    {
                        //For debuging purposes: Sends a ping to the server
                        //bus = Encoding.ASCII.GetBytes("client " + customClient.ClientName + " : Checking Connection ...");
                        //customClient.UdpClient.Send(bus, bus.Length);

                        bus = customClient.UdpClient.Receive(ref serverIpTest);
                        bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                        string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line
                        UpdateRegisterUserTextBox("Connection good");
                       
                    }
                    catch (Exception ex)
                    {
                        string myString = "Failure trying to receive message: " + ex;
                        Console.WriteLine("Failure trying to receive message: " + ex);
                        UpdateRegisterUserTextBox("Connection failed");
                        
                    }
                    Thread.Sleep(sleepVal);
                    //customClient.Socket.Connect(serverIP);
                }
            }
            
        }

        //Goes to main thread to update the textbox (otherwise crash)
        delegate void SetTextCallback(string myString);
        private void UpdateRegisterUserTextBox(string myString)
        {
            
            if (registeredUsersBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateRegisterUserTextBox);
                this.Invoke(d, new object[] { myString });
            }
            else
            {
                registeredUsersBox.Clear();
                registeredUsersBox.Text += myString + Environment.NewLine;

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
                    serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);
                    string updateMsg = String.Format("UPDATE,6,{0},{1},{2}", nameClientBox.Text, hostClientBox.Text, portClientBox.Text);
                    bus = Encoding.ASCII.GetBytes(updateMsg);
                    clients.Last().RestartClient();
                    clients.Last().UdpClient.Send(bus, bus.Length, serverIpTest);
                    bus = clients.Last().UdpClient.Receive(ref serverIpTest);

                    bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                    string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

                    string[] array = myString.Split(",");

                    string val = array[0];

                    if (val.Equals("UPDATE-CONFIRMED"))
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
                serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);
                string updateMsg = String.Format("DE-REGISTER,4,{0},{1},{2}", nameTextBox.Text, hostTextBox.Text, portTextBox.Text);
                bus = Encoding.ASCII.GetBytes(updateMsg);
                clients.Last().RestartClient();
                clients.Last().UdpClient.Send(bus, bus.Length, serverIpTest);
                bus = clients.Last().UdpClient.Receive(ref serverIpTest);

                bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line


                string[] array = myString.Split(",");

                string val = array[0];

                if (val.Equals("DE-REGISTERED"))
                {
                    richTextBox1.Text += String.Format("Destroying for {0} changed ip address to {1}:{2}", nameTextBox.Text, hostTextBox.Text, portTextBox.Text) + Environment.NewLine;                   
                    clients.Last().CloseConnection(serverIpTest);
                    clients.Clear();
                    hostTextBox.Enabled = true;
                    nameTextBox.Enabled = true;
                    portTextBox.Enabled = true;

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

        private void submitSubjectsButton_Click(object sender, EventArgs e)
        {
            string subjectList = "";

            if (marioCheck.Checked)
            {
                subjectList += String.Format(",{0}", marioCheck.Text);
            }

            if (cmpEngCheck.Checked)
            {
                subjectList += String.Format(",{0}", cmpEngCheck.Text);
            }

            if (disneMarvelCheck.Checked)
            {
                subjectList += String.Format(",{0}", disneMarvelCheck.Text);
            }
            
            if (pokemonCheck.Checked)
            {
                subjectList += String.Format(",{0}", pokemonCheck.Text);
            }

            if (mexicanCheck.Checked)
            {
                subjectList += String.Format(",{0}", mexicanCheck.Text);
            }

            if (protocolsCheck.Checked)
            {
                subjectList += String.Format(",{0}", protocolsCheck.Text);
            }

            if (finalFantasyCheck.Checked)
            {
                subjectList += String.Format(",{0}", finalFantasyCheck.Text);
            }

            if (calculusCheck.Checked)
            {
                subjectList += String.Format(",{0}", calculusCheck.Text);
            }

            if (zackFairCheck.Checked)
            {
                subjectList += String.Format(",{0}", zackFairCheck.Text);
            }

            if (usCheck.Checked)
            {
                subjectList += String.Format(",{0}", usCheck.Text);
            }

            try
            {
                serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);
                string publishMsg = String.Format("SUBJECTS,{0}{1}", subjectTextBox.Text, subjectList);
                bus = Encoding.ASCII.GetBytes(publishMsg);
                clients.Last().RestartClient();
                clients.Last().UdpClient.Send(bus, bus.Length, serverIpTest);
                bus = clients.Last().UdpClient.Receive(ref serverIpTest);

                bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

                string[] array = myString.Split(",");

                string val = array[0];

                if (val.Equals("PUBLISH"))
                {
                    richTextBox1.Text += String.Format("subject list for {0} updated to {1}", subjectTextBox.Text, subjectList) + Environment.NewLine;
                }
                else
                {
                    richTextBox1.Text += String.Format("subject list for {0} rejected", subjectTextBox.Text) + Environment.NewLine;
                }

            }
            catch (Exception excep)
            {
                richTextBox1.Text += excep.Message + Environment.NewLine;
            }

        }
    }
}
