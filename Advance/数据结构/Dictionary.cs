namespace 进阶.数据类型;

/// <summary>
/// Dictionary - 本质上是有泛型功能的 HashTable
/// </summary>
public class Dictionary : MyBasePrintClass
{
    public Dictionary(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "增删查改")]
    public void Test1()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("key1", "value1");
        dictionary.Add("key2", "value2");
        dictionary.Add("key3", "value4");

        // 与 HastTable 不同的是，获取一个不存在的键会报错，HashTable 会返回空
        // string str = dictionary["key4"];
    }
}