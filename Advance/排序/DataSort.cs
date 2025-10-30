namespace 进阶.排序;

/// <summary>
/// 要排序的数据
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