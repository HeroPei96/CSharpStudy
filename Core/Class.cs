using Xunit;
using Xunit.Abstractions;

namespace 核心;

/// <summary>
/// 面向对象
/// </summary>
public class Class : MyBasePrintClass
{
    public Class(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "属性测试")]
    public void Test1()
    {
        Person p = new Person(18, "HeroP");
        //相当于调用属性的 get
        output.WriteLine(p.Name);

        //相当于调用属性的 set
        // p.Name = "ABC";
        // output.WriteLine(p.Name);
    }
}

public class Person
{
    private int age;
    private string name;

    //属性
    //命名规范：帕斯卡命名法，开头要大写
    //属性外部定义的访问修饰符是默认的修饰符
    public string Name
    {
        //简写方式一
        //注：如果用该简写方式，相当于一个单独的变量，无法与已有变量产生关联
        // get;
        // set;

        //简写方式二
        get => name;

        //正常写法
        //内部属性方法可以单独定义访问修饰符（不能两个都单独定义访问修饰符，外部属性上定义的一定要生效），默认同属性一致，若单独定义，那权限一定要小于属性上定义的
        private set
        {
            //value 只能用于 set 属性，表示外部传入的值
            name = value;
        }
    }

    public Person(int age)
    {
        this.age = age;
    }

    //构造函数中通过 this 关键字先调用其他构造函数
    public Person(int age, string name) : this(age)
    {
        this.name = name;
    }

    //析构函数 用于在某一对象被垃圾回收时自动调用
    //在Unity中几乎不会使用，只做了解即可
    ~Person()
    {
        Console.WriteLine("内存被回收，自动触发该析构函数");
    }
}