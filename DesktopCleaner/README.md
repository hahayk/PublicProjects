# Clean desktop from unnecessary files and folders

*How to install service* <br/>
Run command <br/>
You need to run "Developer Command Prompt" as administrator. Go to directory of *CleanDesktopSevice.exe* file and write the following:
*InstallUtil.exe CleanDesktopSevice.exe* and press Enter<br\>
The result should be: <br/>
*The commit phase completed sucsessfully* <br/>
*The transacted install has completed* <br/>

<br/>

After completing installation press "Windows key" + R then write "Services". Find on it "DesktopCleaner" service and START.

<br/>

*How it works* 
<br/>
Every 3 hour runs and delete all files and folders in desktop.

#####Some code snipet

*Code snipet from class library*
```C#
var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var empDir = new EmptyDirectory(filePath);
empDir.EmptyDirectoryRecursively();
```

*Code snipet from usage of class library*
```C#
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
```

> This project written for .NET Framework 4.5.2 version, C# 6