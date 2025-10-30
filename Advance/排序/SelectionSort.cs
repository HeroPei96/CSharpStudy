using System.Text;

namespace 进阶.排序;

/// <summary>
/// 选择排序：每一轮都找到一个最小的元素，将其与前排交换位置
///   从第一位开始和后面的比较，直到找到最小的并和第一位调换位置
/// 再从第二位开始和后面的比较，直到找到最小的并和第二位调换位置
/// ...
/// </summary>
public class SelectionSort : MyBasePrintClass
{
    public SelectionSort(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "选择排序")]
    public void Test1()
    {
        int[] arr = DataSort.GenerateArr(5);

        output.WriteLine("Sort 前: ");
        PrintArr(arr);
        output.WriteLine("Sort 后: ");
        Sort(arr);
        PrintArr(arr);
    }

    //选择排序
    public void Sort(int[] arr)
    {
        //临时变量，用于交换
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