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

        public ConnectToWeb(string startUrl, int depth = 1)
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

        public void ReadPageContent()
        {
            if (currentUrl == null)
            {
                throw new ArgumentNullException($"{nameof(currentUrl)} Please enter valid URL.");
            }

            Uri uri = null;
            try
            {
                uri = new Uri(currentUrl);

            }
            catch (UriFormatException e)
            {
                throw new UriFormatException($"{e.Message} Please enter valid URL.");
            }

            listOfPages.Add(uri.ToString());

            try
            {
                for (int i = 0; i < listOfPages.Count && i < counter; i++)
                {
                    HtmlContent = webCl.DownloadString(listOfPages[i]);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message} is not valid URL.");
            }
        }

        public void SaveInfo()
        //public void SaveInfo(string url)
        {
            if (currentUrl == null)
            {
                throw new ArgumentNullException(nameof(currentUrl));
            }

            Uri uri = null;
            try
            {
                uri = new Uri(currentUrl);

            }
            catch (UriFormatException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            listOfPages.Add(uri.ToString());

            try
            {
                for (int i = 0; i < listOfPages.Count && i < counter; i++)
                {
                    HtmlContent = webCl.DownloadString(listOfPages[i]);
                    GetLinks(HtmlContent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
                //do something
            }
        }

        Regex regExpression = new Regex(/*[?:img][?:href]=*/"[\"|']?(.*?)[\"|'|>]+", RegexOptions.Singleline | RegexOptions.CultureInvariant);

        private void GetLinks(string htmlContent)
        {
            SaveContentToFile();
            List<string> links = new List<string>();

            //Regex regExpression = new Regex(/*[?:img][?:href]=*/"[\"|']?(.*?)[\"|'|>]+", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            if (regExpression.IsMatch(htmlContent))
            {
                string matchValue;

                //SaveRegExToFile();

                foreach (Match match in regExpression.Matches(htmlContent))
                {
                    matchValue = match.Groups[1].Value;

                    if (matchValue == string.Empty)
                    {
                        return;
                    }

                    //Collect all mails in the page
                    if (matchValue.Contains("mailto"))
                    {
                        if (!listOfMails.Contains(matchValue))
                        {
                            listOfMails.Add(matchValue);
                        }
                    }

                    // Save images with full or relative paths
                    if (matchValue.Contains(".jpg") || matchValue.Contains(".png")
                        || matchValue.Contains(".zip") || matchValue.Contains(".mp3"))
                    {
                        if (!matchValue.Contains("http"))
                        {
                            //matchValue = currentUrl + matchValue;
                        }

                        SaveToFile(matchValue);
                    }


                    //Collect all links in the page
                    if (!matchValue.Contains("http") && matchValue.Contains(".php"))
                    {
                        if (!listOfPages.Contains(currentUrl + matchValue))
                        {
                            listOfPages.Add(/*currentUrl + */matchValue);
                        }
                    }
                    if (matchValue.Contains("http") && !matchValue.Contains(".css"))
                    {
                        if (matchValue.Contains("<a href"))
                        {
                            if (!listOfPages.Contains(currentUrl + matchValue))
                            {
                                listOfPages.Add(/*currentUrl + */matchValue);
                            }
                        }
                        if (matchValue[0] == '/')
                        {
                            if (!listOfPages.Contains(currentUrl + matchValue))
                            {
                                listOfPages.Add(/*currentUrl + */matchValue);
                            }
                        }

                        if (matchValue.Contains("http") && !matchValue.Contains(".zip"))
                        {
                            if (!listOfPages.Contains(matchValue))
                            {
                                listOfPages.Add(matchValue);
                            }
                        }
                    }
                }
            }
        }

        private void SaveRegExToFile()
        {
            using (StreamWriter strWrite = new StreamWriter("Ext.txt"))
            {
                strWrite.WriteLine((regExpression.Matches(HtmlContent)).GetEnumerator().ToString());
            }

        }

        //Save all links to .txt file
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

        public void SaveContentToFile()
        {
            using (StreamWriter strWrite = new StreamWriter("Content.txt"))
            {
                strWrite.WriteLine(HtmlContent);
            }
        }

        //Save all mails to .txt file
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

        //Save Content to local file
        void SaveToFile(string filePath)
        {
            var lastIndex = filePath.LastIndexOf("/");
            var fileName = filePath.Substring(lastIndex + 1);
            WebClient client = null;
            try
            {
                client = new WebClient();
                client.DownloadFile(filePath, fileName);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            finally
            {
                client.Dispose();
            }
            //using (WebClient client = new WebClient())
            //{
            //    client.DownloadFile(filePath, fileName);
            //}
        }

        public List<string> ReturnMails()
        {
            return listOfMails;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public string HtmlContent
        {
            get
            {
                return htmlContent;
            }

            set
            {
                htmlContent = value;
            }
        }

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
