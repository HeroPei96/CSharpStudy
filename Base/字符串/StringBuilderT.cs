using System.Text;

namespace 基础.字符串构建器;

/// <summary>
/// StringBuilder
/// </summary>
public class StringBuilderT : MyBasePrintClass
{
    public StringBuilderT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        StringBuilder sb = new StringBuilder();
        //注意不是字符串长度
        output.WriteLine($"初始容量: {sb.Capacity}");
        //字符串长度
        output.WriteLine($"字符长度: {sb.Length}");

        //添加
        sb.Append("123");
        sb.AppendFormat("{0}{1}", 100, 99);

        //指定位置插入
        sb.Insert(0, "首位");

        //移除指定索引，指定长度的字符数组
        sb.Remove(2, 3);

        output.WriteLine($"str: {sb.ToString()}");

        //获取指定字符
        output.WriteLine($"sb[0]: {sb[0]}");

        //通过索引修改某个字符
        sb[0] = '末';
        output.WriteLine($"str: {sb.ToString()}");
        //替换
        sb.Replace("0", "1");
        output.WriteLine($"str: {sb.ToString()}");

        //清空
        sb.Clear();
    }

    [Fact(DisplayName = "与 string 比较")]
    public void Test2()
    {
        StringBuilder sb = new StringBuilder("123");
        //可以直接和 string 进行 equals 比较
        bool b1 = sb.Equals("123");
        output.WriteLine($"b1: {b1}");
    }
}