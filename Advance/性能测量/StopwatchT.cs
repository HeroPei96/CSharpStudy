namespace 进阶.性能测量;

/// <summary>
/// C# 提供的高精度计时的工具类
/// 可以精确地测量代码执行的时间，常用于性能分析和调试
/// </summary>
public class StopwatchT : MyBasePrintClass
{
    public StopwatchT(ITestOutputHelper output) : base(output)
    {
    }
    
    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        using (CustomTimer test = new CustomTimer("测试任务", output))
        {
            Thread.Sleep(1000);
        }
    }
}