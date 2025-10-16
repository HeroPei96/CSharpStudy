using Xunit.Abstractions;

namespace 基础;

public class MyBasePrintClass
{
    protected readonly ITestOutputHelper output;

    public MyBasePrintClass(ITestOutputHelper output)
    {
        this.output = output;
    }
}