using System.Text;

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
        Student s1 = new Student(10, true);
        output.WriteLine($"Red number: {s1.GetNumber()}");
    }

    [Fact(DisplayName = "结构体值类型和引用类型的存储")]
    public void Test2()
    {
        Student s1 = new Student(10, true);
        List<string> nameList = new List<string>() { "Red" };
        s1.nameList = nameList;

        Student s2 = s1;
        //对于值类型，采用的是值拷贝
        s2.age = 20;
        //对于引用类型，赋值为引用地址，所以本质上是同一个引用
        s2.nameList.Add("Blue");
        output.WriteLine($"s1.age: {s1.age}, s1.nameListStr: {s1.GetNameListStr()}");
    }
}

/// <summary>
/// 结构体
/// 结构体是 “值类型” 不是 引用类型
/// 结构体不支持 继承 和 多态（但是可以继承接口）
/// </summary>
struct Student
{
    //结构体中，成员变量不能直接初始化
    //变量类型 可以写任意类型 包括其他类型的结构体 “但是不能是当前结构体”
    public int age;
    public bool sex;
    public int number;

    public List<string> nameList;
    //变量类型不能为 当前自己的结构体
    //Student stu; //会报错

    //构造函数
    //如果声明了构造函数，那么必须在其中对所有的变量进行初始化
    public Student(int age, bool sex)
    {
        this.age = age;
        this.sex = sex;
        //如果声明了构造函数，那么必须在其中对所有的变量进行初始化
        this.number = new Random().Next(0, 100);
    }

    //成员函数（同类）
    public int GetNumber()
    {
        return number;
    }

    public string GetNameListStr()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string item in nameList)
        {
            sb.Append(item + " ");
        }

        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }
}