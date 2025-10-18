using System.Text;
using Xunit.Abstractions;

namespace 基础;

/// <summary>
/// 排序
/// </summary>
public class Sort : MyBasePrintClass
{
    public Sort(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// 冒泡排序
    /// </summary>
    [Fact(DisplayName = "冒泡排序")]
    public void Test1()
    {
        int[] arr = GenerateArr(5);

        output.WriteLine("Sort 前: ");
        PrintArr(arr);
        output.WriteLine("Sort 后: ");
        BubbleSort(arr);
        PrintArr(arr);
    }

    /// <summary>
    /// 选择排序
    /// </summary>
    [Fact(DisplayName = "选择排序")]
    public void Test2()
    {
        int[] arr = GenerateArr(5);

        output.WriteLine("Sort 前: ");
        PrintArr(arr);
        output.WriteLine("Sort 后: ");
        SelectionSort(arr);
        PrintArr(arr);
    }

    //冒泡函数方法体
    public void BubbleSort(int[] arr)
    {
        //临时变量，用于冒泡交换
        int tmp;
        //用于提前结束排序的标识
        bool isSort;
        for (int i = 0; i < arr.Length; i++)
        {
            isSort = false;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                //交换
                if (arr[j] > arr[j + 1])
                {
                    tmp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = tmp;
                    isSort = true;
                }
            }

            //如果未进行排序，则提前结束循环
            if (!isSort)
                break;
        }
    }

    //选择排序
    public void SelectionSort(int[] arr)
    {
        //临时变量，用于冒泡交换
        int tmp;
        for (int i = 0; i < arr.Length; i++)
        {
            int maxIndex = 0;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[maxIndex] < arr[j + 1])
                {
                    maxIndex = j + 1;
                }
            }

            if (maxIndex != arr.Length - 1 - i)
            {
                tmp = arr[maxIndex];
                arr[maxIndex] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = tmp;
            }
        }
    }

    //生成数组
    public int[] GenerateArr(int size)
    {
        int[] arr = new int[size];
        Random random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(0, 100);
        }

        return arr;
    }

    //打印数组
    public void PrintArr(int[] arr)
    {
        StringBuilder sb = new StringBuilder();
        foreach (int i in arr)
        {
            sb.Append(i + ", ");
        }

        sb.Remove(sb.Length - 2, 2);
        output.WriteLine(sb.ToString());
    }
}