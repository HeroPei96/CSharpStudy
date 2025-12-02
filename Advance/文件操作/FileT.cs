using System.Text;

namespace 进阶.文件操作;

/// <summary>
/// File 文件类
/// </summary>
public class FileT : MyFileBase
{
    public FileT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "判断文件是否存在")]
    public void Test1()
    {
        string filePath = GetTestFilePath() + "test.txt";
        output.WriteLine($"当前文件路径: {filePath}");
        if (File.Exists(filePath))
            output.WriteLine("文件存在");
        else
            output.WriteLine("文件不存在");
    }

    [Fact(DisplayName = "创建文件&删除文件")]
    public void Test2()
    {
        string filePath = GetTestFilePath() + "test.txt";
        output.WriteLine($"当前文件路径: {filePath}");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            output.WriteLine("文件删除成功");
        }
        else
        {
            File.Create(filePath);
            output.WriteLine("文件创建成功");
        }
    }

    [Fact(DisplayName = "将字节数组写入到文件中")]
    public void Test3()
    {
        string filePath = GetTestFilePath() + "writeTest.txt";
        if (!File.Exists(filePath))
            File.Create(filePath);

        string str = "测试一下把字节数组写入到文件中";
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        //注意: WriteAllBytes 会把原有内容都覆盖掉。相当于会把原有内容删除重新写入
        File.WriteAllBytes(filePath, bytes);
    }

    [Fact(DisplayName = "将字符串写入到文件中")]
    public void Test4()
    {
        string filePath = GetTestFilePath() + "writeTest.txt";
        if (!File.Exists(filePath))
            File.Create(filePath);

        string str = "测试一下把字符串写入到文件中";
        //注意: WriteAllBytes 会把原有内容都覆盖掉。相当于会把原有内容删除重新写入
        File.WriteAllText(filePath, str);
    }

    [Fact(DisplayName = "将字符串数组按行写入到文件中")]
    public void Test5()
    {
        string filePath = GetTestFilePath() + "writeTest.txt";
        if (!File.Exists(filePath))
            File.Create(filePath);

        string[] strs = new[] { "Hello", "World", "Hello", "HeroP" };
        //把字符串数组一行行写入到文件中
        //同样的 WriteAllBytes 也会把原有内容都覆盖掉
        File.WriteAllLines(filePath, strs);
    }

    [Fact(DisplayName = "从文件中读取字节数组")]
    public void Test6()
    {
        string filePath = GetTestFilePath() + "writeTest.txt";
        if (!File.Exists(filePath))
            return;
        //读取字节
        byte[] bytes = File.ReadAllBytes(filePath);
        //转为字符串
        string str = Encoding.UTF8.GetString(bytes);
        output.WriteLine($"读取到的字符串str: {str}");
    }

    [Fact(DisplayName = "从文件中读取字符串")]
    public void Test7()
    {
        string filePath = GetTestFilePath() + "writeTest.txt";
        if (!File.Exists(filePath))
            return;
        //读取字符串
        string str = File.ReadAllText(filePath);
        output.WriteLine($"读取到的字符串str: {str}");
    }

    [Fact(DisplayName = "从文件中读取字符串内容行数组")]
    public void Test8()
    {
        string filePath = GetTestFilePath() + "writeTest.txt";
        if (!File.Exists(filePath))
            return;
        //读取字符串行数组
        string[] strs = File.ReadAllLines(filePath);
        foreach (string str in strs)
        {
            output.WriteLine($"{str}");
        }
    }

    [Fact(DisplayName = "删除文件")]
    public void Test9()
    {
        string filePath = GetTestFilePath() + "writeTest.txt";
        if (!File.Exists(filePath))
            return;
        File.Delete(filePath);
        output.WriteLine("文件删除成功");
    }

    [Fact(DisplayName = "复制文件")]
    public void Test10()
    {
        string filePath = GetTestFilePath() + "test.txt";
        string copyPath = GetTestFilePath() + "testCopy.txt";
        //overwrite 如果已存在该文件，那么就覆盖它
        File.Copy(filePath, copyPath, true);
        output.WriteLine("文件复制成功");
    }

    [Fact(DisplayName = "替换文件")]
    public void Test11()
    {
        //用到的时候再去研究，一般用不上
        // File.Replace();
    }

    [Fact(DisplayName = "打开文件")]
    public void Test12()
    {
        string filePath = GetTestFilePath() + "test.txt";
        //参数一 文件路径
        //参数二 打开模式
        //  CreateNew 创建新文件，如果文件存在则报错
        //  Create 创建文件，若已存在，则覆盖
        //  Open 打开文件，若不存在则报错
        //  OpenOrCreate 用于打开文件，如果文件不存在则创建它。
        //  Append 若文件存在，打开并查找文件尾，不存在则新建一个文件
        //  Truncate 打开并清空文件内容
        //参数三 访问模式 - 对文件可执行的操作
        //  Read 读取
        //  Write 写入
        //  ReadWrite 读和写
        //参数四 访问模式 - 针对其他线程对该文件的访问
        //  None 谢绝共享
        //  Read 允许别的线程读取当前文件
        //  Write 允许别的线程写入该文件
        //  ReadWrite 允许别的线程读写该文件
        FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
    }
}