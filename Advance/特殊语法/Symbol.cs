namespace 进阶.特殊语法;

/// <summary>
/// 特殊语法 - 符号相关
/// </summary>
public class Symbol : MyBasePrintClass
{
    public Symbol(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "$ 字符串拼接变量")]
    public void Test1()
    {
        string str = "HeroP";
        output.WriteLine($"Hello! {str}");
    }

    [Fact(DisplayName = "@ 字符串取消转义")]
    public void Test2()
    {
        //字符串前使用 @ 可以无需使用 \ 转义
        //英文双引号 " 除外
        output.WriteLine(@"\a\b");
    }
}