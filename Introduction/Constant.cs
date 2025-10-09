using Xunit.Abstractions;

namespace 入门;

/// <summary>
/// 常量
/// </summary>
public class Constant : MyBasePrintClass
{
    public Constant(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// 通过关键字 const 声明，相当于 static final
    /// 常量声明时必须初始化，声明后不能被修改
    /// </summary>
    [Fact(DisplayName = "常量的声明")]
    public void Test1()
    {
        const int c1 = 10;

        // 常量声明时必须初始化
        //const int c2;
         
        // 常量声明后不可修改
        // c1 = 20;
    }
}