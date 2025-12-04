namespace Test;

public class ThreadTest
{
    /// <summary>
    /// 线程的启动和停止
    /// </summary>
    public void Test1()
    {
        Thread thread = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine("新线程持续运行中");
            }
        });
        //IsBackground 默认为 false 即表示为 一个前台进程
        //即使主线程停止运行，前台进程也不会停止
        //所以 IsBackground 通常设置为 true
        thread.IsBackground = true;
        thread.Start();
        Console.WriteLine("主线程结束");

        //中止线程 thread.Abort();
        //可能部分C#版本不支持会报错，使用时需注意
        /*
        try
        {
            thread.Abort();
        }
        catch (Exception)
        {
        }
        */
    }
}