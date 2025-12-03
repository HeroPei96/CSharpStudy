namespace 进阶.文件操作;

public class MyFileBase : MyBasePrintClass
{
    public MyFileBase(ITestOutputHelper output) : base(output)
    {
    }

    //获取项目开发路径
    protected String GetCurrentPath()
    {
        string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        return Path.GetFullPath(Path.Combine(appBaseDirectory, @"../../.."));
    }

    //获取项目开发路径
    protected String GetTestFilePath()
    {
        return GetCurrentPath() + "/文件操作/测试文件/";
    }
}