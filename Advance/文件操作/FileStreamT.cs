using System.Text;

namespace 进阶.文件操作;

/// <summary>
/// FileStream 文件流类
/// </summary>
public class FileStreamT : MyFileBase
{
    public FileStreamT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "获取文件流")]
    public void Test1()
    {
        string filePath = GetTestFilePath() + "test.txt";

        //参数释义同 File.Open
        FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
        //同
        // fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
    }

    [Fact(DisplayName = "基本属性和方法")]
    public void Test2()
    {
        string filePath = GetTestFilePath() + "test.txt";
        FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write);

        output.WriteLine($"文本字节长度: {fileStream.Length}");
        output.WriteLine($"是否可写: {fileStream.CanWrite}");
        output.WriteLine($"是否可读: {fileStream.CanRead}");

        byte[] bytes = Encoding.UTF8.GetBytes("HeroP");
        //往字节流写入内容
        fileStream.Write(bytes);

        //将缓存中的内容写入文件。写操作不是实时发生的，写入的数据会先放入缓存中
        fileStream.Flush();
        //缓存资源销毁回收，使用 using 包裹会自动回收
        fileStream.Dispose();
    }

    [Fact(DisplayName = "通过字节写入字符串")]
    public void Test3()
    {
        string filePath = GetTestFilePath() + "test.txt";
        using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            byte[] strBytes = Encoding.UTF8.GetBytes("你好！HeroP");
            int strBytesLength = strBytes.Length;
            //写入字符串字节数组时要先写入长度。因为通过字节流读取时，也要先知道字符数字节数组的长度。
            //参数一 要写入的字节数组
            //参数二 开始写入的字节索引
            //参数二 要写入的字节数组长度
            fileStream.Write(BitConverter.GetBytes(strBytesLength), 0, sizeof(int));
            fileStream.Write(strBytes, 0, strBytesLength);

            //将缓存中字节数据写入
            fileStream.Flush();
        }
    }

    //读和存要匹配，怎么存的就要怎么读
    [Fact(DisplayName = "读取字符串内容(先读取字符串长度再读取内容)")]
    public void Test4()
    {
        string filePath = GetTestFilePath() + "test.txt";
        using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            //先读取字符串长度，长度再写入的时候用了一个 int数值 表示
            byte[] bytes = new byte[sizeof(int)];
            fileStream.Read(bytes, 0, sizeof(int));
            int strLength = BitConverter.ToInt32(bytes);
            output.WriteLine($"字符串长度为: {strLength}");

            //字符串本质上就是一个字符数组，数组长度就是字符串的长度
            byte[] strBytes = new byte[strLength];
            //注意，这里的 offset 不是 size(int) 因为是建立在上一次读取位置的地方，而不是重头读取
            fileStream.Read(strBytes, 0, strLength);
            string str = Encoding.UTF8.GetString(strBytes);
            output.WriteLine($"字符串内容为: {str}");
        }
    }

    //读和存要匹配，怎么存的就要怎么读
    [Fact(DisplayName = "读取字符串内容(一次性全读取出来再挨个读取)")]
    public void Test5()
    {
        string filePath = GetTestFilePath() + "test.txt";
        using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            //先读取文件流中所有字节数据
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes);
            //读取出字符串长度
            int strLength = BitConverter.ToInt32(bytes, 0);
            output.WriteLine($"字符串长度为: {strLength}");
            //再读取字符串内容
            string str = Encoding.UTF8.GetString(bytes, sizeof(int), strLength);
            output.WriteLine($"字符串内容为: {str}");
        }
    }
}