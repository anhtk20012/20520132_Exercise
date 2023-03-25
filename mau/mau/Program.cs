using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            bool exception_throw = false;

            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string IP;
            IPAddress send_to_adress = IPAddress.Parse(IP = Console.ReadLine());
            IPEndPoint sending_end_point = new IPEndPoint(send_to_adress, 50000);
            Console.WriteLine("Enter the message you want to send: ");
            Console.WriteLine("Enter nothing to exit.");
            while(!done)
            {
                Console.WriteLine("Enter text to send and blank line to quit.");
                string text_to_send = Console.ReadLine();   
                if (text_to_send.Length == 0)
                {
                    done = true;
                }
                else
                {
                    byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);
                    Console.WriteLine("Send the message to the IP: {0} port: {1}", sending_end_point.Address, sending_end_point.Port);
                    try
                    {
                        sending_socket.SendTo(send_buffer, sending_end_point);
                    }
                    catch (Exception send_exception)
                    {
                        exception_throw = true;
                        Console.WriteLine("Exception {0}", send_exception);
                    }
                    if (exception_throw == false)
                    {
                        Console.WriteLine("Message has been send to the Ip Address");
                    }
                    else
                    {
                        exception_throw = false;
                        Console.WriteLine("The exception indicates the message was not send");
                    }
                }
            }
        }
    }
}
