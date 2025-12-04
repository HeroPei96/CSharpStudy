using System.Collections;

namespace 进阶.数据类型;

/// <summary>
/// HashTable - 哈希表 - 键值对
/// 不能出现相同键，无法覆盖键
/// 键不能为空，值可以为空
/// </summary>
public class HashTableT : MyBasePrintClass
{
    public HashTableT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "增删查改")]
    public void Test1()
    {
        Hashtable hashTable = new Hashtable();

        hashTable.Add(1, "123");
        hashTable.Add(2, 222);
        hashTable.Add("333", true);
        //键不能为空，值可以为空
        hashTable.Add("ABC", null);
        // 无法覆盖相同键 
        // hashTable.Add("333", false);

        //只能通过键来删除
        hashTable.Remove(1);
        //删除一个不存在的键不会报错
        hashTable.Remove(1);

        //查
        output.WriteLine(hashTable["333"].ToString());
        //获取一个不存在的键值对时不会报错，返回 null
        object o = hashTable["qwer"];
        //查看键是否存在
        hashTable.ContainsKey("333");
        //查看值是否存在
        hashTable.ContainsValue("123");

        //改
        hashTable["333"] = false;

        //清空
        hashTable.Clear();
    }

    [Fact(DisplayName = "遍历")]
    public void Test2()
    {
        Hashtable hashTable = new Hashtable();
        hashTable.Add(1, "123");
        hashTable.Add(2, 222);
        hashTable.Add("333", true);

        output.WriteLine($"hashTable.Count: {hashTable.Count}");

        //遍历 键
        foreach (object item in hashTable.Keys)
        {
            output.WriteLine($"key: {item}, value: {hashTable[item]}");
        }

        //遍历 值
        foreach (object item in hashTable.Values)
        {
        }

        //键值对一起遍历
        output.WriteLine("键值对一起遍历");
        foreach (DictionaryEntry entry in hashTable)
        {
            output.WriteLine($"key: {entry.Key}, value: {entry.Value}");
        }

        //迭代器遍历
        output.WriteLine("迭代器遍历");
        IDictionaryEnumerator enumerator = hashTable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            output.WriteLine($"key: {enumerator.Key}, value: {enumerator.Value}");
        }
    }
}