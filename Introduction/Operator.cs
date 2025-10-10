using Xunit.Abstractions;

namespace 入门;

/// <summary>
/// 运算符
/// </summary>
public class Operator : MyBasePrintClass
{
    public Operator(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// 连接两个数值进行位计算 将数值转为二进制
    /// 有 0 则 0
    /// </summary>
    [Fact(DisplayName = "位运算符 &")]
    public void Test1()
    {
        //001
        int a = 1;
        //101
        int b = 5;
        //001 = 1 &
        //101 = 5
        //001 = 1
        int c = a & b;
        output.WriteLine(c.ToString());
    }

    /// <summary>
    /// 连接两个数值进行位计算 将数值转为二进制
    /// 有 1 则 1
    /// </summary>
    [Fact(DisplayName = "位运算符 |")]
    public void Test2()
    {
        //001
        int a = 1;
        //101
        int b = 5;
        //001 = 1 |
        //101 = 5
        //101 = 5
        int c = a | b;
        output.WriteLine(c.ToString());
    }

    /// <summary>
    /// 连接两个数值进行位计算 将数值转为二进制
    /// 相同为 0 不同 为 1
    /// </summary>
    [Fact(DisplayName = "位运算符 ^")]
    public void Test3()
    {
        //001
        int a = 1;
        //101
        int b = 5;
        //001 = 1 ^
        //101 = 5
        //100 = 4
        int c = a ^ b;
        output.WriteLine(c.ToString());
    }

    /// <summary>
    /// 写在数值前 将数值转为二进制 并取反
    /// 注意与其他运算符不同的是，省略的填充 0 也要取反
    /// </summary>
    [Fact(DisplayName = "位运算符 ~")]
    public void Test4()
    {
        //int 4 个字节 4*8 = 32 位
        //00000000 00000000 00000000 00000101 ~
        //11111111 11111111 11111111 11111010
        //涉及到计算机底层中的反码和补码，最终结果可能与所想不同
        int b = ~5;
        output.WriteLine(b.ToString());
    }

    /// <summary>
    /// 将数值转为二进制 左移 指定位
    /// 左移几位，就在右侧加几个0
    /// </summary>
    [Fact(DisplayName = "位运算符 <<")]
    public void Test5()
    {
        //101 << 2
        //10100 = 20
        int b = 5 << 2;
        output.WriteLine(b.ToString());
    }

    /// <summary>
    /// 将数值转为二进制 右移 指定位
    /// 右移几位，就在右侧去掉几个0
    /// </summary>
    [Fact(DisplayName = "位运算符 >>")]
    public void Test6()
    {
        //101 >> 2
        //1 = 1
        int b = 5 >> 2;
        output.WriteLine(b.ToString());
    }
}