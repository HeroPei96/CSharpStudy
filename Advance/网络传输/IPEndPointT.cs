using System.Net;

namespace 进阶.网络传输;

/// <summary>
/// 端口类
/// 表示 IP + 端口 的组合
/// </summary>
public class IPEndPointT : MyBasePrintClass
{
    public IPEndPointT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(LocalIp), 8080);
        //获取地址字符串
        WriteLine($"IP: {ipEndPoint.Address}");
        WriteLine($"Port: {ipEndPoint.Port}");
    }
}