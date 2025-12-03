namespace 核心.万物之父_object;

/// <summary>
/// 万物之父 - object/Object
/// 装箱拆箱
/// </summary>
public class ObjectS : MyBasePrintClass
{
    public ObjectS(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// object/Object，本质是一个东西 object 是别名关键字
    /// </summary>
    [Fact(DisplayName = "万物之父-object")]
    public void Test1()
    {
        object o = "HeroP";
        string? str = o as string;
        output.WriteLine($"str: {str}");
    }

    /// <summary>
    /// 值类型 和 object之间才会发生装箱和拆箱
    /// 装箱：栈 -> 堆
    /// 拆箱：堆 -> 栈
    /// </summary>
    [Fact(DisplayName = "装箱拆箱")]
    public void Test2()
    {
        //装箱
        object o1 = 1f;
        //拆箱
        float f1 = (float)o1;
    }
}