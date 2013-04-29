using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlImagesProcessor;
using HtmlAgilityPack;

namespace BufferProcessor
{
    class CF_HTMLParser
    {
        

        public CF_HTMLParser(string input)
        {
            Dictionary<string, string> headerData = new Dictionary<string, string>();
            ProcessibleDocument doc;

            var r = new Regex(@"\G([a-zA-Z]+):(.+)\r\n"),
                match = r.Match(input);
            while (match.Success)
            {
                headerData.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }

            
            var startHTML = int.Parse(headerData["StartHTML"]),
                endHTML = int.Parse(headerData["EndHTML"]),
                htmlStr = input.Substring(startHTML, endHTML - startHTML),
                startFragment = int.Parse(headerData["StartFragment"]),
                endFragment = int.Parse(headerData["EndFragment"]);
                sourceURL = headerData["SourceURL"];

            
            if (SourceURL != null) doc = new ProcessibleDocument(SourceURL);
            else doc = new ProcessibleDocument();

            doc.LoadHtml(htmlStr);

            var start = startFragment - startHTML,
                end = endFragment - endHTML;

            HtmlNode cur = doc.DocumentNode;

//            while (cur.StreamPosition


            
        }
    }
}
