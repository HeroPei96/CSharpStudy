using System.Net;
using System.Net.Sockets;
using System.Text;

namespace 进阶.网络传输.TCP同步通信;

/// <summary>
/// 没法通过 Xunit 来模拟
/// </summary>
public class TcpClientT : MyBasePrintClass
{
    public TcpClientT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "建立客户端")]
    public void Test1()
    {
        //与服务端建立连接
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            socket.Connect(IPAddress.Parse(LocalIp), 8080);
        }
        catch (SocketException e) when (e.SocketErrorCode == SocketError.ConnectionRefused)
        {
            WriteLine("服务器拒绝了连接");
            return;
        }
        catch (SocketException e)
        {
            WriteLine("服务器连接失败, ErrorCode: " + e.SocketErrorCode);
            return;
        }
        
        //接收服务端消息
        byte[] bytes = new byte[1024];
        int receiveBytesCount = socket.Receive(bytes);
        WriteLine("接收到的服务端消息为: " + Encoding.UTF8.GetString(bytes, 0, receiveBytesCount));
        //向服务端发送消息
        socket.Send(Encoding.UTF8.GetBytes("我是客户端"));
        
        
        //关闭连接
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();
    }
}