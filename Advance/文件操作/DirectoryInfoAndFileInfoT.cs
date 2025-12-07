namespace 进阶.文件操作;

/// <summary>
/// DirectoryInfo & FileInfo
/// 文件夹信息类 & 文件信息类
/// </summary>
public class DirectoryInfoAndFileInfoT : MyFileBase
{
    public DirectoryInfoAndFileInfoT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "基本使用")]
    public void Test1()
    {
        DirectoryInfo dInfo = Directory.CreateDirectory($"{GetTestFilePath()}");
        //全路径
        output.WriteLine($"当前文件夹全路径: {dInfo.FullName}");
        //文件夹名
        output.WriteLine($"当前文件夹名: {dInfo.Name}");
        //上级文件夹信息
        output.WriteLine($"上级文件夹全路径: {dInfo.Parent?.FullName}，上级文件夹名称: {dInfo.Parent?.Name}");

        //得到所有子文件夹信息(不含子级的子级)
        DirectoryInfo[] directories = dInfo.GetDirectories();
        foreach (DirectoryInfo item in directories)
        {
            output.WriteLine($"包含的文件夹名: {item.Name}");
        }

        WriteMark();
        //得到所有子文件信息(不含子级的子级)
        FileInfo[] files = dInfo.GetFiles();
        foreach (FileInfo item in files)
        {
            output.WriteLine($"包含的文件名: {item.Name}");
            output.WriteLine($"包含的文件全路径: {item.FullName}");
            output.WriteLine($"包含的文件字节长度: {item.Length}，文件后缀: {item.Extension}");
            output.WriteLine("-----");
            //打开文件流
            //FileStream fileStream = item.Open(FileMode.Open);
        }
    }
}