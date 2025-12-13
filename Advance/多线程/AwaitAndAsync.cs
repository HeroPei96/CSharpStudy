namespace 进阶.多线程.AwaitAndAsync;

/// <summary>
/// 类似于 Unity 中的协程，但是是异步的，协程本质还是同步的
/// await 要和 async 配合起来使用
/// async用于修饰函数、lambda表达式、匿名函数
/// await用于在函数中和async配对使用,主要作用是等待某个逻辑结束
/// Unity 中大部分异步方法是不支持异步关键字 await 和 async 的，使用协同程序进行使用
/// </summary>
public class AwaitAndAsync : MyBasePrintClass
{
    public AwaitAndAsync(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "await & async")]
    public void Test1()
    {
        output.WriteLine("首次打印主线程ID：{0}", Environment.CurrentManagedThreadId);
        Task task = TestAsync();
        // 通过 task.Wait() 阻塞
        // task.Wait();
        output.WriteLine("再次打印主线程ID：{0}", Environment.CurrentManagedThreadId);
        Thread.Sleep(2000);
        output.WriteLine("最后打印主线程ID：{0}", Environment.CurrentManagedThreadId);

        async Task TestAsync()
        {
            //当前还在主线程中执行
            output.WriteLine("打印 async 方法线程ID：{0}", Environment.CurrentManagedThreadId);
            //检测到 await 关键字后，当前函数会被挂机，继续返回执行 调用处(调用async函数的地方) 函数剩下的
            //await + Task 是固定写法，表示新开一个线程 执行 await 修饰的 Task 任务
            //await 中不能访问 unity 对象
            await Task.Run(() =>
            {
                output.WriteLine("await 任务线程ID：{0}", Environment.CurrentManagedThreadId);
                Thread.Sleep(1500);
                output.WriteLine("await 任务执行完毕");
            });
            //await 修饰的线程池任务执行完毕后，剩下的任务才会执行
            output.WriteLine("再次打印 async 方法线程ID：{0}", Environment.CurrentManagedThreadId);
        }
    }
}