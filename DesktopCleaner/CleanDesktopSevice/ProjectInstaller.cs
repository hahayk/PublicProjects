using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace CleanDesktopSevice
{
    [RunInstaller(true)]
    public partial class de : System.Configuration.Install.Installer
    {
        public de()
        {
            InitializeComponent();
        }
    }
}
