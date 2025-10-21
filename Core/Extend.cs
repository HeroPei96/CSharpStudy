using Xunit;
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
    /// as: 将一个对象转换为指定类对象，成功则返回 true，失败返回 null
    /// </summary>
    [Fact(DisplayName = "as 的使用")]
    public void Test2()
    {
        GameObject obj1 = new Player();
        Player? player1 = obj1 as Player;
        Monster? player2 = obj1 as Monster;
        output.WriteLine("");
    }
}

class GameObject
{
}

class Player : GameObject
{
    public void PlayerAtk()
    {
        Console.WriteLine("玩家攻击");
    }
}

class Monster : GameObject
{
    public void MonsterAtk()
    {
        Console.WriteLine("怪物攻击");
    }
}