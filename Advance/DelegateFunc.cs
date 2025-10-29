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
        //这种即为 lambda 表达式
        Action action1L = () => { output.WriteLine("这是一个无参无返回的匿名函数"); };
        //参数类型都可以省略，只需与委托或事件容器一致即可
        Action<int> action2L = (int value) => { output.WriteLine($"这是一个有参无返回的匿名函数，参数: {value}"); };
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

        Func<int, string> actionL2 = value =>
        {
            output.WriteLine($"这是一个有参有返回的匿名函数，参数: {value}");
            return "World";
        };
    }
}