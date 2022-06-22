using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HallwayOSCtoVRC
{
    /*This class will act as a representation of the VRChat client. It will be responsible for
     
     */
    internal class VrcClient
    {

        private string m_address = "127.0.0.1";
        private int m_receivePort = 9001;
        private int m_sendPort = 9000;

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
    }
}
