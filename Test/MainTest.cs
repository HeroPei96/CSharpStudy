namespace Test;

public class MainTest
{
    public static void Main(string[] args)
    {
        ThreadTest();
    }

    public static void ThreadTest()
    {
        //线程的启动和停止
        new ThreadTest().Test1();
    }
}