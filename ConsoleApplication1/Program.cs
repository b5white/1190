using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {

        static void Main(string[] args) {
            Config config = new Config();
            int startPage = getStartPage(config);
            string url = getURL(config);
            string folder = getFolder(config);
            int stopPage = getStopPage(config);
            readPages(url, startPage, stopPage, folder);
        }

        private static void readPages(string url, int startPage, int stopPage, string folder) {
            Boolean found = true;
            string xml;
            System.IO.StreamWriter stream = new System.IO.StreamWriter(folder + @"\" + startPage.ToString() + ".html");           
            for (int i = startPage; i < stopPage; i++) {
                found = readPage(buildURL(url, startPage), out xml);                
                writePage(stream, xml);
            }
            stream.Close();
        }

        private static void writePage(StreamWriter stream, string xml)
        {
            stream.Write(xml);
        }

        private static bool readPage(string url, out string xml ) {
            xml = new WebClient().DownloadString(url);
            return true;
        }

        private static string buildURL(string url, int startPage) {
            return url + ((startPage - 1) * 40).ToString();
        }

        private static string getURL(Config config) {
            //return "http://forums.xkcd.com/viewtopic.php?f=7&t=101043&start=";
            return config.Value("BaseURL");
        }

        private static int getStartPage(Config config) {
            return int.Parse(config.Value("StartPage"));
        }
        private static int getStopPage(Config config) {
            //return 25;
            return int.Parse(config.Value("StopPage"));
        }

        private static string getFolder(Config config) {
            //return @"C:\Users\Karen\Documents\xkcd\Time\Thread";
            return config.Value("Folder");
        }

    }
}
