using System;
using System.IO;

namespace FolderMonitoring
{
    public class FolderMonitor
    {
        public string FolderPath { get; set; }

        public FolderMonitor(string folderPath)
        {
            FolderPath = folderPath;
        }

        public void StartMonitoring()
        {
            FileSystemWatcher watch = new FileSystemWatcher();
            watch.Path = FolderPath;

            watch.Changed += Watch_Changed;
            watch.Created += Watch_Created;
            watch.Deleted += Watch_Deleted;
            watch.Renamed += Watch_Renamed;
            
            watch.EnableRaisingEvents = true;

            while (Console.Read() != 'q') ;
        }

        private void Watch_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"{e.OldName} was renamed to {e.Name} ");
        }

        private void Watch_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} was deleted, lets say him GOOD BY.");
        }

        private void Watch_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} was created, lets say him WELCOME!!!.");
        }

        private void Watch_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} was changed, lets say him GOOD CHANGES.");
        }



    }
}
