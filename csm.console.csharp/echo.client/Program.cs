using System.Net;
using System.Net.Sockets;
using System.Text;

namespace echo.client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. 소켓 생성
            using Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2. 연결 

            IPAddress adress = IPAddress.Parse("192.168.0.35");

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 12345);
            client.Connect(serverEndPoint);


            Console.WriteLine($"Server[{serverEndPoint.Address}] connected.");

            byte[] buffer = new byte[1_024];

            try
            {
                while (true)
                {

                    Console.Write("> ");
                    string message = Console.ReadLine();

                    if(message == "<End>")
                    {
                        client.Close();
                        break;
                    }

                    // 콘솔 입력
                    buffer = Encoding.UTF8.GetBytes(message);
                    client.Send(buffer);

                    // 서버로부터 에코잉 된 메세지 수신
                    int receiveBytes = client.Receive(buffer);
                    message = Encoding.UTF8.GetString(buffer, 0, receiveBytes);
                    Console.WriteLine($"[FromServer] : {message}");

                }
            }
            catch(SocketException e)
            {
                Console.WriteLine($"Error : {e}");

            }  
        }

        
    }
}
