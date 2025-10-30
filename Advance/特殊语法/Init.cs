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
}

class Person
{
    private int money;
    public bool sex;

    public string name { get; set; }
    public int Age { get; set; }
}