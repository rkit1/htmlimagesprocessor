using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlImagesProcessor;
using HtmlAgilityPack;

namespace BufferProcessor
{
    static class CF_HTML
    {
        public static Tuple<HtmlDocument,Dictionary<string,string>> Parse(string input)
        {
            Dictionary<string, string> headerData = new Dictionary<string, string>();
            HtmlDocument doc;
            var r = new Regex(@"\G([a-zA-Z]+):(.+)\r\n");
            var match = r.Match(input);
            while (match.Success)
            {
                headerData.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }

            
            var startHTML = int.Parse(headerData["StartHTML"]);
            var endHTML = int.Parse(headerData["EndHTML"]);
            var htmlStr = input.Substring(startHTML, endHTML - startHTML);
            var sourceURL = headerData["SourceURL"];

            doc = new HtmlDocument();

            doc.LoadHtml(htmlStr);

            return new Tuple<HtmlDocument,Dictionary<string,string>>(doc, headerData);
        }

        public static string Produce(HtmlDocument doc) { return Produce(doc, null); }
        public static string Produce(HtmlDocument doc, string sourceURL)
        {
            string outString;
            using (var w = new System.IO.StringWriter())
            {
                doc.Save(w);
                outString = w.ToString();
            }

            var startFragment = outString.IndexOf("<!--StartFragment-->") + 20;
            var endFragment = outString.IndexOf("<!--EndFragment-->");

            if (startFragment == -1)
            {
                startFragment = 0;
                endFragment = outString.Length;
            }

            var header =
@"Version:0.9
StartHTML:<<<<<<<1
EndHTML:<<<<<<<2
StartFragment:<<<<<<<3
EndFragment:<<<<<<<4
";
            /*StartSelection:<<<<<<<3
EndSelection:<<<<<<<4
*/

            if (sourceURL != null) header += String.Format("SourceURL:{0}\r\n", sourceURL);

            var startHTML = header.Length;
            header = header.Replace("<<<<<<<1", startHTML.ToString("00000000"));
            header = header.Replace("<<<<<<<2", (startHTML + outString.Length).ToString("00000000"));
            header = header.Replace("<<<<<<<3", (startFragment + startHTML).ToString("00000000"));
            header = header.Replace("<<<<<<<4", (endFragment + startHTML).ToString("00000000"));

            return header + outString;
        }



    }
}
