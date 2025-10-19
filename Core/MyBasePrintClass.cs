using Xunit.Abstractions;

namespace 核心;

public class MyBasePrintClass
{
    protected readonly ITestOutputHelper output;

    public MyBasePrintClass(ITestOutputHelper output)
    {
        this.output = output;
    }
}