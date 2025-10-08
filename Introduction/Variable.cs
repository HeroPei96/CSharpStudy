using Xunit.Abstractions;

namespace 入门;

/// <summary>
/// 变量
/// </summary>
public class Variable : MyBasePrintClass
{
    public Variable(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "有符号的整形变量")]
    public void Test1()
    {
        //一个字节 2^7: -128 ~ 127
        sbyte v1 = 0;
        //两个字节 2^15: -32768~32767
        short v2 = 0;
        //四个字节 2^31 -2147483648 ~ 2147483647
        int v3 = 0;
        //八个字节 2^63
        long v4 = 0;
    }
    
    //无符号只能存正数 v >= 0
    [Fact(DisplayName = "无符号的整形变量")]
    public void Test2()
    {
        //一个字节 2^8: 0 ~ 128
        byte v1 = 0;
        //两个字节 2^16: 0~32768
        ushort v2 = 0;
        //四个字节 2^32
        uint v3 = 0;
        //八个字节 2^64
        ulong v4 = 0;
    }
    
    //根据编译器的不同，有效数字位也可能不同
    [Fact(DisplayName = "浮点数")]
    public void Test3()
    {
        //存储 7~8 位有效数字，后缀需加 f/F
        float v1 = 0.12345f;
        //存储 15~18 位有效数字
        double v2 = 0.123456789;
        
        //特殊类型 不建议使用。仅作了解
        //存储 27~28 位有效数字，后缀需加 m/M
        decimal v3 = 0.1234567891011m;
    }

    [Fact(DisplayName = "特殊类型")]
    public void Test4()
    {
        bool v1 = true;
        bool v2 = false;

        //存储单个字符，可以为中文字符
        char v3 = '我';

        //存储多个字符
        string v4 = "你好啊";
    }

    //sizeof 只能用于基础变量类型
    [Fact(DisplayName = "通过 sizeof 方法，获取基础变量类型所占内存字节大小")]
    public void Test5()
    {
        output.WriteLine("sbyte 所占内存空间: " + sizeof(sbyte) + " 字节");
        output.WriteLine("int 所占内存空间: " + sizeof(int) + " 字节");
        output.WriteLine("decimal 所占内存空间: " + sizeof(decimal) + " 字节");
    }

    [Fact(DisplayName = "变量的命名规范")]
    public void Test6()
    {
        //1.不能以数字开头
        //2.不能使用关键字命名
        //3.不能有特殊符号(下划线除外)
    }
}