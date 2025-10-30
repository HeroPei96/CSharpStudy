namespace 进阶.特殊语法;

/// <summary>
/// 语法糖 - ? 的空值处理
/// </summary>
public class Null : MyBasePrintClass
{
    public Null(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "值类型赋空")]
    public void Test1()
    {
        //这是不允许的
        //int a = null;

        //这样就可以赋值为空了
        //本质上类型为 Nullable<int>
        int? a = null;
        //使用时一定要判空
        if (a.HasValue)
        {
            //两种都可以
            output.WriteLine(a.Value.ToString());
            output.WriteLine(a.ToString());
        }

        //如果该值为空，使用默认值，默认值可自定义
        //！注意：GetValueOrDefault 内部调用的是 this.value 不是 Value
        output.WriteLine(a.GetValueOrDefault().ToString());
        output.WriteLine(a.GetValueOrDefault(10).ToString());
    }

    [Fact(DisplayName = "引用类型判空语法糖")]
    public void Test2()
    {
        object obj = null;
        //obj 不为空才会执行 tostring 方法
        obj?.ToString();

        int[] array = null;
        //一旦为空，后面的方法链都不会执行。所以接受的变量也可能为 null
        bool? equals = array?[0].ToString().Equals("123");
    }

    [Fact(DisplayName = "委托判空语法糖")]
    public void Test3()
    {
        Action action = null;
        action?.Invoke();
    }

    [Fact(DisplayName = "?? 空合并操作符")]
    public void Test4()
    {
        //就是三目运算符在 判空 逻辑时简便写法
        int? a = null;
        //如果 a 不为空就 b = a 否则 b = 100
        int b = a == null ? 100 : a.Value;

        //简便写法，逻辑同上
        int c = a ?? 100;
    }
}