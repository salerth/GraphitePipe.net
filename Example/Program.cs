using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("", 8080);
            //UdpClient client = new UdpClient("", 8125);


            Random rnd = new Random();
            for (int i = 0; i < 60; i++ )
            {
                string test = "stats.test.qhs.cisqhsblah.glork:" + rnd.Next(50) + "|c";

                client.GetStream().Write(Encoding.ASCII.GetBytes(test), 0, Encoding.ASCII.GetByteCount(test));
                //client.Send();
                Thread.Sleep(rnd.Next(500, 3000));
            }

            client.Close();

            Console.ReadKey();
        }
    }
}
