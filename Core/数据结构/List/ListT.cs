namespace 核心.数据类型.List;

/// <summary>
/// List - 本质上是有泛型功能的 ArrayList
/// </summary>
public class ListT : MyBasePrintClass
{
    public ListT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "增删查改")]
    public void Test1()
    {
        List<string> list = new List<String>();
        list.Add("123");
        list.Add("456");
        list.Add("qwe");
        list.Add("qaz");
        list.Add("asd");
    }
}