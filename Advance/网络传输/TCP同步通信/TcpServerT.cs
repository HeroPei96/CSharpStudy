using System.Net;
using System.Net.Sockets;
using System.Text;

namespace 进阶.网络传输.TCP同步通信;

/// <summary>
/// 没法通过 Xunit 来模拟
/// </summary>
public class TcpServerT : MyBasePrintClass
{
    public TcpServerT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "建立服务端")]
    public void Test1()
    {
        //建立服务端
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(LocalIp), 8080);
            socket.Bind(ipPoint);
        }
        catch (Exception e)
        {
            WriteLine($"绑定出错: {e.Message}");
            return;
        }

        socket.Listen(10);
        //等待连接时会阻塞进程
        Socket connectSocket = socket.Accept();
        WriteLine("有客户端连入了");
        //向客户端发送消息
        connectSocket.Send(Encoding.UTF8.GetBytes("欢迎连入服务端"));
        //接收客户端的消息
        byte[] bytes = new byte[1024];
        int receiveBytesCount = connectSocket.Receive(bytes);
        WriteLine("接收到的客户端消息为: " + Encoding.UTF8.GetString(bytes, 0, receiveBytesCount));

        //关闭连接
        connectSocket.Shutdown(SocketShutdown.Both);
        connectSocket.Close();
    }
}