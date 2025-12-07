namespace 进阶.新版本功能;

/// <summary>
/// C# 9 新功能
/// and or not
/// </summary>
public class NineT : MyBasePrintClass
{
    public NineT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "and or not")]
    public void Test1()
    {
        int i = 2;
        if (i is 1 or 2 or 3)
            output.WriteLine($"i is 1 or 2 or 3, i: {i}");
        if (i is > 0 and < 5)
            output.WriteLine($"i is > 0 and < 5, i: {i}");

        //两个元组间使用 元组要数量匹配，第1个和第1个比，以此类推
        var tupleVal = (3, 5);
        if (tupleVal is (> 2, not 6))
            output.WriteLine("Pass");
    }
}