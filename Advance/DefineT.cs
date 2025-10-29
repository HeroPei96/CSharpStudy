#define test
// #undef test


namespace 进阶;

/// <summary>
/// 预处理指令
/// 通过定义一些符号，告诉编译器是否需要编译相关代码段
/// #define 用于定义符号 需要写在脚本文件开头(比namespace还要前)
/// #undef 取消定义符号
/// #if #elif #endif 配对使用，表示 如果定义了该符号，则指令内代码参与编译
/// #if #elif 支持逻辑运算符 && ||
///
/// 其他指令
/// #warning 警告
/// #error 错误
/// </summary>
public class DefineT : MyBasePrintClass
{
    public DefineT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
#if test
        output.WriteLine("test");
#endif
    }
}