namespace 核心.数据类型.Dictionary;

/// <summary>
/// 最常用的字典
/// 1.元素顺序是无序的
/// </summary>
public class DictionaryT : MyBasePrintClass
{
    public DictionaryT(ITestOutputHelper output) : base(output)
    {
    }
    
    [Fact(DisplayName = "增")]
    public void Test1()
    {
        Dictionary<string, string> dict = new();
        dict.Add("d1", "d1String");
        
        //key 不能为空
        // dict.Add(null, "d2String");
        
        //value 可以为空
        dict.Add("d3", null);
        
        //同一个 key 无法再次 add
        // dict.Add("d1", "d1AnotherStr");
    }
    
    [Fact(DisplayName = "查")]
    public void Test2()
    {
        Dictionary<string, string> dict = new();
        dict.Add("d1", "d1String");
        dict.Add("d2", "d2String");
        dict.Add("d3", "d3String");
        
        if (dict.ContainsKey("d1"))
        {
            WriteLine($"存在键为 d1 的内容: {dict["d1"]}");
        }
        
        if (dict.ContainsValue("d3String"))
        {
            WriteLine($"存在值为 d3String 的内容");
        }
        
        if (dict.TryGetValue("d4", out string result))
        {
            WriteLine($"存在键为 d4 的内容");
        }
        if (result == null)
        {
            WriteLine($"result 为空");
        }
    }
}