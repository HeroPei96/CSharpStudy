namespace 进阶.新版本功能;

using static Math;

/// <summary>
/// C# 6 新功能
/// => lambda 表达式
/// 特殊语法 - Null 传播器
/// 特殊语法 - 字符串内插
/// 静态导入
/// 异常筛选器
/// nameof 运算符
/// </summary>
public class SixT : MyBasePrintClass
{
    public SixT(ITestOutputHelper output) : base(output)
    {
    }

    //可以更方便的调用静态成员和嵌套类型（例如内部类），节约代码量
    [Fact(DisplayName = "静态导入")]
    public void Test1()
    {
        //System.Math;
        int value = Max(1, 2);
        output.WriteLine($"value: {value}");
    }

    [Fact(DisplayName = "异常筛选器")]
    public void Test2()
    {
        try
        {
        }
        catch (Exception e) when (e.Message.Contains("301"))
        {
            //相当于要满足两个条件才会打印 message
            output.WriteLine(e.Message);
        }
    }

    //得到 变量名的字符串
    [Fact(DisplayName = "nameof 运算符")]
    public void Test3()
    {
        int i = 10;
        string str = "str";
        object obj = null;
        //变量 字符串
        //i
        output.WriteLine(nameof(i));
        //str
        output.WriteLine(nameof(str));
        //obj
        output.WriteLine(nameof(obj));
        //类名 字符串
        //SixT
        output.WriteLine(nameof(SixT));
        //函数 字符串
        //GetType
        output.WriteLine(nameof(SixT.GetType));
    }
}