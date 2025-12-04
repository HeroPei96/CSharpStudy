namespace 核心.日期和时间;

/// <summary>
/// DateTIme - 用于处理时间和日期的结构体
/// </summary>
public class DateTimeT : MyBasePrintClass
{
    public DateTimeT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "初始化日期和时间&基本使用")]
    public void Test1()
    {
        //主要参数：
        //年、月、日、时、分、秒、毫秒
        //次要参数：
        //DateTimeKind: 日期时间种类
        //  Local: 本地时间
        //  Utc: UTC时间
        //  Unspecified(默认): 不指定
        DateTime dt = new DateTime(2022, 12, 1, 13, 30, 45, 500);
        //年、月、日、时、分、秒、毫秒
        output.WriteLine($"{dt.Year}-{dt.Month}-{dt.Day} {dt.Hour}:{dt.Minute}:{dt.Second}.{dt.Millisecond}");

        //一年的第多少天
        output.WriteLine($"这是一年的第 {dt.DayOfYear} 天");
        //星期几
        output.WriteLine($"这天是星期 {dt.DayOfWeek}");

        //当前时间
        output.WriteLine($"当前时间为: {DateTime.Now}");
        //UTC时间 因为国内是 UTC +8，所以这里比当前时间少 8h
        output.WriteLine($"当前UTC时间为: {DateTime.UtcNow}");

        //各种时间 2025/12/4 21:15:52
        //2025/12/4
        output.WriteLine($"ShortDate: {DateTime.Now.ToShortDateString()}");
        //21:15
        output.WriteLine($"ShortTime: {DateTime.Now.ToShortTimeString()}");
        //2025年12月4日
        output.WriteLine($"LongDate: {DateTime.Now.ToLongDateString()}");
        //21:15:52
        output.WriteLine($"LongTime: {DateTime.Now.ToLongTimeString()}");

        //格式化输出(详见语雀)
        output.WriteLine($"格式化输出1: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        output.WriteLine($"格式化输出2: {DateTime.Now.ToString("F")}");
    }

    [Fact(DisplayName = "计算时间")]
    public void Test2()
    {
        //各种时间/日期计算
        DateTime dateTime = DateTime.Now.AddDays(-1);
        dateTime = dateTime.AddHours(1);
        output.WriteLine($"计算后的时间为: {dateTime}");
    }

    [Fact(DisplayName = "字符串转DateTime")]
    public void Test3()
    {
        //字符串想要转回DateTime成功的话 
        //那么这个字符串的格式是有要求的 一定是最基本的无规则 toString 的转换出来的字符串才能转回去
        //年/月/日 时:分:秒
        string str = DateTime.Now.ToString();
        DateTime dateTime;
        if (DateTime.TryParse(str, out dateTime))
        {
            output.WriteLine($"time: {dateTime}");
        }
    }
}