using Xunit.Abstractions;

namespace 入门;

public class UnitTest1 : MyBasePrintClass
{
    public UnitTest1(ITestOutputHelper output) : base(output){}
    
    [Fact(DisplayName = "Hello World")]
    public void Test1()
    {
        output.WriteLine("Hello World");
    }
}