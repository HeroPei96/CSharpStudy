using System.Net;
using System.Net.Sockets;

namespace 进阶.网络传输;

/// <summary>
/// Socket
/// </summary>
public class SocketT : MyBasePrintClass
{
    public SocketT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        // Socket s = new Socket()
        // 参数一：AddressFamily 网络寻址 枚举类型，决定寻址方案
        //   常用：
        //   1.InterNetwork  IPv4寻址
        //   2.InterNetwork6 IPv6寻址
        // 参数二：SocketType socket枚举类型，决定使用的socket类型
        //   常用：
        //   1.Dgram         支持数据报，最大长度固定的无连接、不可靠的消息(主要用于UDP通信)
        //   2.Stream        支持可靠、双向、基于连接的字节流（主要用于TCP通信）
        // 参数三：ProtocolType 协议类型枚举类型，决定socket使用的通信协议
        //   常用：
        //   1.TCP           TCP传输控制协议
        //   2.UDP           UDP用户数据报协议
    }

    [Fact(DisplayName = "TCP_Socket")]
    public void Test2()
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    [Fact(DisplayName = "UDP_Socket")]
    public void Test3()
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    }

    [Fact(DisplayName = "常用属性")]
    public void Test4()
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //1.socket的连接状态
        if (socket.Connected)
        {
        }

        //2.获取socket的类型
        WriteLine(socket.SocketType);
        //3.获取socket的协议类型
        WriteLine(socket.ProtocolType);
        //4.获取socket的寻址方案
        WriteLine(socket.AddressFamily);
        //5.从网络中获取准备读取的数据数据量
        WriteLine(socket.Available);

        //6.获取本机EndPoint对象(注意 ：IPEndPoint继承EndPoint)
        IPEndPoint localEndPoint = socket.LocalEndPoint as IPEndPoint;

        //7.获取远程EndPoint对象
        IPEndPoint remoteEndPoint = socket.RemoteEndPoint as IPEndPoint;
    }

    [Fact(DisplayName = "常用方法")]
    public void Test5()
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //1.主要用于服务端
        //  1-1:绑定 IP 和 端口
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(LocalIp), 8080);
        socket.Bind(ipPoint);
        //  1-2:设置客户端连接的最大数量
        socket.Listen(10);
        //  1-3:等待客户端连入
        socket.Accept();

        //2.主要用于客户端
        //  2-1:连接远程服务端
        socket.Connect(IPAddress.Parse("118.12.123.11"), 8080);

        //3.客户端服务端都会用的
        //  3-1:同步发送和接收数据
        socket.Send(new byte[1024]);
        socket.Receive(new byte[1024]);
        //  3-2:异步发送和接收数据
        // socket.SendAsync();
        // socket.ReceiveAsync();
        //  3-3:释放连接并关闭Socket，先与Close调用
        socket.Shutdown(SocketShutdown.Both);
        //  3-4:关闭连接，释放所有Socket关联资源
        socket.Close();
    }
}