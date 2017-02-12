using System;

namespace DownloadFromWeb
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.Write("Please enter WebPage link: ");
            var webLInk = Console.ReadLine();
            Console.Write("Please enter depth of going inside of links (by default it is 1): ");
            string depth = Console.ReadLine();

            ConnectToWeb connect2Web;
            if (depth == String.Empty)
            {
                connect2Web = new ConnectToWeb(webLInk);
            }
            else
            {
                connect2Web = new ConnectToWeb(webLInk, Convert.ToInt32(depth));
            }

            connect2Web.SaveInfo();

            connect2Web.SaveLinkToFile();
            connect2Web.SaveMailToFile();
        }
    }
}
