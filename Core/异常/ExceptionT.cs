namespace 核心.异常;

/// <summary>
/// 异常的基本使用
/// </summary>
public class ExceptionT : MyBasePrintClass
{
    public ExceptionT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "抛出自定义异常")]
    public void Test1()
    {
        Assert.Throws<MyException>(() =>
        {
            int i = 1;
            if (i == 1)
                throw new MyException();
        });
    }
}

//自定义异常
class MyException : Exception
{
    public MyException()
    {
        Console.Out.WriteLine("抛出了一个异常");
    }

    public MyException(string? message) : base(message)
    {
        Console.Out.WriteLine(message);
    }
}