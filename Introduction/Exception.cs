using Xunit.Abstractions;

namespace 入门;

public class Exception : MyBasePrintClass
{
    public Exception(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本语法")]
    public void Test1()
    {
        try
        {
            int v1 = Convert.ToInt32("12.3");
        }
        catch
        {
            output.WriteLine("出错了");
        }
        finally
        {
            output.WriteLine("执行完毕");
        }
    }
}