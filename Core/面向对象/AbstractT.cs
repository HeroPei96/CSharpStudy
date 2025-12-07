namespace 核心.面向对象.抽象类和抽象方法;

/// <summary>
/// 抽象类和抽象方法 - Abstract
/// </summary>
public class AbstractT : MyBasePrintClass
{
    public AbstractT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "抽象类和抽象方法 - 基本使用")]
    public void Test1()
    {
        Thing t1 = new Food();
        //注意：不要在抽象类中声明成员变量。通过多态使用是用的是抽象类的成员变量
        WriteLine(t1.name);
        WriteLine(t1.GetName());
    }
}

/// <summary>
/// abstract 声明的类是抽象类
/// 抽象类无法被实例化(new)（无法直接实例化）
/// </summary>
abstract class Thing
{
    //抽象类中定义变量没有意义
    //多态调用，会导致使用时却用的是父类的成员变量
    public string name = "Thing";

    //抽象方法只存在于抽象类中，没有方法体，不能是私有的(private)，继承的子类必须实现
    public abstract string GetName();

    //虚方法必须有方法体，可以不被重写
    public virtual string GetNameV() => name;
}

class Food : Thing
{
    public string name = "Food";

    public override string GetName() => name;
}