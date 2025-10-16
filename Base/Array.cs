using Xunit.Abstractions;

namespace 基础;

/// <summary>
/// 数组
/// </summary>
public class Array : MyBasePrintClass
{
    public Array(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "一维数组的声明和使用")]
    public void Test1()
    {
        //完整语法
        //变量类型[] 数组名 = new 变量类型[数组长度]{内容1,内容2,内容3,......}
        int[] arr1 = new int[5] { 1, 2, 3, 4, 5 };

        //写法一 不指定数组长度 此时数组长度由 {} 中内容长度决定
        int[] arr2 = new int[] { 1, 2, 3 };
        //写法二 完全省略 new 变量类型[数组长度]
        int[] arr3 = { 1, 2, 3 };

        //数组长度
        int length = arr1.Length;
        output.WriteLine(length.ToString());
    }

    [Fact(DisplayName = "二维数组的声明和使用")]
    public void Test2()
    {
        //完整语法
        //变量类型[,] 数组名 = new 变量类型[行, 列]{ {0行列0,0行列1,...}, {1行列0,1行列1,...},... }
        int[,] arr1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
        //写法一
        int[,] arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
        //写法二
        int[,] arr3 = { { 1, 2, 3 }, { 4, 5, 6 } };

        //通过 GetLength 获取行列
        //获取行
        int row = arr1.GetLength(0);
        //获取列
        int column = arr1.GetLength(1);
    }

    //行固定，列不固定的数组
    [Fact(DisplayName = "交错数组")]
    public void Test3()
    {
        //完整语法
        //变量类型[][] 数组名 = new 变量类型[行][]{ 一维数组1, 一维数组2, ... }
        int[][] arr1 = new int[2][] { new[] { 1, 2 }, new[] { 3, 4, 5 } };
        //写法一
        int[][] arr2 = new int[][] { new[] { 1, 2 }, new[] { 3, 4, 5 } };
        //写法二
        int[][] arr3 = { new[] { 1, 2 }, new[] { 3, 4, 5 } };
    }
}