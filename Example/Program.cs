using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Example
{
    class Program
    {
        static void Main()
        {
            var client = new UdpClient("10.55.110.27", 8125);


            var rnd = new Random();
            for (int i = 0; i < 60; i++)
            {
                string test = "test.glork:" + rnd.Next(50) + "|c";
                var data = Encoding.Default.GetBytes(test);

                Console.WriteLine("sending : " + test);

                client.Send(data, data.Length);
                Thread.Sleep(rnd.Next(500, 3000));
            }

            client.Close();

            Console.ReadKey();
        }
    }
}
