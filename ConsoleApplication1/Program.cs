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
            readPages(url, StartPage);
        }

        private static void readPages(string url, int startPage) {
            Boolean found = true;
            while (found) {
                found = readPage(buildURL(url, startPage));
            }
        }

        private static bool readPage(string v) {
            throw new NotImplementedException();
        }

        private static string buildURL(string url, int startPage) {
            return url + startPage.ToString();
        }
        private static string getURL() {
            return "http://forums.xkcd.com/viewtopic.php?f=7&t=101043&start=";
        }

        private static int getStartPage() {
            return 0;
        }
    }
}
