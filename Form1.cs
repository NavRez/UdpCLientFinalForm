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
        public Form1()
        {
            InitializeComponent();
            GreyOutClientOperations();
        }

        IPEndPoint serverIP = null;
        CustomClient customClient = null;
        private void defaultButton_Click(object sender, EventArgs e)
        {
            hostTextBox.Text = "127.0.0.2";
            nameTextBox.Text = "Testing";
            portTextBox.Text = "5080";

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {

            try
            {
                customClient = new CustomClient(nameTextBox.Text, hostTextBox.Text, Int32.Parse(portTextBox.Text));
                clients.Add(customClient);
                serverIP = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);

                customClient.Socket.Connect(serverIP);

                Thread SocketListenerThread = new Thread(new ThreadStart(SocketListener));
                SocketListenerThread.IsBackground = true;
                SocketListenerThread.Start();
                
                //bus = Encoding.ASCII.GetBytes("client " + customClient.ClientName + " : Requesting connection ...");

                //customClient.Socket.Send(bus, bus.Length);
                //bus = customClient.Socket.Receive(ref serverIP);

                //bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                //string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

                //registeredUsersBox.Text += myString + Environment.NewLine;

                //////These 2 functions are probably bad
                ////udplistener(customclient);
                ////customClient.BeginReceive(new AsyncCallback(OnUdpData), customClient);


                //Console.WriteLine("Exiting connection...");
                //customClient.Socket.Close();

            }
            catch (Exception excep)
            {
                richTextBox1.Text += excep.Message + Environment.NewLine;
            }
        }


        //private void ThreadedUserInfo()
        //{
        //    try
        //    {
        //        customClient = new CustomClient(nameTextBox.Text, hostTextBox.Text, Int32.Parse(portTextBox.Text));
        //        clients.Add(customClient);
        //        serverIP = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);

        //        bus = Encoding.ASCII.GetBytes("client " + customClient.ClientName + " : Requesting connection ...");
        //        customClient.UdpClient.Connect(serverIP);
        //        customClient.UdpClient.Send(bus, bus.Length);
        //        bus = customClient.UdpClient.Receive(ref serverIP);

        //        bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
        //        string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line


        //        if (registeredUsersBox.InvokeRequired)
        //        {
        //            registeredUsersBox.BeginInvoke(new MethodInvoker(delegate { registeredUsersBox.Text = myString + Environment.NewLine; }));
        //        }
        //        else
        //        {
        //            registeredUsersBox.Text += myString + Environment.NewLine;
        //        }

        //        Console.WriteLine("Exiting connection...");
        //        customClient.UdpClient.Close();
        //    }
        //    catch (Exception excep)
        //    {

        //        if (richTextBox1.InvokeRequired)
        //        {
        //            richTextBox1.BeginInvoke(new MethodInvoker(delegate { richTextBox1.Text = excep.Message + Environment.NewLine; }));

        //        }
        //        else
        //        {
        //            richTextBox1.Text += excep.Message + Environment.NewLine;
        //        }

        //    }
        //}

        
        //Function ran on a thread to listen for server updates
        private void SocketListener() 
        {
           
            while (true)
            {
                try
                {
                    bus = Encoding.ASCII.GetBytes("client " + customClient.ClientName + " : Checking Connection ...");
                    customClient.Socket.Send(bus, bus.Length);
                    bus = customClient.Socket.Receive(ref serverIP);
                    bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
                    string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line
                    UpdateRegisterUserTextBox("Connection good");
                    Thread.Sleep(5000);
                }
                catch(Exception ex)
                {
                    string myString = "Failure trying to receive message: " + ex;
                    Console.WriteLine("Failure trying to receive message: " + ex);
                    UpdateRegisterUserTextBox("Connection failed");
                    Thread.Sleep(5000);
                }
                //customClient.Socket.Connect(serverIP);
                

                
            }
        }

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

        //THESE FUNCTIONS SEEM KINDA USELESS, they don't seem to work
        /*
        protected void OnUdpData(IAsyncResult result)
        {
            // this is what had been passed into BeginReceive as the second parameter:
            customClient = result.AsyncState as CustomClient;
            // points towards whoever had sent the message:
            IPEndPoint source = new IPEndPoint(0, 0);
            // get the actual message and fill out the source:
            byte[] message = customClient.EndReceive(result, ref serverIP);
            // do what you'd like with `message` here:
            Console.WriteLine("Got " + message.Length + " bytes from " + source);
            registeredUsersBox.Text += ("Got " + message.Length + " bytes from " + source);
            // schedule the next receive operation once reading is done:
            customClient.BeginReceive(new AsyncCallback(OnUdpData), serverIP);
        }


        //This is another method I found
        public static async Task<byte[]> ReceiveAsync(byte[] datagram)
        {
            using (var client = new UdpClient(5555))
            {
                client.Client.ReceiveTimeout = 200;
                await client.SendAsync(datagram, datagram.Length, "10.0.0.50", 5555);
                var buffer = await client.ReceiveAsync();
                return buffer.Buffer;
            }
        }

        //Another method I found
        private static void UDPListener(CustomClient client)
        {
            Task.Run(async () =>
            {
                using var udpClient = client;
                string loggingEvent = "";
                while (true)
                {

                    //IPEndPoint object will allow us to read datagrams sent from any source.
                    var receivedResults = await udpClient.ReceiveAsync();
                    loggingEvent += Encoding.ASCII.GetString(receivedResults.Buffer);
                }
            });
        }
        */

    }
        }
