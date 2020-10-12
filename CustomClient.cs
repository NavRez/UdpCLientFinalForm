using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpCLientFinalForm
{
    class CustomClient
    {
        /// <summary>
        /// Initialize the custom client, which includes a name and sets the receive and send timeouts
        /// </summary>
        /// <param name="name"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public CustomClient(string name, string host, int port)
        {
            clientName = name;
            clientHost = host;
            clientPort = port;
            ipAdress = clientHost + "." + clientHost.ToString();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(host), port);
            udpClient = new UdpClient(ip);
            udpClient.Client.ReceiveTimeout = 3000;
            udpClient.Client.SendTimeout = 3000;

        }
        /// <summary>
        /// Replace the current subjects with a new one
        /// </summary>
        /// <param name="newSubs"></param>
        public void resetSubjects(List<string> newSubs)
        {
            clientSubjects = newSubs;
        }

        /// <summary>
        /// Add a new subject to the current list
        /// </summary>
        /// <param name="sbject"></param>
        public void addSubjects(string sbject)
        {
            if(!clientSubjects.Contains(sbject)){
                clientSubjects.Add(sbject);
            }
        }

        /// <summary>
        /// Change the IP address of the client to a new one
        /// </summary>
        /// <param name="newHost"></param>
        /// <param name="newPort"></param>
        public void changeIP(string newHost, int newPort)
        {
            clientHost = newHost;
            clientPort = newPort;
            ipAdress = newHost + "." + newPort.ToString();
        }

        /// <summary>
        /// Reconnects a client to its IP address. Called only after closing a socket
        /// </summary>
        /// <param name="oldIp"></param>
        public void restartClient()
        {
            udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse(clientHost), clientPort));
            udpClient.Client.ReceiveTimeout = 3000;
            udpClient.Client.SendTimeout = 3000;
        }

        public string clientName;
        public string clientHost;
        public int clientPort;

        private string ipAdress;
        private List<string> clientSubjects;
        public UdpClient udpClient;

    }
}
