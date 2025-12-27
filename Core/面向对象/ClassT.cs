namespace 核心.面向对象.类;

/// <summary>
/// 类
/// </summary>
public class ClassT : MyBasePrintClass
{
    public ClassT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "属性测试")]
    public void Test1()
    {
        Person p = new Person(18, "HeroP");
        //相当于调用属性的 get
        WriteLine(p.Name);

        //相当于调用属性的 set
        // p.Name = "ABC";
        // WriteLine(p.Name);
    }

    // 常用于数组对象，也可用于选择器，例如get中自定义switch选择
    [Fact(DisplayName = "索引器")]
    public void Test2()
    {
        Person p = new Person(18, "HeroP");
        p[0] = new Person(10, "ABC");
        WriteLine(p[0].Name);
    }

    /// <summary>
    /// 拓展方法
    /// </summary>
    [Fact(DisplayName = "拓展方法")]
    public void Test3()
    {
        Person p = new Person(18, "HeroP");
        p.Name = "ABC";
        WriteLine(p.SpeakValue());

        string str = "Test";
        WriteLine(str.SpeakValue("QWE"));
    }

    [Fact(DisplayName = "分布类")]
    public void Test4()
    {
        Student student = new Student();
        student.sex = false;
        student.name = "HeroP";
        student.number = 1;
        student.Speak("哈哈哈");
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
        //简写方式一，无法关联成员变量
        // get;
        // set;

        //简写方式二
        get => name;

        //正常写法
        //内部属性方法可以单独定义访问修饰符，若单独定义，那权限一定要小于属性上定义的，例 private set
        //value 表示外部传入的值
        set => name = value;
    }

    private Person[] friends = new Person[5];

    //索引器
    //此处可以有多个参数，可以重载，例如 this[int param1, int param2]（二维数组）
    public Person this[int index]
    {
        get => friends[index];
        set => friends[index] = value;
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
    ~Person() => Console.WriteLine("内存被回收，自动触发该析构函数");
}

/// <summary>
/// 拓展方法
/// 为现有的 “非静态类” 添加新方法
/// 拓展方法一定要写在新的自定义 “静态类” 中
/// 新的拓展方法一定是一个 “静态函数”
/// “第一个参数”为拓展目标，并用 “this” 修饰
/// 注意：即使对象为 null 也能调用拓展方法，因为对象实例只是作为第一个参数传入
/// </summary>
static class PersonTools
{
    //为 Person 拓展的一个方法
    public static string SpeakValue(this Person value)
    {
        return value.Name + "拓展的方法";
    }

    //为 string 拓展的一个方法
    public static string SpeakValue(this string value, string param)
    {
        return "打印：" + value + "，" + param;
    }
}

/// <summary>
/// 分布类 关键字 partial
/// 分部类可以写在多个脚本文件中
/// 分部类的访问修饰符要一致
/// 分部类中不能有重复成员
/// </summary>
partial class Student
{
    public bool sex;
    public string name;
}

partial class Student
{
    public int number;

    public void Speak(string str)
    {
    }
}