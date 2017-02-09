using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

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
        string currentUrl;

        //depth of going inside in each link
        readonly int counter;

        public ConnectToWeb(string startUrl, int depth)
        {
            if (!startUrl.Contains("http"))
            {
                currentUrl = "http://" + startUrl;
            }
            else
            {
                currentUrl = startUrl;
            }

            counter = depth;

        }

        public void SaveInfo(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }


            if (!url.Contains("http"))
            {
                url = "http://" + url;
            }

            Uri uri = new Uri(currentUrl);

            listOfPages.Add(uri.ToString());

            try
            {
                for (int i = 0; i < listOfPages.Count && i < counter; i++)
                {
                        htmlContent = webCl.DownloadString(listOfPages[i]);
                    GetLinks(htmlContent); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

            Regex regExpression = new Regex("(?:href)=[\"|']?(.*?)[\"|'|>]+", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            if (regExpression.IsMatch(htmlContent))
            {
                string matchValue;

                foreach (Match match in regExpression.Matches(htmlContent))
                {
                    matchValue = match.Groups[1].Value;

                    if (matchValue == string.Empty)
                    {
                        return;
                    }

                    if (matchValue.Contains("mailto"))
                    {
                        if (!listOfMails.Contains(matchValue))
                        {
                            listOfMails.Add(matchValue);
                        }
                    }

                    // Save images with full or relative paths
                    if ((matchValue.Contains(".jpg") || matchValue.Contains(".png")) && matchValue.Contains("http"))
                    {
                        SaveToFile(matchValue);
                    }
                    else if ((matchValue.Contains(".jpg") || matchValue.Contains(".png")) && !matchValue.Contains("http"))
                    {
                        SaveToFile(currentUrl + matchValue);
                    }

                    if (!matchValue.Contains("http") && matchValue.Contains(".php"))
                    {
                        if (!listOfPages.Contains(currentUrl + matchValue))
                        {
                            listOfPages.Add(currentUrl + matchValue);
                        }
                    }

                    if (matchValue.Contains("<a href") && !matchValue.Contains(".css"))
                    {
                        if (!listOfPages.Contains(currentUrl + matchValue))
                        {
                            listOfPages.Add(currentUrl + matchValue);
                        }
                    }

                    if (matchValue[0] == '/' && !matchValue.Contains(".css"))
                    {
                        if (!listOfPages.Contains(currentUrl + matchValue))
                        {
                            listOfPages.Add(currentUrl + matchValue);
                        }
                    }

                    if (matchValue.Contains("http") && !matchValue.Contains(".css")
                        && !matchValue.Contains("rss") && !matchValue.Contains(".zip"))
                    {
                        if (!listOfPages.Contains(matchValue))
                        {
                            listOfPages.Add(matchValue);
                        }
                    }
                }
            }
        }

        public void SaveLinkToFile()
        {
            using (StreamWriter strWrite = new StreamWriter(/*Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + */"links.txt"))
            {
                foreach (var item in listOfPages)
                {
                    strWrite.WriteLine(item);
                }
            }
        }

        public void SaveMailToFile()
        {
            using (StreamWriter strWrite = new StreamWriter(/*Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + */"mails.txt"))
            {
                foreach (var item in listOfMails)
                {
                    strWrite.WriteLine(item);
                }
            }
        }

        void SaveToFile(string filePath)
        {
            var lastIndex = filePath.LastIndexOf("/");
            var fileName = filePath.Substring(lastIndex + 1);

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(filePath, fileName);
            }
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
