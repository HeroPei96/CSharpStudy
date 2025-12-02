namespace 进阶.类型转换;

/// <summary>
/// 基础类型与字节数组间的相互转换
/// </summary>
public class BiteConverterT : MyBasePrintClass
{
    public BiteConverterT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基础类型转字节数组")]
    public void Test1()
    {
        int i = 256;
        byte[] bytes = BitConverter.GetBytes(i);
        output.WriteLine($"int类型转字节数组后长度为 {bytes.Length}");
    }

    [Fact(DisplayName = "字节数组转基础类型")]
    public void Test2()
    {
        int i = 256;
        byte[] bytes = BitConverter.GetBytes(i);
        int value = BitConverter.ToInt32(bytes, 0);
        output.WriteLine($"字节数组转int: {value}");
    }
}