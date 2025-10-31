namespace 进阶.特殊语法;

/// <summary>
/// 参数相关
/// </summary>
public class Parameter : MyBasePrintClass
{
    public Parameter(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "命名参数 和 可选参数")]
    public void Test1()
    {
        //传参调用时，通过 : 赋值的参数无需固定位置，一般用于可选参数不传的情况下
        Test1Foo("HeroP", age: 20, true);
        Test1Foo("Tom", alive: false);
        Test1Foo("John");
    }

    //参数带默认值的为 可选参数 调用时可以不传
    public void Test1Foo(string name, int age = 18, bool alive = true)
    {
        output.WriteLine($"name: {name}, age: {age}, alive: {alive}");
    }
}