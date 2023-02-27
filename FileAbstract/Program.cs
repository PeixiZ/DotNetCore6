using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using StackExchange.Redis;
using static System.Console;

//文件以IFileProvider为抽象机制，可以通过此接口的方法获取其他接口的返回对象
var provider = new ServiceCollection()
.AddSingleton<IFileProvider>(new PhysicalFileProvider("C:/Users"))
.AddSingleton<IFileSystem, FileSystem>()
.AddHttpClient()
.AddDistributedRedisCache((option) => 
{
    
})
.BuildServiceProvider();

WriteLine(
provider
//.GetService<IHttpClientFactory>()
.GetService<IFileProvider>().GetFileInfo("C:/Users").Name);


Test.test();


public static class Test
{
    public static void test()
    {
        var temp = new PhysicalFileProvider("C:/Users");
        WriteLine(temp.GetFileInfo("name.txt").GetType());                             
    }
}


