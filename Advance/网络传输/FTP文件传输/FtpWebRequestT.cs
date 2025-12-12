using System.Net;

namespace 进阶.网络传输.FTP文件传输;

public class FtpWebRequestT : MyBaseFtpClass
{
    public FtpWebRequestT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "上传文件")]
    public void Test1()
    {
        //创建新的WebRequest，用于进行Ftp相关操作，上传时，远端可以没有这个文件，如果有最终上传后会覆盖
        FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri($"{GetNasPath()}/用于测试上传.txt")) as FtpWebRequest;
        //设置通信凭证
        NetworkCredential credential = GetCredential();
        ftpWebRequest.Credentials = credential;
        //请求完毕后关闭控制连接
        ftpWebRequest.KeepAlive = false;
        //设置操作命令
        ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
        //设置为二进制数据传输
        ftpWebRequest.UseBinary = true;

        //获取用于文件上传的流
        Stream requestStream = ftpWebRequest.GetRequestStream();
        string filePath = GetTestFilePath() + "用于测试上传.txt";
        using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            fileStream.CopyTo(requestStream);
        }

        requestStream.Close();
        WriteLine("上传完毕");
    }

    [Fact(DisplayName = "下载文件")]
    public void Test2()
    {
        //下载时，远端必须要有这个文件
        FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri($"{GetNasPath()}/用于测试下载.txt")) as FtpWebRequest;
        NetworkCredential credential = GetCredential();
        ftpWebRequest.Credentials = credential;
        ftpWebRequest.KeepAlive = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
        ftpWebRequest.UseBinary = true;


        FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
        Stream downLoadStream = ftpWebResponse.GetResponseStream();
        string filePath = GetTestFilePath() + "用于测试下载.txt";
        using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            downLoadStream.CopyTo(fileStream);
        }

        downLoadStream.Close();
        WriteLine("下载完毕");
    }

    [Fact(DisplayName = "删除文件")]
    public void Test3()
    {
        //远端必须要有这个文件
        FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri($"{GetNasPath()}/用于测试删除.txt")) as FtpWebRequest;
        NetworkCredential credential = GetCredential();
        ftpWebRequest.Credentials = credential;
        ftpWebRequest.KeepAlive = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;
        ftpWebRequest.UseBinary = true;

        //真正的删除，只要获取响应就会去发送删除命令
        FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
        ftpWebResponse.Close();
        WriteLine("删除完毕");
    }

    [Fact(DisplayName = "获取文件大小")]
    public void Test4()
    {
        //远端必须要有这个文件
        FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri($"{GetNasPath()}/用于测试下载.txt")) as FtpWebRequest;
        NetworkCredential credential = GetCredential();
        ftpWebRequest.Credentials = credential;
        ftpWebRequest.KeepAlive = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.GetFileSize;
        ftpWebRequest.UseBinary = true;

        //只要获取响应就会去发送请求
        FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
        ftpWebResponse.Close();
        WriteLine($"文件大小为: {ftpWebResponse.ContentLength} 字节");
    }

    [Fact(DisplayName = "创建目录")]
    public void Test5()
    {
        FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri($"{GetNasPath()}/myDirectory")) as FtpWebRequest;
        NetworkCredential credential = GetCredential();
        ftpWebRequest.Credentials = credential;
        ftpWebRequest.KeepAlive = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
        ftpWebRequest.UseBinary = true;

        //只要获取响应就会去发送请求
        FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
        ftpWebResponse.Close();
        WriteLine("创建目录成功");
    }

    [Fact(DisplayName = "获取目录下所有文件名")]
    public void Test6()
    {
        //远端必须要有这个文件目录
        FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri($"{GetNasPath()}/")) as FtpWebRequest;
        NetworkCredential credential = GetCredential();
        ftpWebRequest.Credentials = credential;
        ftpWebRequest.KeepAlive = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
        ftpWebRequest.UseBinary = true;

        //只要获取响应就会去发送请求
        FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
        Stream stream = ftpWebResponse.GetResponseStream();
        //StreamReader 可以一行一行读取信息
        StreamReader streamReader = new StreamReader(stream);
        string line = streamReader.ReadLine();
        while (line != null)
        {
            //打印文件或目录名
            WriteLine(line);
            line = streamReader.ReadLine();
        }

        ftpWebResponse.Close();
    }
}