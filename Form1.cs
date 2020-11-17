﻿using System;
using System.Collections;
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
        String serverMessage = "";
        String[] messageArr;
        List<string> tempUserList = new List<string>();
        int countRQ = 0;

        IPEndPoint serverA = new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), 4444);
        IPEndPoint serverB = new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), 3333);
        IPEndPoint servingServer;

        bool messageReceived = false;
        public Form1()
        {
            InitializeComponent();
            GreyOutClientOperations();
            servingServer = serverA;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (messageReceived)
            {
                customClient = new CustomClient(nameTextBox.Text);
                bus = Encoding.ASCII.GetBytes(String.Format("UPDATE,{0},{1}", countRQ++, customClient.ClientName));
                customClient.UdpClient.Send(bus, bus.Length, servingServer);
            }
            else
            {
                bus = Encoding.ASCII.GetBytes(String.Format("UPDATE,{0},{1}", countRQ++, customClient.ClientName));
                customClient.UdpClient.Send(bus, bus.Length, serverA);
                customClient.UdpClient.Send(bus, bus.Length, serverB);
            }
        }


        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// Creates a new CustomClient by taking in the name, host and port specified by a User. Logs an Error message if Ip Address or name is already in use
        /// </summary>
        private void createButton_Click(object sender, EventArgs e)
        {

            serverA = new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), 4444);
            serverB = new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), 3333);
            customClient = new CustomClient(nameTextBox.Text);
            bus = Encoding.ASCII.GetBytes("REGISTER,0,name");

            SocketListenerThread = new Thread(new ThreadStart(SocketListener));
            SocketListenerThread.IsBackground = true;
            SocketListenerThread.Start();

            bus = Encoding.ASCII.GetBytes(String.Format("REGISTER,{0},{1}", countRQ++, customClient.ClientName));
            customClient.UdpClient.Send(bus, bus.Length, serverA);
            customClient.UdpClient.Send(bus, bus.Length, serverB);
        }
        
        //Function ran on a thread to listen for server updates
        private void SocketListener() 
        {
            
            //int sleepVal = 2000; //2 seconds per check
           
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
                        serverMessage = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line
                        UpdateRichTextBoxText(registeredUsersBox, serverMessage);
                    }
                    catch (Exception ex)
                    {
                        //serverMessage = "Connection failed ";
                        //Console.WriteLine("Failure trying to receive message: " + ex);
                        UpdateRichTextBoxText(registeredUsersBox, serverMessage);
                    }

                    messageArr = serverMessage.Split(",");
                    string serverCommand = messageArr[0];

                    if (serverCommand.Equals("REGISTERED"))
                    {
                        Invoke((MethodInvoker)delegate { CreateUserReceived(serverIpTest); });
                    }

                    else if (serverCommand.Equals("REGISTER-DENIED"))
                    {
                        Invoke((MethodInvoker)delegate { DenyCreateUserReceived(); });
                    }

                    else if (serverCommand.Equals("DE-REGISTERED"))
                    {
                        Invoke((MethodInvoker)delegate { RemoveUserReceived(); });
                    }

                    else if(serverCommand.Equals("UPDATE-CONFIRMED") || serverCommand.Equals("MESSAGE"))
                    {
                        Invoke((MethodInvoker)delegate { SubmitReceived(); });
                    }

                    else if (serverCommand.Equals("UPDATE-DENIED") || serverCommand.Equals("PUBLISH-DENIED"))
                    {
                        Invoke((MethodInvoker)delegate { DenySubmitReceived(); });
                    }

                    else if (serverCommand.Equals("SUBJECTS-UPDATED"))
                    {
                        Invoke((MethodInvoker)delegate { UpdatedListReceived(); });
                    }

                    else if (serverCommand.Equals("SUBJECTS-REJECTED"))
                    {
                        Invoke((MethodInvoker)delegate { DenyUpdatedListReceived(); });
                    }
                    else if (serverCommand.Equals("CHANGE-SERVER"))
                    {
                        Invoke((MethodInvoker)delegate { ChangeServerReceived(); });

                    }

                    //reset the command
                    serverMessage = "";
                }
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


                publishButton.Checked = true;
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

            publishButton.Checked = true;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {         
            
        string publishMsg = String.Format("PUBLISH,{0},{1},{2},{3}",countRQ++, customClient.ClientName , subjectBox.Text, richMessageBox.Text);
        bus = Encoding.ASCII.GetBytes(publishMsg);
        customClient.UdpClient.Send(bus, bus.Length, servingServer);

        }

        private void removeButton_Click(object sender, EventArgs e)
        {      
            string deregMsg = String.Format("DE-REGISTER,{0},{1}",countRQ++, nameTextBox.Text);
            bus = Encoding.ASCII.GetBytes(deregMsg);
            customClient.UdpClient.Send(bus, bus.Length, servingServer);                
        }

        private void submitSubjectsButton_Click(object sender, EventArgs e)
        {
            tempUserList.Clear();

            if (marioCheck.Checked)
            {
                tempUserList.Add(marioCheck.Text);               
            }

            if (cmpEngCheck.Checked)
            {
                tempUserList.Add(cmpEngCheck.Text);
            }

            if (disneMarvelCheck.Checked)
            {
                tempUserList.Add(disneMarvelCheck.Text);
            }
            
            if (pokemonCheck.Checked)
            {
                tempUserList.Add(pokemonCheck.Text);
            }

            if (mexicanCheck.Checked)
            {
                tempUserList.Add(mexicanCheck.Text);
            }

            if (protocolsCheck.Checked)
            {
                tempUserList.Add(protocolsCheck.Text);
            }

            if (finalFantasyCheck.Checked)
            {
                tempUserList.Add(finalFantasyCheck.Text);
            }

            if (calculusCheck.Checked)
            {
                tempUserList.Add(calculusCheck.Text);
            }

            if (zackFairCheck.Checked)
            {
                tempUserList.Add(zackFairCheck.Text);
            }

            if (usCheck.Checked)
            {
                tempUserList.Add(usCheck.Text);
            }
            string combinedList = string.Join("@", tempUserList.ToArray());

            string subjectMsg = String.Format("SUBJECTS,{0},{1},{2}", countRQ++,customClient.ClientName, combinedList);
            bus = Encoding.ASCII.GetBytes(subjectMsg);
            customClient.UdpClient.Send(bus, bus.Length, servingServer);
        }

        private void CreateUserReceived(IPEndPoint currentip)
        {
            //serverMessage = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line
            //UpdateRichTextBoxText(registeredUsersBox, serverMessage);
            servingServer = currentip;
            registeredUsersBox.Text = "User successfully Connected to server: " + servingServer;

            serverHostBox1.Enabled = false;
            serverHostBox2.Enabled = false;
            serverPortBox1.Enabled = false;
            serverPortBox2.Enabled = false;
           
            nameTextBox.Enabled = false;
            
            createButton.Enabled = false;
            updateButton.Enabled = false;
            removeButton.Enabled = true;

            subjectGroupBox.Enabled = true;
            clientOperationBox.Enabled = true;
            publishButton.Checked = true;
            messageReceived = true;


        }

        private void DenyCreateUserReceived()
        {
            registeredUsersBox.Text += serverMessage;

        }

        private void RemoveUserReceived()
        {
          
            richLogBox.Text += String.Format("Destroying for {0}", nameTextBox.Text) + Environment.NewLine;


            nameTextBox.Enabled = true;

            createButton.Enabled = true;
            updateButton.Enabled = true;


            removeButton.Enabled = false;
            subjectGroupBox.Enabled = false;
            clientOperationBox.Enabled = false;

            publishButton.Checked = true;
        }

        private void SubmitReceived()
        {

        richLogBox.Text += String.Format("Message from {0} regarding {1} : {2}", messageArr[1], messageArr[2], messageArr[3]);

        }

        private void DenySubmitReceived()
        {
            richLogBox.Text += serverMessage;
        }

        private void UpdatedListReceived()
        {
            customClient.ClientSubjects.Clear();
            customClient.ClientSubjects = messageArr[3].Split("@").ToList();
            string combinedList = "[ " + string.Join(", ", customClient.ClientSubjects.ToArray()) + " ]";

            richLogBox.Text += String.Format("subject list for {0} updated to:\n {1}",
                customClient.ClientName, combinedList) + Environment.NewLine;
        }

        private void DenyUpdatedListReceived()
        {
            string combinedList = "[ " + string.Join(", ", customClient.ClientSubjects.ToArray()) + " ]";

            richLogBox.Text += String.Format("subject list for {0} denied :\n {1}",
                customClient.ClientName, combinedList) + Environment.NewLine;
        }



        private void ChangeServerReceived()
        {
            richLogBox.Text += String.Format("Serving a different Server") + Environment.NewLine;
            servingServer = serverA;
        }



        /// <summary>
        /// Helper method to determin if invoke required, if so will rerun method on correct thread.
        /// if not do nothing.
        /// </summary>
        /// <param name="c">Control that might require invoking</param>
        /// <param name="a">action to preform on control thread if so.</param>
        /// <returns>true if invoke required</returns>
        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;

            return true;
        }

            // usage on textbox
        public void UpdateRichTextBoxText(RichTextBox textbox, String text)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(textbox, () => UpdateRichTextBoxText(textbox, text))) return;
                textbox.Text = text;
        }
    }
}
