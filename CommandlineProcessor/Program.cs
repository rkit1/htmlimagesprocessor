using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlImagesProcessor;

namespace CommandlineProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string p = "C:\\Users\\Victor\\AppData\\Local\\Temp\\index.htm";
            ProcessibleDocument doc = new ProcessibleDocument(p);
            doc.Load(p);
            doc.Process();
            doc.Save(p + "1.htm", doc.StreamEncoding);
        }
    }
}
