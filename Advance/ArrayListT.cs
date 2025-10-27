using System.Collections;

namespace 进阶;

/// <summary>
/// ArrayList
/// </summary>
public class ArrayListT : MyBasePrintClass
{
    public ArrayListT(ITestOutputHelper output) : base(output)
    {
    }


    [Fact(DisplayName = "增删改查")]
    public void Test1()
    {
        ArrayList list = new ArrayList();

        //能够存储任意类型，包括值类型
        list.Add(1);
        list.Add("123");

        //把一个集合中的内容一个个放到另一个中
        ArrayList list1 = new ArrayList();
        list.AddRange(list1);

        //指定索引处插入
        list.Insert(1, "qwe");

        //移除指定的某个元素，从 索引0 开始
        list.Remove(1);
        //移除指定索引的元素
        list.RemoveAt(2);
        //清空
        // list.Clear();

        //获取指定索引的元素
        object? o1 = list[0];

        //查看元素是否存在
        bool b1 = list.Contains("123");

        //查找元素的索引，找不到返回 -1
        int indexOf = list.IndexOf("123");
        //反向查找 
        int lastIndexOf = list.LastIndexOf("123");

        //改
        list[0] = "Hello";
    }

    [Fact(DisplayName = "遍历")]
    public void Test2()
    {
        ArrayList list = new ArrayList();
        int count = 5;
        for (int i = 0; i < count; i++)
        {
            list.Add(i);
        }

        //Count 集合内容长度
        output.WriteLine($"list.Count={list.Count}");
        //Capacity 容量
        output.WriteLine($"list.Capacity={list.Capacity}");

        //迭代器遍历
        foreach (object obj in list)
        {
            output.WriteLine($"obj: {obj}");
        }
    }
}