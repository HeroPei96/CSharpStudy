namespace 进阶.新版本功能;

/// <summary>
/// C# 7 新功能
/// Out和Ref
/// 弃元
/// 本地函数
/// 字面值改进
/// 元组
/// 模式匹配
/// 抛出表达式
/// </summary>
public partial class SevenT : MyBasePrintClass
{
    public SevenT(ITestOutputHelper output) : base(output)
    {
    }

    //在声明数值变量时，可以在数值间插入 _ 作为分隔符，便于阅读
    [Fact(DisplayName = "字面值改进")]
    public void Test1()
    {
        int i = 9_1234_1234;
        //912341234
        output.WriteLine(i.ToString());
    }

    [Fact(DisplayName = "Out")]
    public void Test2()
    {
        //out 修饰的变量可以无需在外部声明
        Func(out int x);
        output.WriteLine($"x: {x}");
    }

    [Fact(DisplayName = "Ref")]
    public void Test3()
    {
        int x = 100;
        //通过 ref 关键字 指向同一栈空间，如果改变 x 的值则 y 也会改变
        //赋值时，两边都需要有 ref
        ref int y = ref x;
        y = 200;
        output.WriteLine($"x: {x}, y: {y}");
    }

    //弃元
    [Fact(DisplayName = "弃元")]
    public void Test4()
    {
        //因为 x 用不着所以可以用弃元符号代替
        Func(out _);
    }

    [Fact(DisplayName = "本地函数")]
    public void Test5()
    {
        int value = 8;
        test();
        output.WriteLine($"value: {value}");

        //只能在当前函数内部使用，所以不需要修饰符
        void test()
        {
            value += 10;
        }
    }

    //可以在更多的表达式中进行错误抛出
    [Fact(DisplayName = "抛出表达式")]
    public void Test6()
    {
        //1.空合并操作符后用 throw
        Assert.Throws<NullReferenceException>(() =>
        {
            output.WriteLine("空合并操作符后用 throw");
            string str = null;
            _ = str ?? throw new NullReferenceException();
        });

        //2.三目运算符后面用 throw
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            output.WriteLine("三目运算符后面用 throw");
            string str = "1,2,3";
            string[] strs = str.Split(',');
            return strs.Length > 4 ? strs[4] : throw new IndexOutOfRangeException();
        });

        //3.=> 符号后面直接 throw
        Action action = () =>
        {
            output.WriteLine("=> 符号后面直接 throw");
            throw new Exception("错了，不准用这个委托");
        };
        Assert.Throws<Exception>(action);
    }

    //元组其实就是一种特殊的变量类型
    [Fact(DisplayName = "元组")]
    public void Test7()
    {
        //1.无变量名 通过 Item 访问
        (int, float, bool) abc = (1, 5.5f, true);
        //注意不是从 0 开始
        output.WriteLine($"{abc.Item1}");
        output.WriteLine($"{abc.Item2}");
        output.WriteLine($"{abc.Item3}");

        //2.有变量名
        (int i, float f, bool b) xyz = (1, 5.5f, true);
        output.WriteLine($"{xyz.i}");
        output.WriteLine($"{xyz.f}");
        output.WriteLine($"{xyz.b}");

        //3.元组返回值
        var vars1 = GetInfo1();
        output.WriteLine($"{vars1.Item1}");

        var vars2 = GetInfo2();
        output.WriteLine($"{vars2.str}");

        (string myStr, int myI, float myF) = GetInfo2();
        output.WriteLine(myStr);

        //4.元组匹配
        //相当于 xyz.i == XX && xyz.f == XX && xyz.b == XX
        if (xyz is (1, 5.5f, true))
            output.WriteLine("元组匹配正确");

        (string, int, float) GetInfo1()
        {
            return ("123", 2, 5.5f);
        }

        (string str, int i, float f) GetInfo2()
        {
            return ("123", 2, 5.5f);
        }
    }

    [Fact(DisplayName = "模式匹配")]
    public void Test8()
    {
        //1.is
        object o = 1;
        //如果 o 是 int 类型，那么就把 o 的值 赋值给 i
        if (o is int i)
            output.WriteLine($"o 是 int, i: {i}");

        //2.switch
        o = 1.1f;
        switch (o)
        {
            case int value:
                output.WriteLine($"o 是 int, value: {value}");
                break;
            case float value:
                output.WriteLine($"o 是 float, value: {value}");
                break;
        }

        //3.var
        o = 1.1f;
        if (o is var f)
            output.WriteLine($"o 是 {f.GetType()}, f: {f}");
    }

    private void Func(out int x)
    {
        x = 10;
    }
}