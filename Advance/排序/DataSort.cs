namespace 进阶.排序;

/// <summary>
/// 要排序的数据
/// <see href="https://www.bilibili.com/video/BV1e8411M7Lr">排序动画推荐</see>
/// </summary>
public class DataSort
{
    //生成数组
    public static int[] GenerateArr(int size)
    {
        int[] arr = new int[size];
        Random random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(0, 100);
        }

        return arr;
    }
}