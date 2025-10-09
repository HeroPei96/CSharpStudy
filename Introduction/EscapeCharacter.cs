using Xunit.Abstractions;

namespace 入门;

/// <summary>
/// 转义字符
/// </summary>
public class EscapeCharacter : MyBasePrintClass
{
    public EscapeCharacter(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// 固定写法
    /// \字符
    /// </summary>
    [Fact(DisplayName = "转移字符固定写法")]
    public void Test1()
    {
        //单引号
        string s1 = "phj\'s";
        output.WriteLine(s1);

        //双引号
        string s2 = "say \"Hello\"";
        output.WriteLine(s2);

        //换行
        string s3 = "Hello \n...";
        output.WriteLine(s3);

        //斜杠
        string s4 = "\\\\";
        output.WriteLine(s4);
    }

    [Fact(DisplayName = "不常用转义字符")]
    public void Test2()
    {
        //制表符 tab
        string s1 = "Hello\tWorld";
        output.WriteLine(s1);

        //光标退格 xUnit单元测试环境下输出有问题
        string s2 = "123\b45";
        output.WriteLine(s2);

        //警报音 xUnit单元测试环境下输出有问题
        string s3 = "\a";
        output.WriteLine(s3);
    }

    [Fact(DisplayName = "取消转移字符")]
    public void Test3()
    {
        //固定写法，声明字符串在双引号前 + @
        string str = @"\\";
        output.WriteLine(str);
    }
}