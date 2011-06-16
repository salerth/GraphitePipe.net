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
            UdpClient client = new UdpClient("", 8125);

            string test = "system.glork:320|ms";

            Random rnd = new Random();
            while (true)
            {
                client.Send(Encoding.ASCII.GetBytes(test), Encoding.ASCII.GetByteCount(test));
                Thread.Sleep(rnd.Next(500, 3000));
            }

            client.Close();

            Console.ReadKey();
        }
    }
}
