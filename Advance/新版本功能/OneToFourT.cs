namespace 进阶.新版本功能;

/// <summary>
/// C# 1~4 新功能
/// </summary>
public class OneToFourT : MyBasePrintClass
{
    public OneToFourT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "命名参数")]
    public void Test1()
    {
        Test(f: 3.3f, b: false, i: 10);
    }

    public void Test(int i, float f, bool b)
    {
    }

    //dynamic 动态类型最好不要使用，某些场景下可以代替反射使用
    //可以用来存储任意类型对象
    //如果 Unity 使用 IL2CPP 则无法使用
    [Fact(DisplayName = "动态类型")]
    public void Test2()
    {
        dynamic dyn = 1;
        object obj = 2;
    }
}