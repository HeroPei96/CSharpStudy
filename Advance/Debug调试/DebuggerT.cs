using System.Diagnostics;

namespace 进阶.Debug调试;

public class DebuggerT : MyBasePrintClass
{
    public DebuggerT(ITestOutputHelper output) : base(output)
    {
    }

    //可以在 Debug 断点调试时，直观显示对象属性值，私有变量也有效
    [Fact(DisplayName = "DebuggerDisplay 的使用")]
    public void Test1()
    {
        Model model = new Model();
        model.Init();
        //需手动在此处打断点观察
        WriteMark();
    }
}

[DebuggerDisplay("{id}, {name}, {age}")]
class Model
{
    public int id { get; set; }
    public string name;
    private int age;

    //设置 Debug 展示模式为: 永不显示
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string numberPhone;

    //该特性表示 Debug 时不会进入该方法
    [DebuggerHidden]
    public void Init()
    {
        id = 1001;
        name = "HeroP";
        age = 18;
        numberPhone = "012345678";
    }
}