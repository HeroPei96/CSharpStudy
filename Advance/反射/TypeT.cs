using System.Reflection;

namespace 进阶.反射;

/// <summary>
/// Type - 类信息
/// </summary>
public class TypeT : MyBasePrintClass
{
    public TypeT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "获取类 Type")]
    public void Test1()
    {
        //方式一：对象.GetType()
        int a = 100;
        Type type1 = a.GetType();
        output.WriteLine($"a.Type: {type1}");

        //方式二：通过 typeof 关键字
        Type type2 = typeof(int);
        output.WriteLine($"int.Type: {type2}");

        //方式三：Type.GetType(类名字符串);
        //类名字符串必须包含 “命名空间”
        Type? type3 = Type.GetType("System.Int32");
        output.WriteLine($"Type: {type3}");

        //type.Assembly 获取所在程序集
        output.WriteLine($"type 所在程序集为: {type1.Assembly}");
    }

    [Fact(DisplayName = "获取类中成员")]
    public void Test2()
    {
        Type type = typeof(TestType);

        //获取所有公共(public)的成员(变量&函数)，包含父类的
        MemberInfo[] memberInfos = type.GetMembers();
        foreach (MemberInfo item in memberInfos)
        {
            output.WriteLine($"MemberInfo: {item.Name}");
        }
    }

    [Fact(DisplayName = "Type - 构造函数")]
    public void Test3()
    {
        Type type = typeof(TestType);
        //获取所有公共(public)构造函数
        ConstructorInfo[] constructorInfos = type.GetConstructors();

        //获取到无参构造函数
        ConstructorInfo info1 = type.GetConstructor(new Type[0]);
        //若无参，要传 null
        TestType? obj1 = info1?.Invoke(null) as TestType;
        output.WriteLine($"无参构造器 obj.str: {obj1.str}");

        //获取有参构造函数
        ConstructorInfo? info2 = type.GetConstructor(new Type[] { typeof(int), typeof(int), typeof(string) });
        TestType? obj2 = info2?.Invoke(new object[] { 5, 8, "HeroP" }) as TestType;
        output.WriteLine($"有参构造器 obj.str: {obj2.str}");
    }

    [Fact(DisplayName = "Type - 成员变量")]
    public void Test4()
    {
        Type type = typeof(TestType);
        TestType obj = new TestType();

        //获取所有当前类的公共(public)成员变量，包含父类的
        FieldInfo[] fieldInfos = type.GetFields();

        //获取某个公共(public)成员变量，包含父类的
        FieldInfo fieldStr = type.GetField("str");

        //设置 和 获取 成员变量值
        fieldStr.SetValue(obj, "HelloP");
        string strValue = fieldStr.GetValue(obj) as string;
        output.WriteLine($"obj.str: {strValue}");
    }

    [Fact(DisplayName = "Type - 成员方法")]
    public void Test5()
    {
        Type type = typeof(TestType);
        TestType obj = new TestType();

        //获取当前类的所有公共方法，包含父类的
        MethodInfo[] methodInfos = type.GetMethods();

        //无参的简便写法，如果有重载函数，那么不能这么调用
        // MethodInfo methodInfo = type.GetMethod("Speak");
        //有几个参数就是几，0表示无参
        MethodInfo methodInfo = type.GetMethod("Speak", new Type[0]);
        output.WriteLine(methodInfo.Invoke(obj, null).ToString());

        methodInfo = type.GetMethod("Speak", new Type[1] { typeof(string) });
        output.WriteLine(methodInfo.Invoke(obj, new[] { "Hello" }).ToString());
    }

    [Fact(DisplayName = "Type - 其他成员")]
    public void Test6()
    {
        //枚举
        //GetEnumName

        //事件
        //GetEvent

        //接口
        //GetInterface

        //属性
        //GetProperty
    }
}

public class TestType
{
    private int i = 1;
    public int j = 0;
    public string str = "123";

    public TestType()
    {
    }

    public TestType(int i)
    {
        this.i = i;
    }

    public TestType(int i, int j, string str)
    {
        this.i = i;
        this.j = j;
        this.str = str;
    }

    public int Speak()
    {
        return i;
    }

    public string Speak(string str)
    {
        return str;
    }
}