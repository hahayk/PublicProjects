using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadFromWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectToWeb connect2Web = new ConnectToWeb();
            //connect2Web.SaveInfo("http://google.com", "google.html");
            connect2Web.SaveInfo("http://mic.am", "mic.html");
            //connect2Web.SaveInfo("http://tert.am", "mic.html");

            List<string> mails = new List<string>();
            mails = connect2Web.ReturnMails();

            foreach (var item in mails)
            {
            Console.WriteLine(item);
            }
        }
    }
}
