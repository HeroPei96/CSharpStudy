namespace 进阶.新版本功能;

/// <summary>
/// C# 8 新功能
/// Index: 索引，正序索引和倒序索引
/// Range: 索引范围
/// </summary>
public partial class EightT
{
    //Index 表示索引
    [Fact(DisplayName = "Index 数据类型")]
    public void Test11()
    {
        int[] arr = new[] { 1, 2, 3, 4, 5 };
        //数据类型是 Index 或 Var
        //表示正序时，索引值从 0 开始
        Index index = 0;
        output.WriteLine($"arr 第 {index.Value} 个: {arr[index]}");

        //通过 ^ 表示倒序，索引值从 1 开始
        index = ^1;
        output.WriteLine($"arr 最后第 {index.Value} 个: {arr[index]}");
    }

    //Range 表示范围，含头不含尾
    [Fact(DisplayName = "Range 数据类型")]
    public void Test12()
    {
        int[] arr = new[] { 1, 2, 3, 4, 5 };
        //数据类型是 Range 或 Var
        Range range = 1..4;
        InnerFun();
        WriteMark();

        //符号前后可以省略
        range = 2..;
        InnerFun();
        WriteMark();
        range = ..3;
        InnerFun();
        WriteMark();
        
        //也可以配合 Index 使用
        range = 1..^2;
        InnerFun();
        
        void InnerFun()
        {
            foreach (int item in arr[range])
            {
                output.WriteLine($"item: {item}");
            }
        }
    }
}