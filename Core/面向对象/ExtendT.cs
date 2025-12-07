namespace 核心.面向对象.继承;

/// <summary>
/// 继承
/// </summary>
public class ExtendT : MyBasePrintClass
{
    public ExtendT(ITestOutputHelper output) : base(output)
    {
    }

    // is: 用于判断某个变量是否是指定类对象
    [Fact(DisplayName = "is 的使用")]
    public void Test1()
    {
        GameObject obj = new Player();
        WriteLine($"obj1是否是Player: {obj is Player}");
        WriteLine($"obj1是否是GameObject: {obj is GameObject}");
    }

    // as: 将一个对象转换为指定类对象，成功则返回执行类对象，失败返回 null
    [Fact(DisplayName = "as 的使用")]
    public void Test2()
    {
        GameObject obj1 = new Player();
        Player? player1 = obj1 as Player;
        Monster? player2 = obj1 as Monster;
        WriteLine($"player1 是否为空: {player1 is null}");
        WriteLine($"player2 是否为空: {player2 is null}");
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
        WriteLine(obj1.GetName());

        //多态调用应避免使用成员变量
        WriteLine($"obj1.intValue: {obj1.intValue}");
        WriteMark();
        //通过 virtual - override 关键字实现多态的使用
        WriteLine(obj1.GetNameV());
        WriteLine(obj2.GetNameV());
    }
}

class GameObject
{
    //注意，父类定义的成员变量子类最好不要定义，因为成员变量无法被 Override 修饰。多态调用时会有问题
    public int intValue = 10;

    public string GetName() => "GameObject";

    //virtual - 父类通过该关键字定义为 “虚函数”，子类通过 override 重写父类中的虚函数
    public virtual string GetNameV() => "GameObject";
}

/// <summary>
/// sealed 密封类，让类无法再被继承
/// 如果配合多态使用，那么继承类都推荐使用 sealed 标识。原因：当通过多态调用虚方法时，底层会去查询虚方法表。会导致一个简单的函数调用性能可能有十倍之差
/// </summary>
sealed class Player : GameObject
{
    public int intValue = 20;

    //默认通过 base 调用父类午无参构造函数
    //可以通过 base传参 调用父类重载的构造函数
    public Player() : base()
    {
    }

    public string GetName() => "Player";

    public override string GetNameV() => "Player";
}

class Monster : GameObject
{
    public string GetName() => "Monster";

    //sealed 密封方法，配合 override 使用，表示该方法无法因再被继承而重写
    //如果不是密封类，单独一个密封方法必须配合 Override
    public sealed override string GetNameV() => "Monster";
}