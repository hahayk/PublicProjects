namespace CleanDesktopSevice
{
    partial class de
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DesktopCleanerInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.DesktopCleaner = new System.ServiceProcess.ServiceInstaller();
            // 
            // DesktopCleanerInstaller
            // 
            this.DesktopCleanerInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.DesktopCleanerInstaller.Password = null;
            this.DesktopCleanerInstaller.Username = null;
            // 
            // DesktopCleaner
            // 
            this.DesktopCleaner.DelayedAutoStart = true;
            this.DesktopCleaner.Description = "The service is running every 3 hour and clean the desktop from files and folders." +
    "";
            this.DesktopCleaner.DisplayName = "Desktop Clean";
            this.DesktopCleaner.ServiceName = "DesktopCleaner";
            this.DesktopCleaner.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // de
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.DesktopCleanerInstaller,
            this.DesktopCleaner});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller DesktopCleanerInstaller;
        private System.ServiceProcess.ServiceInstaller DesktopCleaner;
    }
}