using System.Numerics;

namespace 进阶.新版本功能;

/// <summary>
/// C# 8 新功能
/// 静态本地函数
/// Using 声明
/// Null 合并赋值
/// 解构函数 Deconstruct
/// 模式匹配增强功能
/// </summary>
public partial class EightT : MyBasePrintClass
{
    public EightT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "静态本地函数")]
    public void Test1()
    {
        int i = 10;
        Test(ref i);
        output.WriteLine($"i: {i}");

        //相对于本地函数来说，加了 static 所以不能直接访问外部非 static 的变量。从而看起来更像一个函数
        static void Test(ref int i)
        {
            i += 10;
        }
    }

    [Fact(DisplayName = "Using 声明")]
    public void Test2()
    {
        //在使用 using 语法时，必须继承System.IDisposable接口
        //相对于 using(){} 当前 "声明式" 写法会在当前语句块执行完成后释放
        using StreamWriter strem = new StreamWriter("文件路径");
        //对该变量进行逻辑处理 该变量只能在这个语句块中使用
        strem.Write(true);
        strem.Write(1.2f);
        strem.Flush();
    }

    [Fact(DisplayName = "Null 合并赋值")]
    public void Test3()
    {
        //语法: 左边值 ??= 右边值
        //如果左边为 null 才会把右边值赋值给变量
        //如果不为空，则不会有赋值操作
        string str = null;
        //如果 str 为空就执行 str = "4565";
        str ??= "4565";
        output.WriteLine(str);
    }

    //其实 C#_7 就有了
    [Fact(DisplayName = "解构函数 Deconstruct")]
    public void Test4()
    {
        //通常情况下，都是在类外部对类进行初始化赋值
        //而解构函数的作用是把类内部变量值赋值给外部变量
        //解构一般搭配元组使用
        Person p = new Person();
        p.Init();

        //注意，这里不用加 out 关键字来接收
        (string name, int age) = p;
        output.WriteLine($"name: {name}, age: {age}");
    }

    //对于所有的 模式匹配增强功能是针对表达式的，不是语句 必须要有一个具体的返回值
    [Fact(DisplayName = "模式匹配增强功能-switch")]
    public void Test5()
    {
        Vector2 pos = GetString(PosType.Bottom_Left);
        output.WriteLine($"pos: {pos}");

        //使用了 本地函数 简便写法
        Vector2 GetString(PosType posType) => posType switch
        {
            PosType.Top_Left => new Vector2(0, 0),
            PosType.Top_Right => new Vector2(1, 0),
            PosType.Bottom_Left => new Vector2(0, 1),
            PosType.Bottom_Right => new Vector2(1, 1),
            //使用弃元符号 _ 表示 default 的情况
            _ => new Vector2(0, 0),
        };
    }

    [Fact(DisplayName = "模式匹配增强功能-属性")]
    public void Test6()
    {
        Person p = new Person();
        p.Init();
        //本质上就是 p.name == xx && p.number == xx
        if (p is { number: "123123123123", name: "HeroP" })
            output.WriteLine("信息相同");
    }

    [Fact(DisplayName = "模式匹配增强功能-元组")]
    public void Test7()
    {
        float price = GetPrice("6折", true, 50);
        output.WriteLine($"打折后的价格为price: {price}");

        //使用了 本地函数 简便写法
        float GetPrice(string discount, bool isDiscount, float money) => (discount, isDiscount) switch
        {
            ("5折", true) => money * 0.5f,
            ("6折", true) => money * 0.6f,
            ("7折", true) => money * 0.7f,
            _ => money,
        };
    }

    [Fact(DisplayName = "模式匹配增强功能-位置")]
    public void Test8()
    {
        //位置模式: 就是解构函数搭配模式匹配
        Person p = new Person();
        p.Init();
        //写法要和属性模式做区分
        if (p is ("HeroP", 18))
            output.WriteLine("是本人");
    }
}

//用于 解构函数 & 模式匹配增强功能
public class Person
{
    //= null! 引用类型如果不在构造器中显示地初始化，那么IDE会进行提醒，但如果通过其他手段初始化了想要关闭提醒就可以这么做
    public string name = null!;

    //还能把 private 类型的数据给结构出来！
    private int age;
    public string number = null!;
    public string email = null!;

    public void Init()
    {
        name = "HeroP";
        age = 18;
        email = "xxxx@qq.com";
        number = "123123123123";
    }

    //解构函数的函数名为: Deconstruct
    //解构函数也可以重载，只解构对应的属性
    public void Deconstruct(out string n, out int age, out string number, out string email)
    {
        n = name;
        age = this.age;
        number = this.number;
        email = this.email;
    }

    //简便写法 搭配 => 和 元组
    public void Deconstruct(out string n, out int age)
        => (n, age) = (this.name, this.age);
}

//用于 模式匹配增强功能-switch
enum PosType
{
    Top_Left,
    Top_Right,
    Bottom_Left,
    Bottom_Right
}