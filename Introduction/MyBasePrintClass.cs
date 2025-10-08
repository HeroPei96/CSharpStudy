using Xunit.Abstractions;

namespace 入门;

public class MyBasePrintClass
{
    protected readonly ITestOutputHelper output;

    public MyBasePrintClass(ITestOutputHelper output)
    {
        this.output = output;
    }
}