namespace 基础;

/// <summary>
/// 字符串
/// </summary>
public class String : MyBasePrintClass
{
    public String(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// 若通过运算符拼接只能用 + 或者 += 其余为非法操作(例：++)
    /// </summary>
    [Fact(DisplayName = "字符串 拼接")]
    public void Test1()
    {
        //通过 + 拼接字符串时，出现字符串后才会执行字符串拼接逻辑，之前的逻辑运算还会按照原逻辑
        string str = 1 + 2 + "" + 3 + 4;
        //334
        output.WriteLine("str: " + str);

        //format拼接
        str = string.Format("{0}{1}", "Hello", " World!");
        output.WriteLine("str: " + str);
    }

    [Fact(DisplayName = "通过 string.Format 拼接字符串")]
    public void Test2()
    {
        //最基础的拼接
        string str = string.Format("1", "22", "333");
        output.WriteLine("str: " + str);

        //指定占位符拼接
        str = string.Format("我是{0}，我今年{1}, 我是{0}", "HeroP", 18);
        output.WriteLine(str);
    }

    [Fact(DisplayName = "字符串和数组")]
    public void Test3()
    {
        //字符串本质是字符数组
        string str = "Hello World";
        output.WriteLine("str[0]: " + str[0]);
        //转为字符数组
        char[] charArray = str.ToCharArray();
        output.WriteLine("charArray[1]: " + charArray[1]);
    }

    [Fact(DisplayName = "字符串查找字符")]
    public void Test4()
    {
        string str = "Hello World";
        //正向查找 索引从0开始，没找到返回 -1
        int index = str.IndexOf("o");
        output.WriteLine($"o index: {index}");

        //反向查找 字符串从后往前找，但返回的还是正向的索引
        index = str.LastIndexOf("o");
        output.WriteLine($"o LastIndex: {index}");

        //查找字符串
        index = str.IndexOf("lo");
        output.WriteLine($"lo index: {index}");
    }

    [Fact(DisplayName = "移除字符")]
    public void Test5()
    {
        //移除指定位置后的字符
        string str = "Hello World";

        //移除该位置和之后的所有字符，相当于保留前 n 位字符
        string str1 = str.Remove(7);
        output.WriteLine($"移除指定位置后的新字符串: {str1}");

        //移除该位置和之后的 n-1 个字符
        string str2 = str.Remove(4, 2);
        output.WriteLine($"移除后的新字符串: {str2}");
    }

    [Fact(DisplayName = "字符串替换")]
    public void Test6()
    {
        string str = "HeroP";

        string str1 = str.Replace("P", "Pei");
        output.WriteLine($"替换后的字符串: {str1}");
    }

    [Fact(DisplayName = "大小写转换")]
    public void Test7()
    {
        string str = "Hello World";

        string str1 = str.ToUpper();
        output.WriteLine($"转大写: {str1}");
        string str2 = str.ToLower();
        output.WriteLine($"转小写: {str2}");
    }


    [Fact(DisplayName = "截取字符串")]
    public void Test8()
    {
        string str = "Hello World";

        //截取当前索引位开始和之后的
        string str1 = str.Substring(6);
        output.WriteLine($"截取后的新字符串为: {str1}");

        //截取指定位置和长度
        string str2 = str.Substring(2, 3);
        output.WriteLine($"截取指定位置和长度后的新字符串为: {str2}");
    }


    [Fact(DisplayName = "切割字符串")]
    public void Test9()
    {
        string str = "1,2,3,4,5,6,7,8";
        //切割为数组
        string[] str1 = str.Split(",");
    }
}