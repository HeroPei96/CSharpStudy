namespace 基础.循环;

/// <summary>
/// 循环
/// </summary>
public class Loop : MyBasePrintClass
{
    public Loop(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "数组循环 - 当数组容量为0时")]
    public void Test1()
    {
        int[] array = new int[0];
        for (var i = 0; i < array.Length; i++)
        {
            WriteLine($"array[{i}] = {array[i]}");
        }

        foreach (int i in array)
        {
            WriteLine($"item = {array[i]}");
        }
    }
}