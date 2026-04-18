using System.Diagnostics;

namespace 进阶.性能测量;

/// <summary>
/// 性能测量计时工具类
/// </summary>
public class CustomTimer : IDisposable
{
    
    private ITestOutputHelper _output;
    
    //计时任务的名字
    private string _name;

    //计时对象
    private Stopwatch _watch;

    //消耗时间
    public double SpendTime { get; private set; }

    public CustomTimer(string name, ITestOutputHelper output)
    {
        _output = output;
        _name = name;
        //声明一个计时对象 并且直接开始计时
        _watch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        _watch.Stop();
        //从上一次 StartNew 至此的时间
        SpendTime = _watch.Elapsed.TotalMilliseconds;
        _output.WriteLine($"{_name}计时结束，共耗时{SpendTime}ms");
    }
}