using System.Text;

namespace 进阶.类型转换;

/// <summary>
/// string类型与字节数组间的相互转换
/// </summary>
public class EncodingT : MyBasePrintClass
{
    public EncodingT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "字符串类型转字节数组")]
    public void Test1()
    {
        string str = "Hello World";
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        output.WriteLine($"string转字节数组后长度为 {bytes.Length}");
    }

    [Fact(DisplayName = "字节数组转字符串类型")]
    public void Test2()
    {
        string str = "Hello World";
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        string value = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        output.WriteLine($"字节数组转string: {value}");
    }
}