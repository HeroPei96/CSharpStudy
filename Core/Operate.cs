namespace 核心;

/// <summary>
/// 运算符重载
/// </summary>
public class Operate : MyBasePrintClass
{
    public Operate(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "运算符重载")]
    public void Test1()
    {
        Point p1 = new Point(1, 2);
        Point p2 = new Point(6, 7);
        Point p3 = p1 + p2;
        output.WriteLine($"x: {p3.x}, y: {p3.y}");
    }
}

public class Point
{
    public int x;
    public int y;

    public Point()
    {
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// 为 Point 重载 + 方法
    /// 一定是一个公共的静态方法(public static)
    /// 返回值写在 operator 前
    /// 不能使用 ref 和 out
    /// 至少有一个参数的类型和当前对象类一致（也就是说可以 + 其他类型）
    /// 条件运算符必须成对实现，例如 有 == 运算符重载那也必须有 !=
    /// </summary>
    public static Point operator +(Point p1, Point p2)
    {
        Point p = new Point();
        p.x = p1.x + p2.x;
        p.y = p1.y + p2.y;
        return p;
    }
}