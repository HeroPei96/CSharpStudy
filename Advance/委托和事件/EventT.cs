namespace 进阶.委托和事件;

/// <summary>
/// Event - 事件
/// 基于委托的存在，让委托的使用更具有安全性
/// 事件不能在类外部 “赋值”和“调用”，但可以 “+/-”
/// 只能声明为 “成员变量” 存在于类和接口以及结构体中，相当于事件 event 是 private
/// </summary>
public class EventT : MyBasePrintClass
{
    public EventT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        EventTest eventTest = new EventTest();
        //不能在类外部 赋值
        //eventTest.myEvent = Fun1;
        //但是可以在类外部 +/-
        eventTest.myEvent += Fun1;
        //不能在类外部 执行 invoke
        //eventTest.myEvent();
    }

    public void Fun1()
    {
        WriteLine("Fun1 执行了");
    }

    public int Fun2(int value)
    {
        WriteLine($"Fun2 执行了, 参数: {value}");
        return value * 2;
    }
}

class EventTest
{
    //声明事件
    public event Action myEvent;
}