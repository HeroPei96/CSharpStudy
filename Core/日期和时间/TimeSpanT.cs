namespace 核心.日期和时间;

/// <summary>
/// TimeSpan - 时间跨度结构体
/// 时间跨度结构体
/// 用两个 DateTime 对象相减 可以得到该对象
/// </summary>
public class TimeSpanT : MyBasePrintClass
{
    public TimeSpanT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        DateTime now = DateTime.Parse("2025/12/4 21:29:36");
        output.WriteLine($"now: {now}");
        TimeSpan ts = now - new DateTime(2020, 1, 1);
        output.WriteLine($"Minutes: {ts.TotalMinutes}");
        output.WriteLine($"Seconds: {ts.TotalSeconds}");
        output.WriteLine($"Days: {ts.TotalDays}");
        output.WriteLine($"Hours: {ts.TotalHours}");
        output.WriteLine($"Ticks: {ts.Ticks}");

        //2164-21-29-36-0
        output.WriteLine($"时间间隔为: {ts.Days}天, {ts.Hours}小时, {ts.Minutes}分钟, {ts.Seconds}秒, {ts.Milliseconds}毫秒");
    }

    [Fact(DisplayName = "时间跨度和时间进行计算")]
    public void Test2()
    {
        TimeSpan ts = new TimeSpan(1,1,1,1);
        DateTime timeNow = DateTime.Now + ts;
        output.WriteLine($"计算后的时间为: {timeNow}");
    }

    [Fact(DisplayName = "时间跨度之间进行计算")]
    public void Test3()
    {
        TimeSpan ts1 = new TimeSpan(0, 1, 0, 1);
        TimeSpan ts2 = new TimeSpan(-1,0,-1,0);
        TimeSpan ts = ts1 + ts2;
        output.WriteLine($"days: {ts.Days}, hours: {ts.Hours}, minutes: {ts.Minutes}, seconds: {ts.Seconds}");
    }
}