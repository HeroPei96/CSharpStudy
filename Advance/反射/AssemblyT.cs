using System.Reflection;

namespace 进阶.反射;

/// <summary>
/// Assembly - 程序集类
/// 用来加载其他程序集，加载后才能通过 Type 来使用其他程序集中的类 
/// </summary>
public class AssemblyT : MyBasePrintClass
{
    public AssemblyT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "通过文件路径加载程序集")]
    public void Test1()
    {
        //Assembly assembly1 = Assembly.LoadFrom("包含程序集清单的文件的名称或路径");

        Assembly assembly = Assembly.LoadFrom(@"D:\workSpace\CSharp\CSharpStudy\Advance\bin\Debug\net7.0\Advance.dll");
        Type[] types = assembly.GetTypes();
        foreach (Type item in types)
        {
            WriteLine($"type: {item.FullName}");
        }

        //获取 Type
        Type? type = assembly.GetType("进阶.反射.TestType");
    }

    /// <summary>
    /// 它和 LoadFrom() 的不同之处在于 LoadFile() 不会加载目标程序集所引用和依赖的其他程序集
    /// </summary>
    [Fact(DisplayName = "通过文件路径加载程序集")]
    public void Test2()
    {
        //Assembly assembly2 = Assembly.LoadFile("要加载的文件的完全限定路径");
    }
}