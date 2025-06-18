using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Udp.client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient ucpClient = new UdpClient(54401);
            ucpClient.EnableBroadcast = true;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Broadcast, 12345);


            while (true)
            {
                Console.Write(">");
                string message = Console.ReadLine();

                byte[] sendbuf = Encoding.UTF8.GetBytes(message);

                // udp 는 tcp 와 달리 연결 없이 데이터를 송수신하기 때문에
                // endpoint 를 매번 알려주어야 함
                ucpClient.Send(sendbuf, serverEndPoint);

                Console.WriteLine("Message sent to the broadcast address");
            }
        }
    }
}
