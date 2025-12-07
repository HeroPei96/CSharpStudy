#define MyPrint1
using System.Diagnostics;

namespace 进阶.预处理指令;

public class ConditionalT : MyBasePrintClass
{
    public ConditionalT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "配合预处理指令限制函数的调用")]
    public void Test1()
    {
        WriteLine("打印了吗？");
        MyFunc1();
        //没有通过 #define 定义就无法调用
        MyFunc2();
    }

    //IDE Debug模式运行时，通常会自带预编译指令 #define DEBUG。届时可配合使用
    //注意，Rider中需点击启动工具旁的编辑配置下拉框，手动选择 Release或Debug 模式
    [Fact(DisplayName = "DEBUG 的使用")]
    public void Test2()
    {
        WriteLine("打印了吗？");
        MyFunc3();
    }

    [Conditional("MyPrint1")]
    private void MyFunc1()
    {
        WriteLine("打印了 MyFunc1");
    }

    [Conditional("MyPrint2")]
    private void MyFunc2()
    {
        WriteLine("打印了 MyFunc2");
    }

    [Conditional("DEBUG")]
    private void MyFunc3()
    {
        WriteLine("打印了 MyFunc3");
    }
}