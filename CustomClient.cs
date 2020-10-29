using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpCLientFinalForm
{
    class CustomClient : UdpClient, IDisposable
    {
        #region properties
        public string ClientName { get; set; }
        public string ClientHost { get; set; }
        public string ClientIP { get; set; }
        public bool Registered { get; set; }
        public List<string> ClientSubjects { get; set; }
        public int ClientPort { get; set; }
        public UdpClient UdpClient { get; set; }



        #endregion


        public CustomClient(string _clientName, string _clientHost, string _ip, int _port, List<string> _subject, bool _registered)
        {
            ClientName = _clientName;
            ClientHost = _clientHost;
            ClientIP = _ip;
            ClientPort = _port;
            ClientSubjects = _subject;
            Registered = _registered;
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ClientHost), ClientPort);
            UdpClient = new UdpClient(ip);
            UdpClient.Client.ReceiveTimeout = 3000;
            UdpClient.Client.SendTimeout = 3000;
        }
        /// <summary>
        /// Initialize the custom client, which includes a name and sets the receive and send timeouts
        /// </summary>
        /// <param name="name"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public CustomClient(string name, string host, int port)
        {
            ClientName = name;
            ClientHost = host;
            ClientPort = port;
            ClientIP = ClientHost + "." + ClientPort.ToString();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(host), port);
            UdpClient = new UdpClient(ip);
            UdpClient.Client.ReceiveTimeout = 3000;
            UdpClient.Client.SendTimeout = 3000;
            UdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

        }
        /// <summary>
        /// Restart the client connection
        /// </summary>
        public void RestartClient()
        {
            UdpClient.Close();
            UdpClient = null;
            UdpClient = new UdpClient(new IPEndPoint(IPAddress.Parse(ClientHost), ClientPort));
            UdpClient.Client.ReceiveTimeout = 3000;
            UdpClient.Client.SendTimeout = 3000;
            UdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        /// <summary>
        /// Change the IP on the users request (I think that's how it works?)
        /// </summary>
        /// <param name="newHost"></param>
        /// <param name="newPort"></param>
        public void ChangeIP(string newHost, int newPort)
        {
            ClientHost = newHost;
            ClientPort = newPort;
            ClientIP = newHost + "." + newPort.ToString();
            RestartClient();
        }


        /// <summary>
        /// Add a single subject to the subject list
        /// </summary>
        /// <param name="sbject"></param>
        public void AddSubject(string sbject)
        {
            if (!ClientSubjects.Contains(sbject))
            {
                ClientSubjects.Add(sbject);
            }
        }

        /// <summary>
        /// Add an entire list of subjects the user may be interested in
        /// </summary>
        /// <param name="subjects"></param>
        public void AddSubjectList(List<string> subjects)
        {
            foreach (var subject in subjects)
            {
                AddSubject(subject);
            }
        }

        //May be needed if registered gets set to false to remove all the information of the object
        protected virtual void Dispose(bool disposing)
        {
        }

        public void CloseConnection(IPEndPoint serverIP)
        {
            UdpClient.Client.Shutdown(SocketShutdown.Both);
            UdpClient.Client.Disconnect(true);
            UdpClient.Client = null;
            UdpClient.Close();
            UdpClient = null;
        }

    }
}