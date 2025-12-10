using System.Net;

namespace 进阶.网络传输;

/// <summary>
/// IPHostEntry - 域名类
/// 不要尝试去自己声明，这是作为某些方法的返回值返回信息
/// </summary>
public class IPHostEntryT : MyBasePrintClass
{
    public IPHostEntryT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        string hostName = Dns.GetHostName();
        WriteLine($"当前主机名: {hostName}");

        IPHostEntry ipHostEntry = Dns.GetHostEntry("www.bilibili.com");
        WriteLine($"B站主机名: {ipHostEntry.HostName}");
        foreach (IPAddress item in ipHostEntry.AddressList)
        {
            WriteLine($"IP: {item}");
        }

        WriteMark();

        foreach (string item in ipHostEntry.Aliases)
        {
            WriteLine($"主机别名: {item}");
        }
    }
}