namespace 进阶.特殊语法;

/// <summary>
/// 初始化 - 不通过构造函数进行初始化
/// </summary>
public class Init
{
    [Fact(DisplayName = "初始化 - 不通过构造函数进行初始化")]
    public void Test1()
    {
        //申明对象时，可以直接在大括号中初始化公共成员变量和属性
        Person person1 = new Person() { sex = true, Age = 18, name = "HeroP" };
        //括号() 可以省略不写
        Person person2 = new Person { Age = 18 };
    }

    [Fact(DisplayName = "初始化 - 数组/集合/字典 通过 {} 添加元素")]
    public void Test2()
    {
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        Dictionary<int, string> dict = new Dictionary<int, string>() { { 1, "ABC" }, { 2, "DEF" } };
    }

    [Fact(DisplayName = "初始化 - 匿名类型")]
    public void Test3()
    {
        //声明一个匿名类型，只能有变量不能有函数
        var v = new { age = 10, money = 11, name = "小明" };
        Console.WriteLine(v.age);
    }
}

class Person
{
    private int money;
    public bool sex;

    public string name { get; set; }
    public int Age { get; set; }
}