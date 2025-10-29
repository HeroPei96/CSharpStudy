using System.Collections;

namespace 进阶.数据类型;

/// <summary>
/// Stack - 栈 - 先进后出
/// </summary>
public class StackT : MyBasePrintClass
{
    public StackT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "增取查改")]
    public void Test1()
    {
        Stack stack = new Stack();

        //压栈
        stack.Push("123");

        //出栈
        object? str = stack.Pop();

        stack.Push("456");
        stack.Push("qwe");
        //查看栈顶元素（不会出栈）
        object? top = stack.Peek();

        //通过 Contains 判断是否存在对应元素 
        if (stack.Contains("456"))
        {
            output.WriteLine("存在该元素");
        }

        //清空
        stack.Clear();
    }

    [Fact(DisplayName = "遍历")]
    public void Test2()
    {
        Stack stack = new Stack();
        stack.Push("123");
        stack.Push("qwe");
        stack.Push("456");
        stack.Push("qaz");

        //长度
        output.WriteLine($"Stack Count: {stack.Count}");
        
        //遍历 - 从栈顶到栈底
        foreach (object item in stack)
        {
            output.WriteLine(item.ToString());
        }

        //转数组，顺序也是从栈顶到栈底
        object?[] array = stack.ToArray();
        
        //循环弹栈
        if (stack.Count > 0)
        {
            stack.Pop();
        }
    }
}