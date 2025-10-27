namespace 进阶;

/// <summary>
/// 泛型
/// </summary>
public class GenericsT : MyBasePrintClass
{
    public GenericsT(ITestOutputHelper output) : base(output)
    {
    }
}

/// <summary>
/// 泛型
/// 泛型约束 泛型类约束，泛型方法约束
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