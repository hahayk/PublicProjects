using System;

namespace DownloadFromWeb
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.Write("Please enter WebPage link: ");
            var webLInk = Console.ReadLine();
            Console.Write("Please enter depth of going inside of links: ");
            var depth = Console.ReadLine();

            ConnectToWeb connect2Web = new ConnectToWeb(webLInk, Convert.ToInt32(depth));

            connect2Web.SaveInfo(webLInk);

            connect2Web.SaveLinkToFile();
            connect2Web.SaveMailToFile();
        }
    }
}
