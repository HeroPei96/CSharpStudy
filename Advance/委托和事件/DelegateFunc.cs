namespace 进阶.委托和事件;

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

    /// <summary>
    /// 委托/事件中的一种特殊情景，委托中函数用了外部的变量
    /// 之后委托执行时，这个变量的值为外部函数中的最终值（即使是值类型变量也是这种情况，相当于有了引用）
    /// </summary>
    [Fact(DisplayName = "闭包")]
    public void Test3()
    {
        Action action = DoSomething();
        action();
    }

    public Action DoSomething()
    {
        Action action = null;
        //变量 value 和 i 形成了闭包，此时它们的生命周期发生了变化（可以理解为值类型也有了引用）
        //当委托被执行时，这些变量的值为在当前函数下的最终值
        int value = 0;
        for (int i = 0; i < 5; i++)
        {
            action += () => { output.WriteLine($"i: {i}, value: {value}"); };
        }

        value = 10;
        return action;
    }
}