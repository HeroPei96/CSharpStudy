namespace 核心.数据类型.List;

/// <summary>
/// LinkedList - 双向链表
/// </summary>
public class LinkedListT : MyBasePrintClass
{
    public LinkedListT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "增删查改")]
    public void Test1()
    {
        LinkedList<int> linkedList = new LinkedList<int>();
        
        //在链表头部 add
        linkedList.AddFirst(1);
        linkedList.AddFirst(0);
        //在链表尾部 add
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(4);
        linkedList.AddLast(3);
        
        //linkedList.RemoveFirst();
        //linkedList.RemoveLast();
        //从链表头开始匹配
        linkedList.Remove(3);
        
        //头节点内容
        int? firstValue = linkedList.First?.Value;
        //尾节点内容
        int? lastValue = linkedList.Last?.Value;

        //存在判断
        if (linkedList.Contains(3))
        {
            WriteLine("存在该元素");
        }

        //正序查找指定元素
        int? findValue = linkedList.Find(3)?.Value;
        //倒序查找指定元素
        int? findLastValue = linkedList.FindLast(3)?.Value;

        LinkedListNode<int>? node = linkedList.Find(2);
        if (node != null)
        {
            //在指定元素前插入
            linkedList.AddBefore(node, 1);
            //在指定元素后插入
            linkedList.AddAfter(node, 3);
        }

        linkedList.Clear();
    }

    [Fact(DisplayName = "遍历")]
    public void Test2()
    {
        LinkedList<int> linkedList = new LinkedList<int>();
        
        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(4);
        linkedList.AddLast(3);
        
        WriteLine("foreach 遍历");
        foreach (int item in linkedList)
        {
            WriteLine($"item: {item}");
        }

        WriteLine("通过next 遍历");
        LinkedListNode<int>? node = linkedList.First;
        while (node != null)
        {
            WriteLine($"node: {node.Value}");
            node = node.Next;
        }
    }
}