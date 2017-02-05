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
           
            Console.Write("Please enter WebPage link: ");
            var webLInk = Console.ReadLine();
            ConnectToWeb connect2Web = new ConnectToWeb(webLInk);

            connect2Web.SaveInfo(webLInk);

            List <string> mails = new List<string>();
            mails = connect2Web.ReturnMails();

            //foreach (var item in mails)
            //{
            //    Console.WriteLine(item);
            //}

            connect2Web.SaveLinkToFile();
            connect2Web.SaveMailToFile();

        }
    }
}
