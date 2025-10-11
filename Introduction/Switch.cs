using Xunit.Abstractions;

namespace 入门;

public class Switch : MyBasePrintClass
{
    public Switch(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基础语法")]
    public void Test1()
    {
        //case 内必须为 常量
        //字符串常量也是常量
        string str = "abc";
        switch (str)
        {
            case "123":
                output.WriteLine("case: 123");
                break;
            case "456":
                output.WriteLine("case: 456");
                break;
            case "abc":
                output.WriteLine("case: abc");
                break;
            default:
                output.WriteLine("case: default");
                break;
        }
    }
}