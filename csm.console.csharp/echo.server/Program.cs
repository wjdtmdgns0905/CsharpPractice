using System.Net;
using System.Net.Sockets;
using System.Text;

namespace echo.server
{
    internal class Program
    {
        static void Main(string[] args)
        {


            s_blackList.Add(IPAddress.Parse("192.168.0.19"));
            // using -> Dispose 메서드의 호출을 보장
            // 1. 소켓 파일 생성
            using Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // IPAdress.Any -> 와일드카드. 0.0.0.0
            // 두 번째 파라미터 = 포트번호. Well Known Port 피해서 사용
            // 2. 소켓 주소(소켓 주소)를 소켓에 바인딩한다.
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 12345); // 0.0.0.0:12345
            server.Bind(serverEndPoint);

            // --Closed

            // 3. 클라이언트의 접속을 대기한다.
            server.Listen();
            Console.WriteLine("Server Started");

            // --Listen

            // 3way Handshake가 끝난 후 Accept()가 종료된다.
            // server.Accept는 세션을 반환한다.(Socket 타입)
            // 4. 클라이언트의 연결을 수락한다.

            while (true)
            {
                try
                {
                    using Socket session = server.Accept();

                    if (IsBlackList(session.RemoteEndPoint as IPEndPoint))
                    {
                        Console.WriteLine($"{session.RemoteEndPoint} blocked");
                    }

                    Console.WriteLine("Connected established");

                    // 5. 클라이언트로부터 데이터를 받는다.
                    // 5-1. 메세지를 수신받을 byte[] 버퍼를 생성한다.
                    byte[] buffer = new byte[1_024];

                    while (true)
                    {

                        int receviedBytes = session.Receive(buffer);  // 클라이언트로부터 어떤 메세지가 있을 때 buffer 에 복사된다.
                                                                      // buffer 저장된 데이터는 UTF-8 문자열
                                                                     
                        if(receviedBytes == 0) // 연결종료
                        {
                            break;
                        }

                        string message = Encoding.UTF8.GetString(buffer, 0, receviedBytes);

                      
                        Console.WriteLine($"[Recieved] : {message}");

                        // Span : 연속된 메모리의 부분, 읽기 전용
                        // 6. 클라이언트에게 에코잉한다.
                        session.Send(new ReadOnlySpan<byte>(buffer, 0, receviedBytes));
                    }
                    Console.WriteLine($"[Recieved] : End");
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"Error : {e}");
                }
            }
            // 가변 객체보다 불변 객체를 선호하라
            // 가변 객체에서 버그가 발생하기에.
            // 불변 객체를 이용하면 그 부분에서 버그가 일어날 확률이 없음.
        }

        static List<IPAddress> s_blackList = new List<IPAddress>();

        static bool IsBlackList(IPEndPoint remoteEndPoint)
        {
            foreach (IPAddress ip in s_blackList)
            {
                if (ip.Address.Equals(remoteEndPoint))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }

}
