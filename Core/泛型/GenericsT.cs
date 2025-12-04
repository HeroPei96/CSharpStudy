namespace 核心.泛型;

/// <summary>
/// 泛型
/// </summary>
public class GenericsT : MyBasePrintClass
{
    public GenericsT(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    /// out 协变 修饰返回值
    /// in 逆变 修饰参数
    /// 只能出现在 “泛型接口” 和 “泛型委托/事件” 中
    /// </summary>
    [Fact(DisplayName = "协变和逆变")]
    public void Test1()
    {
        //协变 out 父类 装 子类
        TestOut<Son> outSon = () => new Son();
        TestOut<Father> outFather = outSon;
        Father father = outFather();

        //逆变 in 子类 装 父类
        TestIn<Father> inFather = (value) => { };
        TestIn<Son> inSon = inFather;
        inSon(new Son());
    }
}

/// <summary>
/// 泛型
/// 泛型约束分为 泛型类约束，泛型方法约束
/// 泛型约束可以组合使用，通过 , 组合 例如 where T : class, new()
/// 1. 值类型  where T:struct
/// 2. 引用类型 where T:class
/// 3. 存在无参公共构造函数   where T:new()
/// 4. 某个类及其子类  where T:类名
/// 5. 某个接口及其子类 where T:接口名
/// 6. 另一个泛型类型本身或者子类类型  where T:U(U本身或者U的子类)
/// </summary>
class TestClass<T1, T2, T3> where T1 : class where T2 : class where T3 : TestClass<T1, T2, T3>
{
    public T1 value1;
    public T2 value2;
    public T3 value3;

    //泛型方法
    public void TestFun<T>(T value) where T : class, new()
    {
    }
}

//协变
delegate T TestOut<out T>();

//逆变
delegate void TestIn<in T>(T value);

class Father
{
}

class Son : Father
{
}