namespace 进阶.反射;

/// <summary>
/// 特性
/// </summary>
public class AttributeT : MyBasePrintClass
{
    public AttributeT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "自定义特性的基本使用")]
    public void Test1()
    {
        MyTestClass obj = new MyTestClass();
        Type type = obj.GetType();
        //判断是否使用了某个特性
        //参数一：特性的类型
        //参数二：代表是否搜索继承链（属性和事件忽略此参数）
        if (type.IsDefined(typeof(MyCustomAttribute), false))
        {
            output.WriteLine("使用了 MyCustomAttribute 特性");
        }

        //获取type元数据中的所有特性，这里 true 即会搜索继承链上的
        object[] array = type.GetCustomAttributes(true);
        foreach (var item in array)
        {
            //当前特性为 MyCustomAttribute
            if (item is MyCustomAttribute)
            {
                MyCustomAttribute arrributeItem = item as MyCustomAttribute;
                output.WriteLine(arrributeItem.info);
                arrributeItem.TestFun();
            }
        }
    }

    /// <summary>
    /// c#官方特性
    /// 
    /// [Obsolete("OldFun 方法以及过时了", false)]
    /// 参数一：调用方法时 提示的内容
    /// 参数二：true-使用该方法时会报错 false-使用该方法时直接警告
    /// 
    /// [Conditional]
    /// 配合预处理指令 #define 使用，可以实现根据系统环境等确定代码要不要执行
    /// </summary>
    public void Test2()
    {
    }
}

/// <summary>
/// Attribute - 继承该抽象类的即为自定义特性
/// 自定义的特性以 Attribute 后缀结尾的情况下，使用时可以省略
///
/// AttributeUsage - 作用域
/// AllowMultiple 是否允许同个特性的多个实例用在同一个目标上
/// Inherited 特性是否能被派生类和重写成员继承
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Method |
    AttributeTargets.Parameter,
    AllowMultiple = false, Inherited = true)]
class MyCustomAttribute : Attribute
{
    public string info;

    public MyCustomAttribute(String info)
    {
        this.info = info;
    }

    public void TestFun()
    {
        Console.WriteLine("特性的方法");
    }
}

//MyCustomAttribute 可以省略 Attribute 后缀
[MyCustom("这是用于计算的类")]
class MyTestClass
{
    [MyCustom("这是成员变量")] public int value;

    [MyCustom("这是用于计算加法的函数")]
    public void TestFun([MyCustom("函数参数")] int a)
    {
    }
}