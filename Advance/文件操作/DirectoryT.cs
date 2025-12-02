namespace 进阶.文件操作;

/// <summary>
/// Directory 文件夹类
/// </summary>
public class DirectoryT : MyFileBase
{
    public DirectoryT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "判断文件夹是否存在")]
    public void Test1()
    {
        output.WriteLine($"当前文件夹: {GetTestFilePath()}");
        output.WriteLine($"当前文件夹是否存在: {Directory.Exists(GetTestFilePath())}");
    }

    [Fact(DisplayName = "创建文件夹")]
    public void Test2()
    {
        //如果文件夹存在则不会创建
        Directory.CreateDirectory($"{GetTestFilePath()}/测试文件夹");
        output.WriteLine($"文件夹创建成功");
    }

    [Fact(DisplayName = "删除文件夹")]
    public void Test3()
    {
        //删除时文件夹不存在则会报错
        //参数二 是否删除非空目录
        //  true 如果该目录下有文件，那么会被一并删除
        //  false 如果该目录下有文件，那么该目录不会被删除
        Directory.Delete($"{GetTestFilePath()}/测试文件夹", false);
        output.WriteLine($"文件夹删除成功");
    }

    [Fact(DisplayName = "获取指定路径下文件夹和文件")]
    public void Test4()
    {
        Directory.CreateDirectory($"{GetTestFilePath()}/测试文件夹");
        //获取当前路径下的文件夹名称列表(不含文件，子级的子级不会去获取)
        string[] directories = Directory.GetDirectories(GetTestFilePath());
        foreach (string item in directories)
        {
            output.WriteLine($"当前文件夹路径为: {item}");
        }

        //获取当前路径下的文件名称列表(不含子级的子级)
        string[] files = Directory.GetFiles(GetTestFilePath());
        foreach (string item in files)
        {
            output.WriteLine($"当前文件路径为: {item}");
        }
    }

    [Fact(DisplayName = "移动文件夹")]
    public void Test5()
    {
        Directory.CreateDirectory($"{GetTestFilePath()}/测试文件夹1");
        FileStream fs = File.Create($"{GetTestFilePath()}/测试文件夹1/1.txt");
        fs.Close();
        //！！！注意 目标路径的文件夹如果已存在则会报错
        //其实就是新建一个目标路径的文件夹，把源路径文件夹下的内容都移动过去(剪切)，然后把源目录文件夹删除
        Directory.Move($"{GetTestFilePath()}/测试文件夹1", $"{GetTestFilePath()}/测试文件夹2");
    }
}