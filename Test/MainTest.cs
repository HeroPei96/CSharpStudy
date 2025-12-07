using System.Diagnostics;

namespace Test;

public class MainTest
{
    public static void Main(string[] args)
    {
        Console.Out.WriteLine("Hello World!");
        MainTest test = new MainTest();
        
        
        Console.WriteLine("打印了吗？");
        test.MyFunc();
    }

    [Conditional("DEBUG")]
    public void MyFunc()
    {
        Console.WriteLine("打印了");
    }
}