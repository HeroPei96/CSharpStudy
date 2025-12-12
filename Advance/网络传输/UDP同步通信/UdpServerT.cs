using System.Net;
using System.Net.Sockets;
using System.Text;

namespace 进阶.网络传输.UDP同步通信;

/// <summary>
/// 没法通过 Xunit 来模拟
/// </summary>
public class UdpServerT : MyBasePrintClass
{
    public UdpServerT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "建立服务端")]
    public void Test1()
    {
        //建立服务端
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
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
        //无需连接，直接指定目标并发送数据
        EndPoint remoteIpPoint = new IPEndPoint(IPAddress.Parse(LocalIp), 8081);
        socket.SendTo(Encoding.UTF8.GetBytes("8080.Send: Hello"), remoteIpPoint);
        //接收指定目标的消息
        byte[] bytes = new byte[1024];
        int receiveBytesCount = socket.ReceiveFrom(bytes, ref remoteIpPoint);
        WriteLine("8080.Receive: " + Encoding.UTF8.GetString(bytes, 0, receiveBytesCount));

        //关闭连接
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();
    }
}