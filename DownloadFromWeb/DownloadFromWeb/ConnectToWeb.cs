using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DownloadFromWeb
{
    public class ConnectToWeb : IDisposable
    {
        //Keep info from site
        private StreamWriter strWrite;
        WebClient webCl = new WebClient();
        string htmlContent = string.Empty;
        List<string> listOfMails = new List<string>();
        List<string> listOfPages = new List<string>();

        //depth of going inside in each link
        const int counter = 30;

        public void SaveInfo(string url, string path)
        {
            if(url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            //strWrite = new StreamWriter(path);

            Uri uri = new Uri(url);

            try
            {
                htmlContent = webCl.DownloadString(uri);

                //strWrite.Write(htmlContent);

                //var linkDown = GetLinks(htmlContent);
                GetLinks(htmlContent);

            }
            catch (Exception)
            {
                //do something
            }
            
        }

        public List<string> ReturnMails()
        {
            return listOfMails;
        }

        //private List<string> GetLinks(string htmlContent)
        private void GetLinks(string htmlContent)
        {
            List<string> links = new List<string>();

            //Regex regExpression = new Regex("(?:href|src)=[\"|']?(.*?)[\"|'|>]+", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            Regex regExpression = new Regex("(?:href)=[\"|']?(.*?)[\"|'|>]+", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            if (regExpression.IsMatch(htmlContent))
            {
                string matchValue;
                foreach (Match match in regExpression.Matches(htmlContent))
                {
                    matchValue = match.Groups[1].Value;
                    links.Add(matchValue);

                    if (matchValue.Contains("mailto"))
                    {
                        if (!listOfMails.Contains(matchValue))
                        {
                            listOfMails.Add(matchValue);
                        }
                    }
                    

                    if (matchValue.Contains("http:") && !matchValue.Contains(".css")
                        && !matchValue.Contains("rss") && !matchValue.Contains(".zip") 
                        && listOfPages.Count < counter)
                    {
                        if (!listOfPages.Contains(matchValue))
                        {
                            Console.WriteLine(matchValue);
                            listOfPages.Add(matchValue);
                            SaveInfo(matchValue, matchValue);
                        }
                    }
                }
            }

            //return links;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    strWrite.Dispose();
                    webCl.Dispose();
                }


                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                strWrite = null;
                webCl = null;

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~ConnectToWeb()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
        #endregion

    }
}
