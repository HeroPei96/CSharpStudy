using System.Text;

namespace 进阶.排序;

/// <summary>
/// 快速排序
/// <see href="https://www.bilibili.com/video/BV1m84y1n7xb">快速排序 动画</see>
/// 要配合递归执行
/// </summary>
public class QuickSort : MyBasePrintClass
{
    public QuickSort(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "快速排序")]
    public void Test1()
    {
        int[] arr = DataSort.GenerateArr(11);

        output.WriteLine("Sort 前: ");
        PrintArr(arr);
        output.WriteLine("Sort 后: ");
        Sort(arr, 0, arr.Length - 1);
        PrintArr(arr);
    }

    /// <summary>
    /// 需要被递归调用，所以边界需要手动传入
    /// </summary>
    /// <param name="array">要调整的数组</param>
    /// <param name="left">要调整的 数组/子数组 左边界</param>
    /// <param name="right">要调整的 数组/子数组 右边界</param>
    public void Sort(int[] array, int left, int right)
    {
        if (left >= right)
            return;

        //索引 左游标和右游标
        int tempLeft = left;
        int tempRight = right;

        //元素 第一个基准值
        int temp = array[left];

        while (left != right)
        {
            //先移动右侧游标
            while (tempLeft < tempRight && temp < array[tempRight])
            {
                tempRight--;
            }

            //移动结束证明可以换位置
            array[tempLeft] = array[tempRight];

            //再移动左侧游标
            while (tempLeft < tempRight && temp > array[tempLeft])
            {
                tempLeft++;
            }

            //移动结束证明可以换位置
            array[tempRight] = array[tempLeft];
        }

        //放置基准值
        //跳出循环后 把基准值放在中间位置
        //此时tempRight和tempLeft一定是相等的
        array[tempRight] = temp;

        //递归执行
        //左子数组
        Sort(array, left, tempRight - 1);
        Sort(array, tempRight + 1, right);
        //右子数组
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