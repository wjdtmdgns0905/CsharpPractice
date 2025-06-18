using System.Net;
using System.Net.Sockets;
using System.Text;

namespace udp.server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using UdpClient udpClient = new UdpClient(12345);
            IPEndPoint listenEnpPoint = new IPEndPoint(IPAddress.Any, 12345);


            Console.WriteLine("Server Started.");

            while (true)
            {
                try
                {
                    byte[] datagram = udpClient.Receive(ref listenEnpPoint);
                    Console.WriteLine($"{listenEnpPoint} : {Encoding.UTF8.GetString(datagram)}");
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"[Error] : {e.Message}");
                }
            }
        }
    }
}
