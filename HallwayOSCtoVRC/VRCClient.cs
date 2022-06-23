using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Rug.Osc;

namespace HallwayOSCtoVRC
{
    /*This class will act as a representation of the VRChat client. It will be responsible for
     
     */
    internal class VrcClient
    {

        //Connection Parameters
        private IPAddress m_address;
        private int m_receivePort;
        private int m_sendPort;
        private bool m_listening = true;

        private string m_currentAviID = null;
        private Thread listenThread;
        private OscReceiver receiver;
        private OscSender sender;
        public event EventHandler AvatarUpdated;

        

        /*
         * Put logic for changing connections when addresses/ports are changed in these setters
         */
        public string Address
        {
            get => m_address.ToString();
            set => m_address = IPAddress.Parse(value);
        }

        public int ReceivePort
        {
            get => m_receivePort;
            set => m_receivePort = value;
        }

        public int SendPort
        {
            get => m_sendPort;
            set => m_sendPort = value;
        }

        //Initiates a VrcClient and connects it to the user's VRChat instance using the specified connection parameters
        public VrcClient(string address, int receivePort, int sendPort) {
            Address = address;
            ReceivePort = receivePort;
            SendPort = sendPort;

            receiver = new OscReceiver(m_address, m_receivePort);
            sender = new OscSender(m_address, m_sendPort);
            receiver.Connect();
            listenThread = new Thread(new ThreadStart(ListenLoop));
            listenThread.Start();

        }

        //Initiates a VrcClient and connects it to the user's VRChat instance with default connection parameters
        public VrcClient() : this("127.0.0.1", 9001, 9000) {}


        private void StopListening()
        {
            receiver.Close();
            listenThread.Join();
        }

        private void ListenLoop()
        {
            while (receiver.State != OscSocketState.Closed)
            {
                if (receiver.State == OscSocketState.Connected)
                {
                    OscPacket packet = receiver.Receive();
                    Console.WriteLine(packet.ToString());
                }
            }
            
        }

        private async Task HandleAviChange()
        {
            throw new NotImplementedException();

            //AvatarUpdated?.Invoke(this);
        }

        ~VrcClient()
        {
            StopListening();
        }
    }


}
