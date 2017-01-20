using System.IO;

namespace FileManager
{
    public class EmptyDirectory
    {
        public string DirName { get; set; }
        public EmptyDirectory(string directoryName)
        {
            DirName = directoryName;
        }

        public void EmptyDirectoryRecursively()
        {
            var toDeleteFilePaths = Directory.GetFiles(DirName);
            foreach (var file in toDeleteFilePaths)
            {
                File.Delete(file);
            }

            var dirs = Directory.GetDirectories(DirName);
            foreach (var dir in dirs)
            {
                Directory.Delete(dir, true);
            }
        }
    }
}
