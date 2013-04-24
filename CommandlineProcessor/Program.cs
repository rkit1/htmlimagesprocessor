using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using HtmlImagesProcessor;

namespace CommandlineProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlDocument doc = new HtmlDocument();
            string p = "C:\\Users\\Victor\\AppData\\Local\\Temp\\index.htm";
            doc.Load(p);
            var baseU = new Uri(p);
            foreach (var img in doc.DocumentNode.SelectNodes("//img[@src]"))
            {
                var uri = new Uri(baseU, img.Attributes["src"].Value);
                img.Attributes["src"].Value = ToDataURI.Transform(uri).ToString();
            }
            doc.Save(p + "1.htm", doc.StreamEncoding);
        }
    }
}
