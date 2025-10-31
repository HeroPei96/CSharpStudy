using System.Text;

namespace 进阶.排序;

/// <summary>
/// 希尔排序 - 升级版的插入排序
/// 多引入了步长的概念
/// </summary>
public class ShellSort : MyBasePrintClass
{
    public ShellSort(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "希尔排序")]
    public void Test1()
    {
        int[] arr = DataSort.GenerateArr(11);

        output.WriteLine("Sort 前: ");
        PrintArr(arr);
        output.WriteLine("Sort 后: ");
        Sort(arr);
        PrintArr(arr);
    }

    //希尔排序
    public void Sort(int[] arr)
    {
        //临时变量
        int temp = 0;
        //step 步长
        for (int step = arr.Length / 2; step > 0; step /= 2)
        {
            for (int i = step; i < arr.Length; i++)
            {
                //未排序区的第一个元素
                int noSortNum = arr[i];
                //排序区的最后一个元素索引
                int sortIndex = i - step;
                while (sortIndex >= 0 && arr[sortIndex] > noSortNum)
                {
                    //有点抽象，需结合排序动画
                    arr[sortIndex + step] = arr[sortIndex];
                    sortIndex -= step;
                }

                arr[sortIndex + step] = noSortNum;
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