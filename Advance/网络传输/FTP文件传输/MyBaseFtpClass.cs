using System.Net;

namespace 进阶.网络传输.FTP文件传输;

public class MyBaseFtpClass : MyBasePrintClass
{
    //NasIP
    protected string NasIp => "192.168.31.236";
    protected string NasUsername => "HeroPei";
    protected string NasPassword => "Phj@nas123";

    public MyBaseFtpClass(ITestOutputHelper output) : base(output)
    {
    }

    protected NetworkCredential GetCredential()
    {
        return new NetworkCredential(NasUsername, NasPassword);
    }

    protected string GetNasPath()
    {
        return $"ftp://{NasIp}/DATA_2/FTPTest";
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
        return GetCurrentPath() + "/网络传输/FTP文件传输/测试文件/";
    }
}