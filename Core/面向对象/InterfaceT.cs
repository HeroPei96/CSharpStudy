namespace 核心.接口;

/// <summary>
/// 接口
/// </summary>
public class InterfaceT : MyBasePrintClass
{
    public InterfaceT(ITestOutputHelper output) : base(output)
    {
    }
}

/// <summary>
/// 命名规范 帕斯卡前面加个 I
/// 只包含方法、属性、索引器、事件
/// 成员不能是私有的，默认是 public
/// 成员不能有具体实现
/// 实现接口的类实现方法不用加 override
/// 接口可以继承另一个接口
/// </summary>
interface IFly
{
    
    void Fly();

    //属性
    //注意，只能使用自动属性，如果有具体实现就违背了接口方法不能有具体实现的规则
    string Name { get; set; }

    //索引器
    int this[int index] { get; set; }

    //事件
    event Action doSomething;
}