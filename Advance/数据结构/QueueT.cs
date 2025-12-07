using System.Collections;

namespace 进阶.数据类型;

/// <summary>
/// Queue - 队列 - 先进先出
/// </summary>
public class QueueT : MyBasePrintClass
{
    public QueueT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "增取查改")]
    public void Test1()
    {
        Queue queue = new Queue();

        //增
        queue.Enqueue("123");
        queue.Enqueue("456");

        //取
        object obj = queue.Dequeue();

        //查看队首
        object? top = queue.Peek();
        WriteLine($"top: {top}");

        if (queue.Contains("456"))
        {
            WriteLine("存在该元素");
        }

        //清空
        queue.Clear();
    }

    [Fact(DisplayName = "遍历")]
    public void Test2()
    {
        Queue queue = new Queue();
        queue.Enqueue("123");
        queue.Enqueue("qwe");
        queue.Enqueue("456");
        queue.Enqueue("qaz");
        WriteLine($"Queue Count: {queue.Count}");

        WriteLine($"Foreach 遍历");
        foreach (object item in queue)
        {
            WriteLine(item.ToString());
        }

        WriteLine($"转为数组 遍历");
        object?[] array = queue.ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            WriteLine(array[i].ToString());
        }

        //循环出队
        if (queue.Count > 0)
        {
            queue.Dequeue();
        }
    }
}