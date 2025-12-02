namespace 进阶.文件操作;

public class MyFileBase : MyBasePrintClass
{
    protected String currentPath = "D:/workSpace/CSharp/CSharpStudy/03-核心/03-文件操作/测试文件";

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