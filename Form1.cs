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
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            hostTextBox.Text = "127.0.0.2";
            nameTextBox.Text = "Testing";
            portTextBox.Text = "5080";

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            CustomClient customClient = new CustomClient(nameTextBox.Text, hostTextBox.Text, Int32.Parse(portTextBox.Text));
            clients.Add(customClient);
            IPEndPoint serverIpTest = new IPEndPoint(IPAddress.Parse("127.0.0.2"), 5080);

            bus = Encoding.ASCII.GetBytes("client "+ customClient.clientName + " Requesting connection ...");
            customClient.udpClient.Send(bus, bus.Length, serverIpTest);
            bus = customClient.udpClient.Receive(ref serverIpTest);

            bus = bus.Where(x => x != 0x00).ToArray(); // functions inspired from https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox 
            string myString = Encoding.ASCII.GetString(bus).Trim();//see link on the aboce line

            registeredUsersBox.Text+= myString + Environment.NewLine;
            customClient.udpClient.Close();

        }
    }
}
