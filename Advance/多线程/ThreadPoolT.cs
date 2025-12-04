namespace 进阶.线程池;

/// <summary>
/// 线程池
/// </summary>
public class ThreadPoolT : MyBasePrintClass
{
    public ThreadPoolT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "获取可用的工作线程数和I/O线程数")]
    public void Test1()
    {
        int num1;
        int num2;
        ThreadPool.GetAvailableThreads(out num1, out num2);
        output.WriteLine($"可用的工作线程数: {num1}");
        output.WriteLine($"可用的I/O线程数: {num2}");
    }

    [Fact(DisplayName = "获取线程池中工作线程的最大数目和I/O线程的最大数目")]
    public void Test2()
    {
        int num1;
        int num2;
        ThreadPool.GetMaxThreads(out num1, out num2);
        output.WriteLine($"工作线程的最大数目: {num1}");
        output.WriteLine($"I/O线程的最大数目: {num2}");
    }

    [Fact(DisplayName = "设置线程池中可以同时处于活动状态的工作线程的最大数目和I/O线程的最大数目")]
    public void Test3()
    {
        //大于次数的请求将保持排队状态，直到线程池线程变为可用
        //更改成功返回true，失败返回false
        bool result = ThreadPool.SetMaxThreads(20, 20);
        if (result)
            output.WriteLine("更改成功");
    }

    [Fact(DisplayName = "同上，设置最小数目")]
    public void Test4()
    {
        bool result = ThreadPool.SetMinThreads(10, 10);
        if (result)
            output.WriteLine("更改成功");
    }

    [Fact(DisplayName = "获取线程池中工作线程的最小数目和I/O线程的最小数目")]
    public void Test5()
    {
        int num1;
        int num2;
        ThreadPool.GetMinThreads(out num1, out num2);
        output.WriteLine($"工作线程的最小数目: {num1}");
        output.WriteLine($"I/O线程的最小数目: {num2}");
    }

    [Fact(DisplayName = "排队待线程可用时执行")]
    public void Test6()
    {
        ThreadPool.QueueUserWorkItem(state =>
        {
            //state 其实就是自己传的参数 "Hello"
            output.WriteLine(state.ToString());
            output.WriteLine("开启了线程");
        }, "Hello");
    }
}