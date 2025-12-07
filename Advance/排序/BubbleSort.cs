using System.Text;

namespace 进阶.排序;

/// <summary>
/// 冒泡排序：从头开始，相邻的两个元素不断比较，直到把最大的排到后排
/// 第一轮
///   第一位和第二位比较，如果第一位大于第二位，则交换他们的位置
///   第二位和第三位比较，如果第二位大于第三位，则交换他们的位置
///   ...
///   第n-1和第n位比较，如果第n-1位大于第n位，则交换他们的位置
/// 第二轮
///   第一位和第二位比较，如果第一位大于第二位，则交换他们的位置
///   第二位和第三位比较，如果第二位大于第三位，则交换他们的位置
///   ...
///   第n-2和第n-1位比较，如果第n-2位大于第n-1位，则交换他们的位置
/// ...
/// </summary>
public class BubbleSort : MyBasePrintClass
{
    public BubbleSort(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "冒泡排序")]
    public void Test1()
    {
        int[] arr = DataSort.GenerateArr(5);

        WriteLine("Sort 前: ");
        PrintArr(arr);
        WriteLine("Sort 后: ");
        Sort(arr);
        PrintArr(arr);
    }

    //冒泡函数方法体
    public void Sort(int[] arr)
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

    //打印数组
    public void PrintArr(int[] arr)
    {
        StringBuilder sb = new StringBuilder();
        foreach (int i in arr)
        {
            sb.Append(i + ", ");
        }

        sb.Remove(sb.Length - 2, 2);
        WriteLine(sb.ToString());
    }
}