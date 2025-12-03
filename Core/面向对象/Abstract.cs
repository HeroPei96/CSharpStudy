namespace 核心.抽象类和抽象方法;

/// <summary>
/// 抽象类和抽象方法 - Abstract
/// </summary>
public class Abstract : MyBasePrintClass
{
    public Abstract(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "抽象类和抽象方法 - 基本使用")]
    public void Test1()
    {
        Thing t1 = new Food();
        //注意：不要在抽象类中声明成员变量。通过多态使用是用的是抽象类的成员变量
        output.WriteLine(t1.name);
        output.WriteLine(t1.GetName());
    }
}

/// <summary>
/// abstract 声明的类是抽象类
/// 抽象类无法被实例化(new)（无法直接实例化）
/// </summary>
abstract class Thing
{
    //抽象类中定义变量没有意义
    //因为抽象类无法被实例化必须通过多态调用，会导致子类使用时却用的是父类的成员变量
    public string name = "Thing";

    /// <summary>
    /// 抽象方法只存在于抽象类中，只有先定义 abstract 抽象类才能声明 抽象方法
    /// 没有方法体
    /// 方法不能是私有的(private)
    /// 继承的子类必须实现(Override重写)
    /// </summary>
    public abstract string GetName();

    //虚方法必须有方法体，可以不被重写
    public virtual string GetNameV()
    {
        return name;
    }
}

class Food : Thing
{
    public string name = "Food";

    public override string GetName()
    {
        return name;
    }
}