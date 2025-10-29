namespace 进阶.反射;

/// <summary>
/// Activator
/// 用于快速实例化对象的类，将 Type 对象快捷实例化为对象
/// </summary>
public class ActivatorT : MyBasePrintClass
{
    public ActivatorT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        Type type = typeof(TestType);
        //快捷调用无参构造函数
        TestType? obj = Activator.CreateInstance(type) as TestType;
        output.WriteLine($"obj.j: {obj.j}");

        //调用有参构造函数
        obj = Activator.CreateInstance(type, 5, 8, "HeroP") as TestType;
        output.WriteLine($"obj.str: {obj.str}");
    }
}