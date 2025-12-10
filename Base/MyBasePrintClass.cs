namespace 基础;

public class MyBasePrintClass
{
    protected readonly ITestOutputHelper output;

    public MyBasePrintClass(ITestOutputHelper output)
    {
        this.output = output;
    }

    #region 网络传输相关

    //本机IP
    protected string LocalIp => "127.0.0.1";

    #endregion

    #region 控制台打印输出相关

    //标记分隔符
    protected void WriteMark() => output.WriteLine("***** 分隔符 *****");

    protected void WriteLine(object msg) => output.WriteLine(msg.ToString());

    #endregion
}