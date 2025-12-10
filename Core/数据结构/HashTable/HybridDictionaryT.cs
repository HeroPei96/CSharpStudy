using System.Collections.Specialized;

namespace 核心.数据类型.HashTable;

/// <summary>
/// HybridDictionary - 混合类型的哈希表，不支持泛型
/// 当元素数量较少时，使用链表结构。通过源码可知，5个及以内采用链表
/// 当元素数量较多时，切换为使用哈希表
/// </summary>
public class HybridDictionaryT : MyBasePrintClass
{
    public HybridDictionaryT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "增删查改")]
    public void Test1()
    {
        //6 > 5，采用哈希表
        HybridDictionary dictionary = new HybridDictionary(6);
        object key1 = new();
        object val1 = new();
        dictionary.Add(key1, val1);
        dictionary.Add("key2", "value2");
        dictionary.Add("key3", "value4");

        //不存在会返回空
        Assert.Null(dictionary["key4"]);
    }
}