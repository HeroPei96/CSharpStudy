using Xunit.Abstractions;

namespace 基础;

/// <summary>
/// 函数
/// ref & out 在函数中的使用
/// </summary>
public class Function : MyBasePrintClass
{
    public Function(ITestOutputHelper output) : base(output)
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
        ChangeRefValue(ref value);
        output.WriteLine(value);
    }

    private void ChangeRefValue(ref string value)
    {
        value = new string("RefStr");
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
        ChangeOutValue(out value);
        output.WriteLine(value.ToString());
    }

    private void ChangeOutValue(out int value)
    {
        //out 修饰的参数必须在函数内初始化
        value = 2;
        value = value * 2;
    }
}