using System.Text;

namespace 进阶.排序;

/// <summary>
/// <see href="https://www.bilibili.com/video/BV1Y8411T7LC">插入排序 动画</see>
/// 插入排序：从第二个元素开始，将其与前排比较并交换位置
/// 与冒泡逻辑相似，区别是 从第二位开始，将较小值与前排冒泡交换
/// </summary>
public class InsertionSort : MyBasePrintClass
{
    public InsertionSort(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "插入排序")]
    public void Test1()
    {
        int[] arr = DataSort.GenerateArr(10);

        output.WriteLine("Sort 前: ");
        PrintArr(arr);
        output.WriteLine("Sort 后: ");
        Sort(arr);
        PrintArr(arr);
    }

    //排序
    public void Sort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            //未排序区的第一个元素
            int noSortNum = arr[i];
            //排序区的最后一个元素索引
            int sortIndex = i - 1;
            while (sortIndex >= 0 && arr[sortIndex] > noSortNum)
            {
                //有点抽象，需结合排序动画
                arr[sortIndex + 1] = arr[sortIndex];
                sortIndex--;
            }

            arr[sortIndex + 1] = noSortNum;
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