namespace 基础.单元测试;

public class UnitTest : MyBasePrintClass
{
    public UnitTest(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "Hello World")]
    public void Test1()
    {
        output.WriteLine("Hello World");
    }
}