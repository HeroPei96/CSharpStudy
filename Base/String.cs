using Xunit.Abstractions;

namespace 基础;

/// <summary>
/// 字符串
/// </summary>
public class String : MyBasePrintClass
{
    public String(ITestOutputHelper output) : base(output)
    {
    }
    
    /// <summary>
    /// 字符串拼接只能用 + 或者 += 其余为非法操作(例：++)
    /// </summary>
    [Fact(DisplayName = "字符串 + 拼接")]
    public void Test1()
    {
        //通过 + 拼接字符串时，出现字符串后才会执行字符串拼接逻辑，之前的逻辑运算还会按照原逻辑
        string str = 1 + 2 + "" + 3 + 4;
        //334
        output.WriteLine("str: " + str);
    }

    [Fact(DisplayName = "通过 string.Format 拼接字符串")]
    public void Test2()
    {
        //最基础的拼接
        string str = string.Format("1", "22", "333");
        output.WriteLine("str: " + str);

        //指定占位符拼接
        str = string.Format("我是{0}，我今年{1}, 我是{0}", "HeroP", 18);
        output.WriteLine(str);
    }
}