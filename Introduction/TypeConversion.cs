using Xunit.Abstractions;

namespace 入门;

/// <summary>
/// 类型转换
/// </summary>
public class TypeConversion : MyBasePrintClass
{
    public TypeConversion(ITestOutputHelper output) : base(output)
    {
    }

    //小类型自动转换为大类型
    //隐式转换只能在 数值型基本类型 中进行，字符和字符串之间无法进行
    [Fact(DisplayName = "隐式转换")]
    public void Test1()
    {
        //小符号变量赋值给大变量时，会发生自动隐式转换
        long v1 = 0;
        int v2 = 1;
        v1 = v2;

        //注意，有符号不能转换为无符号的
        //但是，无符号的可以转换为更大的有符号的
        ulong v3 = 0;
        int v4 = 1;
        //v3 = v4;

        //注意，decimal 无法参与进行隐式转换
        double v5 = 1.0;
        decimal v6 = 2.0m;
        //v6 = v5;
        
        //浮点型(包括 decimal)可以装载任何 整型数值
        v5 = v1;
        
        //char 本质上存储的是一个无符号整型值，通过 Unicode 编码表示对应的字符，所以可以转换为 整型
        char v7 = '你';
        int v8 = v7;
        output.WriteLine(v8.ToString());
    }

    [Fact(DisplayName = "显示转换 - ()")]
    public void Test2()
    {
        //括号强转
        //用于高精度转换为低精度
        int v1 = 1;
        short v2 = 2;
        v2 = (short)v1;
        //不保证正确性，所以有符号可以转为无符号
        sbyte v3 = 3;
        v3 = (sbyte)v1;
        //把整型强转为字符
        char v4 = (char)v1;
    }

    /// <summary>
    /// 把字符串转为对应的类型
    /// 字符串必须能够不借助强制转换为对应类型否则报错（例如浮点字符串转整型会报错）
    /// </summary>
    [Fact(DisplayName = "显示转换 - Parse")]
    public void Test3()
    {
        int v1 = int.Parse("123");

        bool v2 = bool.Parse("true");
    }

    /// <summary>
    /// 更为强大的转换器，按要求转换指定类型
    /// </summary>
    [Fact(DisplayName = "显示转换 - Convert")]
    public void Test4()
    {
        //字符串必须能够不借助强制转换为对应类型否则报错（例如浮点字符串转整型会报错）
        int v1 = Convert.ToInt32("123");
        
        //Convert 浮点转整型会四舍五入
        int v2 = Convert.ToInt32(1.6f);
        output.WriteLine(v2.ToString());
    }
}