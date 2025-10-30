using System.Collections;

namespace 进阶.迭代器;

/// <summary>
/// 迭代器
/// 关键接口 IEnumerable, IEnumerator
/// </summary>
public class Enumerator : MyBasePrintClass
{
    public Enumerator(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// foreach 的本质
    /// 1.会先获取 in 后对象的 IEnumerable 执行方法 GetEnumerator 获取到 IEnumerator
    /// 2.执行 IEnumerator.next()
    /// 3.只要返回值为 true 就会获取 Current 属性(get)
    /// 4.赋值给 item
    /// 5.循环直至 IEnumerator.next() 返回 false
    /// </summary>
    [Fact(DisplayName = "foreach 的本质")]
    public void Test1()
    {
        CustomList list = new CustomList();
        foreach (int item in list)
        {
            output.WriteLine(item.ToString());
        }
    }

    [Fact(DisplayName = "使用 yield return 语法糖简化迭代器写法")]
    public void Test2()
    {
        CustomList list = new CustomList();
        foreach (int item in list)
        {
            output.WriteLine(item.ToString());
        }
    }
}

/// <summary>
/// 标准迭代器实现
/// </summary>
class CustomList : IEnumerable, IEnumerator
{
    private int[] list;

    //光标位置 从 -1 开始
    private int position = -1;

    public CustomList()
    {
        list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }

    //可以不需要实现 IEnumerable 这个接口，只需要这个方法就行，但为了规范和方便起见最好实现
    public IEnumerator GetEnumerator()
    {
        Reset();
        return this;
    }

    public bool MoveNext()
    {
        ++position;
        return position < list.Length;
    }

    public void Reset()
    {
        position = -1;
    }

    public object Current
    {
        get => list[position];
    }
}

/// <summary>
/// 使用 yield return 语法糖简化迭代器写法
/// </summary>
class EasyCustomList : IEnumerable
{
    private int[] list;

    public EasyCustomList()
    {
        list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < list.Length; i++)
        {
            yield return list[i];
        }

        //本质
        //yield return list[0];
        //yield return list[1];
        //yield return list[2];
        //...
    }
}