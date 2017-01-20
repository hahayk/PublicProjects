namespace FolderMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            FolderMonitor fm = new FolderMonitor(@"H:\C# Training");
            fm.StartMonitoring();
        }
    }
}
