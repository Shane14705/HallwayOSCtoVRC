using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CoreOSC;
using CoreOSC.IO;

namespace HallwayOSCtoVRC
{
    /*This class will act as a representation of the VRChat client. It will be responsible for
     
     */
    internal class VrcClient
    {

        //Connection Parameters
        private string m_address = "127.0.0.1";
        private int m_receivePort = 9001;
        private int m_sendPort = 9000;
        private bool m_listening = true;

        private string m_currentAviID = null;
        public event EventHandler AvatarUpdated;

        /*
         * Put logic for changing connections when addresses/ports are changed in these setters
         */
        public string Address
        {
            get => m_address;
            set => m_address = value;
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
            m_address = address;
            m_receivePort = receivePort;
            m_sendPort = sendPort;
        }

        //Initiates a VrcClient and connects it to the user's VRChat instance with default connection parameters
        public VrcClient()
        {
            m_address = "127.0.0.1";
            m_receivePort = 9001;
            m_sendPort = 9000;
        }

        private async void ListenLoop()
        {
            while (m_listening)
            {
                using (UdpClient client = new UdpClient(m_address, m_receivePort))
                {
                    OscMessage response = await client.ReceiveMessageAsync();

                    if (response.Address.Value == "/avatar/change")
                    {
                        m_currentAviID = (string)(response.Arguments.ElementAt(0));
                        HandleAviChange();
                    }
                }
            }
            
        }

        private async Task HandleAviChange()
        {
            throw new NotImplementedException();

            //AvatarUpdated?.Invoke(this);
        }
    }


}
