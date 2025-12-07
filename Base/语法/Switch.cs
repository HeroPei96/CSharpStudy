namespace 基础.switch_语句;

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
                WriteLine("case: 123");
                break;
            case "456":
                WriteLine("case: 456");
                break;
            case "abc":
                WriteLine("case: abc");
                break;
            default:
                WriteLine("case: default");
                break;
        }
    }
}