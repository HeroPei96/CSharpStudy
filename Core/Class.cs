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
}

public class Person
{
    private int age;
    private string name;

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