using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {

        static void Main(string[] args) {
            int StartPage = getStartPage();
            string url = getURL();
            string folder = getURL();
            readPages(url, StartPage);
        }

        private static void readPages(string url, int startPage, string folder) {
            Boolean found = true;
            string xml;
            System.IO.StreamWriter stream = new System.IO.StreamWriter(folder + @"\" + startPage.ToString() + ".html"));
            int stopPage = 25;
            for (int i = startPage; i < stopPage; i++) {
                found = readPage(buildURL(url, startPage), out xml);
                writePage(stream, xml);
            }
        }

        private static bool readPage(string url, out string xml ) {
            throw new NotImplementedException();
        }

        private static string buildURL(string url, int startPage) {
            return url + ((startPage - 1) * 40).ToString();
        }

        private static string getURL() {
            return "http://forums.xkcd.com/viewtopic.php?f=7&t=101043&start=";
        }

        private static int getStartPage() {
            return 0;
        }
    }
}
