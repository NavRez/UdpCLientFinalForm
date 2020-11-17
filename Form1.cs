using System;
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
        int connectedPort;
        string connectedHost;

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
            customClient = new CustomClient(nameTextBox.Text);
            IPEndPoint testServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4444);
            bus = Encoding.ASCII.GetBytes("REGISTER,0,name");
            

            SocketListenerThread = new Thread(new ThreadStart(SocketListener));
            SocketListenerThread.IsBackground = true;
            SocketListenerThread.Start();

            bus = Encoding.ASCII.GetBytes(String.Format("REGISTER,{0},{1}", countRQ++, customClient.ClientName));
            customClient.UdpClient.Send(bus, bus.Length, testServer);
            //var newPort = Int32.Parse(portTextBox.Text) + 1;
            //portTextBox.Text = newPort.ToString();

            //try
            //{

            //    if (hostTextBox.Text.Equals(connectedHost))
            //    {
            //        if (portTextBox.Text.Equals(connectedPort.ToString()))
            //        {
            //            throw new InvalidCastException("Address cannot be the same as another Server");
            //        }
            //    }


            //    customClient = new CustomClient(nameTextBox.Text, hostTextBox.Text, Int32.Parse(portTextBox.Text));
            //    subjectTextBox.Text = nameTextBox.Text;
            //    //clients.Add(customClient);
            //    customClient.UdpClient.Connect(serverIpTest);

            //SocketListenerThread = new Thread(new ThreadStart(SocketListener));
            //SocketListenerThread.IsBackground = true;
            //SocketListenerThread.Start();


            //    //TODO: Change the sent message
            //    //Send a message to the server to ping connection
            //    //bus = Encoding.ASCII.GetBytes("client " + customClient.ClientName + " : Checking Connection ...");
            //    bus = Encoding.ASCII.GetBytes(String.Format("REGISTER,{0},{1},{2},{3}", countRQ++, nameTextBox.Text, hostTextBox.Text, portTextBox.Text));
            //    //bus = Encoding.ASCII.GetBytes("connect user request");
            //    customClient.UdpClient.Send(bus, bus.Length);
            //}
            //catch (Exception excep)
            //{
            //    richLogBox.Text += excep.Message + Environment.NewLine;
            //}
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
                        Invoke((MethodInvoker)delegate { CreateUserReceived(); });
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



                    //Thread.Sleep(sleepVal);

                    //reset the command
                    serverMessage = "";
                }
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

            //serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 8080);
            //connectedPort = 8080;
            connectedHost = "127.0.0.2";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (updateButton.Checked)
            {
                try
                {
                    //serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);
                    string updateMsg = String.Format("UPDATE,{0},{1},{2},{3}",countRQ++, nameClientBox.Text, hostClientBox.Text, portClientBox.Text);
                    bus = Encoding.ASCII.GetBytes(updateMsg);

                    //bus = Encoding.ASCII.GetBytes("send submit");
                    customClient.UdpClient.Send(bus, bus.Length);
                    }
                catch (Exception ermo)
                {
                    richLogBox.Text += ermo.Message + Environment.NewLine;
                }
            }
            else if (publishButton.Checked)
            {
                string publishMsg = String.Format("PUBLISH,{0},{1},{2},{3}",countRQ++, nameClientBox.Text, subjectBox.Text, richMessageBox.Text);
                bus = Encoding.ASCII.GetBytes(publishMsg);

                //bus = Encoding.ASCII.GetBytes("send publish");
                customClient.UdpClient.Send(bus, bus.Length);
            }

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                //serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);
                string deregMsg = String.Format("DE-REGISTER,{0},{1},{2},{3}",countRQ++, nameTextBox.Text, hostTextBox.Text, portTextBox.Text);
                //updateMsg = "remove user request";
                bus = Encoding.ASCII.GetBytes(deregMsg);
                customClient.UdpClient.Send(bus, bus.Length);                

            }
            catch (Exception excep)
            {
                richLogBox.Text += excep.Message + Environment.NewLine;
            }
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
            try
            {
                string subjectMsg = String.Format("SUBJECTS,{0},{1},{2}", countRQ++,subjectTextBox.Text, combinedList);
                bus = Encoding.ASCII.GetBytes(subjectMsg);
                //bus = Encoding.ASCII.GetBytes("send updated list");
                customClient.UdpClient.Send(bus, bus.Length);
                
            }
            catch (Exception excep)
            {
                richLogBox.Text += excep.Message + Environment.NewLine;
            }

        }

        private void CreateUserReceived()
        {
            //serverMessage = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line
            //UpdateRichTextBoxText(registeredUsersBox, serverMessage);
            registeredUsersBox.Text = "User successfully Connected";

            hostTextBox.Enabled = false;
            nameTextBox.Enabled = false;
            portTextBox.Enabled = false;

            createButton.Enabled = false;
            removeButton.Enabled = true;
            subjectGroupBox.Enabled = true;
            clientOperationBox.Enabled = true;

        }

        private void DenyCreateUserReceived()
        {
            richMessageBox.Text += serverMessage;

        }

        private void RemoveUserReceived()
        {
          
            richLogBox.Text += String.Format("Destroying for {0} changed ip address to {1}:{2}",
                nameTextBox.Text, hostTextBox.Text, portTextBox.Text) + Environment.NewLine;

            hostTextBox.Enabled = true;
            nameTextBox.Enabled = true;
            portTextBox.Enabled = true;
            createButton.Enabled = true;

            removeButton.Enabled = false;
            subjectGroupBox.Enabled = false;
            clientOperationBox.Enabled = false;
        }

        private void SubmitReceived()
        {
            //if (updateButton.Checked)
            //{
            //    richLogBox.Text += String.Format("Update for {0} changed ip address to {1}:{2}",
            //    nameClientBox.Text, hostClientBox.Text, portClientBox.Text) + Environment.NewLine;
            //    customClient.ChangeIP(hostClientBox.Text, Int32.Parse(portClientBox.Text));
            //    customClient.UdpClient.Connect(serverIpTest);
            //}
            //else
            //{
            richLogBox.Text += String.Format("Message from {0} regarding {1} : {2}", messageArr[1], messageArr[2], messageArr[3]);
            //}
            
        }

        private void DenySubmitReceived()
        {
            richLogBox.Text += serverMessage;
        }

        private void UpdatedListReceived()
        {
            customClient.ClientSubjects.Clear();
            customClient.ClientSubjects = tempUserList;
            string combinedList = "[ " + string.Join(", ", customClient.ClientSubjects.ToArray()) + " ]";

            richLogBox.Text += String.Format("subject list for {0} updated to:\n {1}",
                subjectTextBox.Text, combinedList) + Environment.NewLine;
        }

        private void DenyUpdatedListReceived()
        {
            string combinedList = "[ " + string.Join(", ", customClient.ClientSubjects.ToArray()) + " ]";

            richLogBox.Text += String.Format("subject list for {0} denied :\n {1}",
                subjectTextBox.Text, combinedList) + Environment.NewLine;
        }



        private void ChangeServerReceived()
        {
            richLogBox.Text += String.Format("Serving a different Server") + Environment.NewLine;
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
        public void UpdateRichTextBoxEnable(RichTextBox textbox, bool value)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(textbox, () => UpdateRichTextBoxEnable(textbox, value))) return;
            textbox.Enabled = value;
        }

        public void UpdateTextBoxText(TextBox textbox, String text)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(textbox, () => UpdateTextBoxText(textbox, text))) return;
            textbox.Text = text;
        }
        public void UpdateTextBoxEnable(TextBox textbox, bool value)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(textbox, () => UpdateTextBoxEnable(textbox, value))) return;
            textbox.Enabled = value;
        }

        //public void UpdateGroupBoxText(GroupBox groupBox, String text)
        //{
        //    //Check if invoke requied if so return - as i will be recalled in correct thread
        //    if (ControlInvokeRequired(groupBox, () => UpdateGroupBoxText(groupBox, text))) return;
        //    groupBox.Text = text;
        //}
        public void UpdateGroupBoxEnable(GroupBox groupBox, bool value)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(groupBox, () => UpdateGroupBoxEnable(groupBox, value))) return;
            groupBox.Enabled = value;
        }

        //Or any control
        public void UpdateButtonEnable(Button button,bool value)
        {
        //Check if invoke requied if so return - as i will be recalled in correct thread
        if (ControlInvokeRequired(button, () => UpdateButtonEnable(button, value))) return;
            button.Enabled = value;
        }


    }
}
