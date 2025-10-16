using Xunit.Abstractions;

namespace 基础;

/// <summary>
/// 枚举
/// “整型常量” 的集合
/// </summary>
public class EnumType : MyBasePrintClass
{
    public EnumType(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基础使用")]
    public void Test1()
    {
        E_MyEnum e1 = E_MyEnum.A;
        //A
        output.WriteLine(e1.ToString());
    }

    [Fact(DisplayName = "枚举相关类型转换")]
    public void Test2()
    {
        E_MyEnum e1 = E_MyEnum.D;
        //通过强制转换直接转换为整型
        output.WriteLine(((int)e1).ToString());

        //整型转枚举
        E_MyEnum e2 = (E_MyEnum)6;
        output.WriteLine(e2.ToString());

        //字符串转枚举
        //通过 Enum.Parse 强制转换
        E_MyEnum e3 = (E_MyEnum)Enum.Parse(typeof(E_MyEnum), "A");
        output.WriteLine(e3.ToString());
    }
}

/// <summary>
/// 枚举值默认从 0 开始
/// 如果前面的枚举定义了整型值 Normal = 100，那么后面新增的枚举整型值也会从当前值递增 1
/// </summary>
enum E_MyEnum
{
    A = 5,
    B, //6
    C = 100,
    D //101
}