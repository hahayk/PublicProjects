using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var empDir = new EmptyDirectory(filePath);
            empDir.EmptyDirectoryRecursively();
        }
    }
}
