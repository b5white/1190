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
            
        }

        private static string getURL() {
            return "http://forums.xkcd.com/viewtopic.php?f=7&t=101043&start=";
        }

        private static int getStartPage() {
            return 0;
        }
    }
}
