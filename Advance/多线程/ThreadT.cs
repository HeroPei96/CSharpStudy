namespace 进阶.多线程.线程;

/// <summary>
/// 多线程 Xunit
/// 线程 Thread 开启有问题，不要在这里进行测试
/// </summary>
public class ThreadT : MyBasePrintClass
{
    public ThreadT(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// 线程的启动和停止
    /// </summary>
    [Fact(DisplayName = "启动一个线程")]
    public void Test1()
    {
        Thread thread = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(200);
                WriteLine("新线程持续运行中");
            }
        });
        //IsBackground 默认为 false 即表示为 一个前台进程
        //即使主线程停止运行，前台进程也不会停止
        //所以 IsBackground 通常设置为 true
        thread.IsBackground = true;
        thread.Start();
        Thread.Sleep(1000);
        WriteLine("主线程结束");
    }

    [Fact(DisplayName = "中止一个线程")]
    public void Test2()
    {
        Thread thread = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(200);
                WriteLine("新线程持续运行中");
            }
        });
        thread.Start();
        Thread.Sleep(1000);
        try
        {
            //中止线程 thread.Abort();
            //可能部分C#版本不支持会报错，使用时需注意
            thread.Abort();
        }
        catch (Exception)
        {
        }

        WriteLine("主线程结束");
    }
}