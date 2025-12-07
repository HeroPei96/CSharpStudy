namespace 进阶.新版本功能;

/// <summary>
/// C# 8 新功能
/// Case筛选器
/// </summary>
public partial class SevenT
{
    [Fact(DisplayName = "Case筛选器")]
    public void Test11()
    {
        MyFunc(1, 2);
        WriteMark();
        MyFunc(5, 5);

        void MyFunc(int a, int b)
        {
            switch (a, b)
            {
                //case 筛选中还可以用 When 来进一步筛选
                case (> 0, > 0) when a == b:
                    WriteLine("a>0 & b>0 & a==b");
                    break;
                case (> 0, > 0):
                    WriteLine("a>0 & b>0");
                    break;
                default:
                    WriteLine("default");
                    break;
            }
        }
    }
}