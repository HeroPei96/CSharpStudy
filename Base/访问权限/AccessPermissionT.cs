namespace 基础.访问权限;

/// <summary>
/// 访问权限
/// 通常情况下 public > internal > protected > private
/// public: 任何地方都可访问
/// internal: 当前程序集中可以访问
/// protected: 当前类和子类可以访问，无论是否在同一程序集中都有效，如果要限定同一程序集可以使用 private protected
/// private: 仅当前类可以访问
///
/// 访问修饰符可以组合使用
/// protected internal: 当前程序集 & 无论派生类是否在当前程序集中，都可以访问。相当于或关键字
/// private protected: 当前程序集内的派生类
/// </summary>
public class AccessPermissionT : MyBasePrintClass
{
    public AccessPermissionT(ITestOutputHelper output) : base(output)
    {
    }
}