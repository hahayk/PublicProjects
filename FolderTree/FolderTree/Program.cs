using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FolderTest
{
    public class StackBasedIteration
    {
        static void Main(string[] args)
        {
            // Specify the starting folder on the command line, or in 
            // Visual Studio in the Project > Properties > Debug pane.
            TraverseTree(@"H:\C# Training\Docs");

            //DirectoryInfo direct = new DirectoryInfo(@"H:\C# Training\Docs");

            //DirectoryInfo[] listOfDir = direct.GetDirectories();

            //Console.WriteLine("Press any key");
            // Console.ReadKey();
        }

        public static void TraverseTree(string root)
        {
            string pathFile = string.Empty;

            DirectoryInfo dirInfo = new DirectoryInfo(root);
            DirectoryInfo[] listOfDir = dirInfo.GetDirectories();

            foreach (var dir in listOfDir)
            {
                if (dir.Attributes == FileAttributes.Directory)
                {
                    if (dir == listOfDir.Last())
                    {
                        Console.WriteLine(" -" + dir);

                        pathFile = root + "\\" + dir;
                        var curDirs = Directory.GetFiles(pathFile);
                        foreach (var item in curDirs)
                        {
                            Console.WriteLine("  -" + item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("-" + dir);
                        pathFile = root + "\\" + dir;
                        var curDirs = Directory.GetFiles(pathFile);
                        foreach (var item in curDirs)
                        {
                            Console.WriteLine("  -" + item);
                        }
                    }
                }

                try
                {
                    DirectoryInfo dr = new DirectoryInfo(root + "\\" + dir);
                    DirectoryInfo[] dirInfoList = dr.GetDirectories();

                    if (dirInfoList.Length > 0)
                    {
                        if (dir != dirInfoList.Last())
                        {
                            TraverseTree(root + "\\" + dir + "  ");

                        }

                        else

                        {

                            TraverseTree(root + "\\" + dir + "  ");

                        }
                    }


                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }
}