namespace 进阶;

/// <summary>
/// delegate - 匿名函数
/// </summary>
public class DelegateFunc : MyBasePrintClass
{
    public DelegateFunc(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "无返回值的匿名函数")]
    public void Test1()
    {
        Action action1 = delegate() { output.WriteLine("这是一个无参无返回的匿名函数"); };

        Action<int> action2 = delegate(int value) { output.WriteLine($"这是一个有参无返回的匿名函数，参数: {value}"); };

        action1();
        action2(8);

        //delegate 可以省略
        Action action = () => { output.WriteLine("这是一个无参无返回的匿名函数"); };
    }

    [Fact(DisplayName = "有返回值的匿名函数")]
    public void Test2()
    {
        Func<string> action1 = delegate()
        {
            output.WriteLine("这是一个无参有返回的匿名函数");
            return "Hello";
        };

        Func<int, string> action2 = delegate(int value)
        {
            output.WriteLine($"这是一个有参有返回的匿名函数，参数: {value}");
            return "World";
        };

        output.WriteLine(action1());
        output.WriteLine(action2(8));
    }
}