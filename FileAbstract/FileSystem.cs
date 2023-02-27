using Microsoft.Extensions.FileProviders;
using static System.Console;

public class FileSystem: IFileSystem
{
    private readonly IFileProvider _file;
    private string _path = "C:/Users";

    public FileSystem(IFileProvider file) 
    {
        _file = file;
    }

    public void Print()
    {
        foreach (var item in _file.GetDirectoryContents(_path))
        {
            WriteLine($"{item.Name}");            
        }
    }
}