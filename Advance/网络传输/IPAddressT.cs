using System.Net;

namespace 进阶.网络传输;

/// <summary>
/// IP地址类
/// </summary>
public class IPAddressT : MyBasePrintClass
{
    public IPAddressT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        IPAddress ipAddress = IPAddress.Parse(LocalIp);
        //获取地址字符串
        WriteLine(ipAddress.ToString());
    }
}