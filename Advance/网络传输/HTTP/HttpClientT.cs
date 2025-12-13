using System.Text;
using System.Text.Json;

namespace 进阶.网络传输.HTTP;

/// <summary>
/// HttpClient
/// HttpClient 旨在实例化一次，并在应用程序的整个生命周期内重复使用。
/// 在 .NET Core 和 .NET 5+ 中，HttpClient 会在处理程序实例内部管理连接池，并在多个请求之间重用连接。
/// 如果为每个请求实例化一个 HttpClient 类，在负载过大时，可用的套接字数量将会耗尽。
/// 如果耗尽，将导致 SocketException 错误
/// </summary>
public class HttpClientT : MyBasePrintClass
{
    public HttpClientT(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "Head 请求")]
    public void Test1()
    {
        Task task = GetUri();
        task.Wait();

        async Task GetUri()
        {
            HttpClient client = new HttpClient();
            //超时时间为 5s
            client.Timeout = TimeSpan.FromSeconds(5);
            string url = "https://cn.bing.com";
            //发送 Head 请求
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url);
            HttpResponseMessage response = await client.SendAsync(request);
            //检查响应状态码
            if (response.IsSuccessStatusCode)
            {
                WriteLine($"请求成功！状态码: {response.StatusCode}");
            }
            else
            {
                WriteLine($"请求失败，状态码: {(int)response.StatusCode} {response.ReasonPhrase}");
            }
        }
    }

    [Fact(DisplayName = "Get 请求")]
    public void Test2()
    {
        Task task = GetUri();
        task.Wait();

        async Task GetUri()
        {
            HttpClient client = new HttpClient();
            //超时时间为 5s
            client.Timeout = TimeSpan.FromSeconds(5);
            string url = "https://cn.bing.com";
            //发送 GET 请求
            HttpResponseMessage response = await client.GetAsync(url);
            //检查响应状态码
            if (response.IsSuccessStatusCode)
            {
                //读取响应内容（通常是字符串）
                string content = await response.Content.ReadAsStringAsync();

                WriteLine($"请求成功！状态码: {response.StatusCode}");
                WriteLine("响应内容:");
                WriteLine(content);
            }
            else
            {
                WriteLine($"请求失败，状态码: {(int)response.StatusCode} {response.ReasonPhrase}");
            }
        }
    }

    [Fact(DisplayName = "Post 请求")]
    public void Test3()
    {
        Task task = GetUri();
        task.Wait();

        async Task GetUri()
        {
            HttpClient client = new HttpClient();
            //超时时间为 5s
            client.Timeout = TimeSpan.FromSeconds(5);
            //请求地址和请求体
            string url = "https://jsonplaceholder.typicode.com/posts";
            var payload = new
            {
                name = "John Doe",
                occupation = "Developer"
            };
            //序列化为 JSON 字符串
            string jsonPayload = JsonSerializer.Serialize(payload);
            HttpContent content = new StringContent(
                content: jsonPayload,
                encoding: Encoding.UTF8,
                mediaType: "application/json" // 设定内容类型
            );
            HttpResponseMessage response = await client.PostAsync(url, content);
            //检查响应状态码
            if (response.IsSuccessStatusCode)
            {
                //读取响应内容（通常是字符串）
                string responseBody = await response.Content.ReadAsStringAsync();

                WriteLine($"请求成功！状态码: {response.StatusCode}");
                WriteLine("响应内容:");
                WriteLine(responseBody);
            }
            else
            {
                WriteLine($"请求失败，状态码: {(int)response.StatusCode} {response.ReasonPhrase}");
            }
        }
    }

    //用于发送标准的 application/x-www-form-urlencoded 数据
    [Fact(DisplayName = "Post 表单请求")]
    public void Test4()
    {
        var values = new Dictionary<string, string>
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };
        var formContent = new FormUrlEncodedContent(values);
        // ... 调用 PostAsync(uri, formContent)
    }

    [Fact(DisplayName = "Post 文件上传")]
    public void Test5()
    {
        using var form = new MultipartFormDataContent();
        //文件内容
        var fileContent = new ByteArrayContent(File.ReadAllBytes("file.txt"));
        form.Add(fileContent, "fileName", "fileName.txt"); 
        // ... 调用 PostAsync(uri, form)
    }
}