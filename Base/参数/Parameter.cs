namespace 基础.特殊参数;

/// <summary>
/// 特殊参数
/// ref & out 在函数中的使用
/// params 变长参数
/// </summary>
public class Parameter : MyBasePrintClass
{
    public Parameter(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// ref 在函数调用时本质上不会创建新的变量进行 赋值/引用，所以函数内参数改动都是针对于同一变量
    /// ref 在使用时 函数声明上对应的参数要加 ref，调用函数时，对应的参数也要加 ref
    /// ref 修饰参数在函数调用前“必须初始化”，引用类型可以初始化为 null
    /// </summary>
    [Fact(DisplayName = "ref 在函数中使用")]
    public void Test1()
    {
        string value = null;
        //调用时必须添加 ref 关键字
        MyFunc(ref value);
        output.WriteLine(value);
        void MyFunc(ref string value)
        {
            value = new string("RefStr");
        }
    }

    /// <summary>
    /// out 作用同 ref
    /// out 使用方法同 ref
    /// out 修饰的参数必须在函数内初始化，在调用函数前没有必要赋值(因为函数内会再此进行初始化)
    /// </summary>
    [Fact(DisplayName = "out 在函数中使用")]
    public void Test2()
    {
        int value;
        //调用时必须添加 out 关键字
        MyFunc(out value);
        output.WriteLine($"value: {value}");

        //简便写法，out 修饰的参数可以无需在外部声明
        MyFunc(out int myValue);
        output.WriteLine($"myValue: {myValue}");

        void MyFunc(out int value)
        {
            //out 修饰的参数必须在函数内初始化
            value = 2;
            value = value * 2;
        }
    }

    /// <summary>
    /// 用于传入多个参数(可变参数长度)
    /// params 变长参数 一定是最后的一组参数
    /// params 变长参数 只能有一个
    /// </summary>
    [Fact(DisplayName = "params 变长参数")]
    public void Test3()
    {
        MyFunc("HeroP", 2, 4, "abc", "123", "qwe");

        void MyFunc(string name, int a, int b, params string[] strs)
        {
            output.WriteLine($"我的名字是: {name}");
            output.WriteLine($"a + b = {a + b}");
            for (int i = 0; i < strs.Length; i++)
            {
                output.WriteLine($"str{i}: {strs[i]}");
            }
        }
    }


    /// <summary>
    /// 默认值参数 可以有多个
    /// 若参数混用，那么默认值参数一定在普通参数后面
    /// 如果有变长参数，那么变长参数在最后
    /// </summary>
    [Fact(DisplayName = "默认值参数")]
    public void Test4()
    {
        MyFunc("HeroP");

        //如果默认值参数和普通参数混用，那么“默认值参数一定要在普通参数后面”(如果有变长参数，那么变长参数在最后)
        void MyFunc(string name, string str = "沉默是金")
        {
            output.WriteLine(name + str);
        }
    }
}