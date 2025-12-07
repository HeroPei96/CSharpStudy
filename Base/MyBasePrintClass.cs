namespace 基础;

public class MyBasePrintClass
{
    protected readonly ITestOutputHelper output;

    public MyBasePrintClass(ITestOutputHelper output)
    {
        this.output = output;
    }

    //标记分隔符
    protected void WriteMark() => output.WriteLine("***** 分隔符 *****");

    protected void WriteLine(string msg) => output.WriteLine(msg);
}