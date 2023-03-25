using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        private const int listenPort = 50000;
        static void Main(string[] args)
        {
            bool done = false;
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            string data_recieved;
            byte[] recieve_byte_array;
            try
            {
                while (!done)
                {
                    //Console.WriteLine("Waiting for broadcast");
                    recieve_byte_array = listener.Receive(ref groupEP);
                    //Console.WriteLine("Received broadcast from {0} :", groupEP.ToString());
                    data_recieved = Encoding.ASCII.GetString(recieve_byte_array, 0, recieve_byte_array.Length);
                    Console.WriteLine(data_recieved);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
