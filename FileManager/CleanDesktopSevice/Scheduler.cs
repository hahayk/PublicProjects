using System.ServiceProcess;
using FileManager;
using System.Timers;
using System;

namespace CleanDesktopSevice
{
    public partial class Scheduler : ServiceBase
    {
        private Timer timer1 = null;

        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 10800000; // every 3 hour
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            timer1.Enabled = true;           
        }

        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var empDir = new EmptyDirectory(filePath);
            empDir.EmptyDirectoryRecursively();
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
        }
    }
}
