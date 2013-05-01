using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlImagesProcessor;
using HtmlAgilityPack;

namespace CommandlineProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string p = "C:\\Users\\Victor\\AppData\\Local\\Temp\\index.htm";
            var doc = new HtmlDocument();
            doc.Load(p);
            ProcessURIs.Go(doc.DocumentNode, new Uri(p));
            doc.Save(p + "1.htm", doc.StreamEncoding);
        }
    }
}
