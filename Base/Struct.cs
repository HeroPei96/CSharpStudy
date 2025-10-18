using Xunit.Abstractions;

namespace 基础;

/// <summary>
/// 结构体
/// </summary>
public class Struct : MyBasePrintClass
{
    public Struct(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "结构体的基本使用")]
    public void Test1()
    {
        Student s1 = new Student(10, true, "Red");
        output.WriteLine($@"Red number: {s1.getNumber()}");
    }
}

struct Student
{
    //结构体中，成员变量不能直接初始化
    //变量类型 可以写任意类型 包括其他类型的结构体 “但是不能是当前结构体”
    int age;
    bool sex;
    int number;

    string name;
    //变量类型不能为 当前自己的结构体
    //Student stu; //会报错

    //构造函数
    //如果声明了构造函数，那么必须在其中对所有的变量进行初始化
    public Student(int age, bool sex, string name)
    {
        this.age = age;
        this.sex = sex;
        this.name = name;
        //如果声明了构造函数，那么必须在其中对所有的变量进行初始化
        this.number = new Random().Next(0, 100);
    }

    //成员函数（同类）
    public int getNumber()
    {
        return number;
    }
}