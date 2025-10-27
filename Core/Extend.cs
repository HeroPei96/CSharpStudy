using Xunit.Abstractions;

namespace 核心;

/// <summary>
/// 继承
/// </summary>
public class Extend : MyBasePrintClass
{
    public Extend(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// is 的使用
    /// is: 用于判断某个变量是否是指定类对象
    /// </summary>
    [Fact(DisplayName = "is 的使用")]
    public void Test1()
    {
        GameObject obj1 = new Player();
        GameObject obj2 = new Monster();
        output.WriteLine($"obj1是否是Player: {obj1 is Player}");
        output.WriteLine($"obj1是否是GameObject: {obj1 is GameObject}");
        output.WriteLine($"obj2是否是Player: {obj2 is Player}");
    }

    /// <summary>
    /// as 的使用
    /// as: 将一个对象转换为指定类对象，成功则返回执行类对象，失败返回 null
    /// </summary>
    [Fact(DisplayName = "as 的使用")]
    public void Test2()
    {
        GameObject obj1 = new Player();
        Player? player1 = obj1 as Player;
        Monster? player2 = obj1 as Monster;
        output.WriteLine("");
    }

    /// <summary>
    /// C#中多态需要通过 virtual 实现
    /// 注意：如果父类和子类都有定义成员变量，那么通过多态调用时用的还是父类的变量
    /// </summary>
    [Fact(DisplayName = "多态 - virtual")]
    public void Test3()
    {
        GameObject obj1 = new Player();
        GameObject obj2 = new Monster();
        //与 java 不同，多态不能直接使用，还会调用父类的方法
        output.WriteLine(obj1.GetName());

        //注意：如果父类和子类都有定义成员变量，那么通过多态调用时用的还是父类的变量
        //所以要避免在多态中使用成员变量
        output.WriteLine($"obj1.intValue: {obj1.intValue}");
        output.WriteLine("*****");
        //通过 virtual - override 关键字实现多态的使用
        output.WriteLine(obj1.GetNameV());
        output.WriteLine(obj2.GetNameV());
    }
}

class GameObject
{
    public int intValue = 10;

    public string GetName()
    {
        return "GameObject";
    }

    /// <summary>
    /// virtual - 父类通过该关键字定义为 “虚函数”
    /// 子类通过 override 重写父类
    /// </summary>
    /// <returns></returns>
    public virtual string GetNameV()
    {
        return "GameObject";
    }
}

/// <summary>
/// sealed 密封类，让类无法再被继承
/// </summary>
sealed class Player : GameObject
{
    public int intValue = 20;

    //默认通过 base 调用父类午无参构造函数
    //可以通过 base传参 调用父类重载的构造函数
    public Player() : base()
    {
    }

    public void PlayerAtk()
    {
        Console.WriteLine("玩家攻击");
    }

    public string GetName()
    {
        return "Player";
    }

    public override string GetNameV()
    {
        return "Player";
    }
}

class Monster : GameObject
{
    public void MonsterAtk()
    {
        Console.WriteLine("怪物攻击");
    }

    public string GetName()
    {
        return "Monster";
    }

    /// <summary>
    /// sealed 密封方法
    /// 配合 override 使用，用于表示该方法无法再继续被 因继承而重写
    /// </summary>
    public sealed override string GetNameV()
    {
        return "Monster";
    }
}