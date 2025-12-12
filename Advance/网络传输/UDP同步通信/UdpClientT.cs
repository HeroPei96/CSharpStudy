using System.Net;
using System.Net.Sockets;
using System.Text;

namespace 进阶.网络传输.UDP同步通信;

/// <summary>
/// 没法通过 Xunit 来模拟
/// </summary>
public class UdpClientT : MyBasePrintClass
{
    public UdpClientT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "建立客户端")]
    public void Test1()
    {
        //与服务端建立连接
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(LocalIp), 8081);
            socket.Bind(ipPoint);
        }
        catch (Exception e)
        {
            WriteLine($"绑定出错: {e.Message}");
            return;
        }

        //无需连接，直接指定目标并接受数据
        EndPoint remoteIpPoint = new IPEndPoint(IPAddress.Parse(LocalIp), 8080);//接收指定目标的消息
        byte[] bytes = new byte[1024];
        int receiveBytesCount = socket.ReceiveFrom(bytes, ref remoteIpPoint);
        WriteLine("8081.Receive: " + Encoding.UTF8.GetString(bytes, 0, receiveBytesCount));
        socket.SendTo(Encoding.UTF8.GetBytes("8081.Send: Hello"), remoteIpPoint);
        


        //关闭连接
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();
    }
}