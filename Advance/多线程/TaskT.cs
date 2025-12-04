namespace 进阶.多线程.Task任务类;

/// <summary>
/// Task
/// 和 Thread 的区别为: Task内部封装了线程池，使用方法和 Thread 差不多
/// 调用 task.Result 会阻塞当前线程，直到 task 线程执行完毕
/// </summary>
public class TaskT : MyBasePrintClass
{
    public TaskT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "无返回值 Task 方式一")]
    public void Test1()
    {
        Task task = new Task(() => { output.WriteLine("无返回值 Task 方式一"); });
        task.Start();
    }

    [Fact(DisplayName = "无返回值 Task 方式二")]
    public void Test2()
    {
        Task.Run(() => { output.WriteLine("无返回值 Task 方式二"); });
    }

    [Fact(DisplayName = "无返回值 Task 方式三")]
    public void Test3()
    {
        Task.Factory.StartNew(() => { output.WriteLine("无返回值 Task 方式三"); });
    }

    [Fact(DisplayName = "有返回值 Task 方式一")]
    public void Test4()
    {
        Task<string> task = new Task<string>(() =>
        {
            output.WriteLine("有返回值 Task 方式一");
            return "返回值一";
        });
        task.Start();
        //调用 task.Result 会阻塞当前线程，直到 task 线程执行完毕
        //Unity 中不要在主线程执行该方法。容易导致卡顿
        output.WriteLine($"taskResult: {task.Result}");
    }

    [Fact(DisplayName = "有返回值 Task 方式二")]
    public void Test5()
    {
        Task<string> task = Task.Run(() =>
        {
            output.WriteLine("有返回值 Task 方式二");
            return "返回值二";
        });
        output.WriteLine($"taskResult: {task.Result}");
    }

    [Fact(DisplayName = "有返回值 Task 方式三")]
    public void Test6()
    {
        Task<string> task = Task<string>.Factory.StartNew(() =>
        {
            output.WriteLine("有返回值 Task 方式三");
            return "返回值三";
        });
        output.WriteLine($"taskResult: {task.Result}");
    }

    //如果不希望异步执行，想要同步，那么可以使用  RunSynchronously 方法
    [Fact(DisplayName = "同步执行 task")]
    public void Test7()
    {
        Task task = new Task(() => { output.WriteLine("无返回值 Task 方式一"); });
        //只支持通过 new Task创建对象的方式
        task.RunSynchronously();
    }

    //阻塞当前线程，而不是其他运行中的线程
    [Fact(DisplayName = "Wait 线程阻塞")]
    public void Test8()
    {
        Task t1 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
                output.WriteLine("t1: {i}");
        });

        Task t2 = Task.Run(() =>
        {
            for (int i = 0; i < 20; i++)
                output.WriteLine("t2: {i}");
        });
        //会等待 t2 执行完才会去执行当前线程，但不会影响 t1 的执行
        // t2.Wait();

        //t1 或 t2 任一执行完才会去执行当前线程
        //Task.WaitAny(t1, t2);

        //t1 和 t2 全部执行完才会去执行当前线程
        // Task.WaitAll(t1, t2);
    }

    //某一线程完成后额外执行其他任务（其他的任务也是通过该线程执行的）
    [Fact(DisplayName = "When 某一线程完成后额外执行其他任务")]
    public void Test9()
    {
        Task t1 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
                output.WriteLine("t1: {0}", i);
        });
        Task t2 = Task.Run(() =>
        {
            for (int i = 0; i < 20; i++)
                output.WriteLine("t2: {0}", i);
        });
        Task.WhenAll(t1).ContinueWith((t) => { output.WriteLine("t1执行完成，继续执行当前线程"); });

        Task.WhenAny(t1, t2).ContinueWith((t) => { output.WriteLine("t1 或 t2执行完成，继续执行当前线程"); });

        //通过 Task.Factory 的方式
        Task.Factory.ContinueWhenAll(new Task[] { t1, t2 }, (t) => { output.WriteLine("t1 和 t2执行完成，继续执行当前线程"); });
        Task.Factory.ContinueWhenAny(new Task[] { t1, t2 }, (t) => { output.WriteLine("t1 或 t2执行完成，继续执行当前线程"); });
    }

    //如果没有任务取消后要执行的方法，更推荐通过标识符来提前结束执行
    [Fact(DisplayName = "CancellationTokenSource 取消执行")]
    public void Test10()
    {
        CancellationTokenSource c = new CancellationTokenSource();
        Task.Run(() =>
        {
            int i = 0;
            while (!c.IsCancellationRequested)
            {
                output.WriteLine("计次: {0}", ++i);
                Thread.Sleep(1000);
            }
        });
        //任务取消后需要执行的任务
        c.Token.Register(() => { output.WriteLine("任务取消了"); });
        Thread.Sleep(5000);
        c.Cancel();
    }

    [Fact(DisplayName = "CancellationTokenSource 延迟取消")]
    public void Test11()
    {
        CancellationTokenSource c = new CancellationTokenSource();
        Task.Run(() =>
        {
            int i = 0;
            while (!c.IsCancellationRequested)
            {
                output.WriteLine("计次: {0}", ++i);
                Thread.Sleep(1000);
            }
        });
        //延迟3s取消
        c.CancelAfter(3000);
        Thread.Sleep(5000);
    }
}