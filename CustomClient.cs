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
        public List<string> ClientSubjects = new List<string>();
        public int ClientPort { get; set; }
        public UdpClient UdpClient { get; set; }
        IPEndPoint ipEndPoint;



        #endregion


        public CustomClient(string name)
        {
            ClientName = name;

            ClientIP = ClientHost + "." + ClientPort.ToString();

            ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            UdpClient = new UdpClient(ipEndPoint);
            UdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
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

        public void CloseConnection(IPEndPoint serverIP)
        {
            UdpClient.Client.Shutdown(SocketShutdown.Both);
            UdpClient.Client = null;
            UdpClient.Close();
            UdpClient = null;
        }

    }
}