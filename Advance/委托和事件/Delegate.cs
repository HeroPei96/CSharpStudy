namespace 进阶.委托和事件;

/// <summary>
/// 委托
/// 函数的容器，用于装载函数 
/// 语法: 访问修饰符 delegate 返回值 委托名(参数列表);
/// 声明处: namespace中 或 class语句块内
/// 委托“不能重载”，所以不能同名
/// 委托可以为空，此时通过运算符 +/- 存储函数时“不会报错”
/// </summary>
public class Delegate : MyBasePrintClass
{
    public Delegate(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "无参无返回委托的定义和使用")]
    public void Test1()
    {
        //用委托装载了一个函数
        MyFun1 myFun = new MyFun1(Fun1);
        myFun.Invoke();

        //简化写法
        MyFun1 myFunNew = Fun1;
        myFunNew();
    }

    [Fact(DisplayName = "有参有返回委托的定义和使用")]
    public void Test2()
    {
        MyFun2 myFun = Fun2;
        int result = myFun.Invoke(5);
        WriteLine($"result: {result}");
    }

    //通过 + 或 += 使委托可以存储多个函数
    [Fact(DisplayName = "委托存储多个函数")]
    public void Test3()
    {
        MyFun1 myFun = null;
        //委托可以为空，此时通过运算符 +/- 存储函数时“不会报错”
        myFun += Fun1;
        myFun += Fun1;
        myFun.Invoke();
        WriteMark();
        //多 - 不会报错
        myFun -= Fun1;
        myFun.Invoke();
    }

    [Fact(DisplayName = "C#系统定义好的委托")]
    public void Test4()
    {
        //无参无返回值
        Action action1 = null;

        //参数泛型约束无返回值委托，最多16个
        Action<int, string> action2 = null;

        //返回值泛型约束无参委托 这个例子的返回值为 String
        Func<string> funcString = null;

        //前 n 个是参数泛型，最后一个是返回值泛型
        Func<string, int, string> func = null;
    }

    [Fact(DisplayName = "循环执行委托内的函数")]
    public void Test5()
    {
        Func<string> func = null;
        func += () => { return "hello"; };
        func += () => { return "world"; };
        func += () => { return "HeroP"; };

        //注意 item 类型需要手动替换
        foreach (Func<string> item in func.GetInvocationList())
        {
            WriteLine(item());
        }
    }

    public void Fun1()
    {
        WriteLine("Fun1 执行了");
    }

    public int Fun2(int value)
    {
        WriteLine($"Fun2 执行了, 参数: {value}");
        return value * 2;
    }
}

//无参无返回的委托
public delegate void MyFun1();

//有参有返回的委托
public delegate int MyFun2(int v1);