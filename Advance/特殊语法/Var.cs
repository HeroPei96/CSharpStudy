namespace 进阶.特殊语法;

/// <summary>
/// var 是一种特殊的变量类型 可以用来表示任意类型
/// var “必须初始化”（为了让编译器推测出类型）
/// var “不能作为类的成员” 只能用于临时变量声明时使用（一般写在函数语句块中）
/// 协同开发下不建议使用
/// </summary>
public class Var : MyBasePrintClass
{
    public Var(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "")]
    public void Test1()
    {
        var i = 5;
        var s = "123";
        var array = new int[] { 1, 2, 3, 4 };
        var list = new List<int>();
    }
}