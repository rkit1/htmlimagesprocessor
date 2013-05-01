using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace HtmlImagesProcessor
{
    public static class ProcessURIs
    {
        public static void Go(HtmlNode input, Uri baseUri)
        {
            var nodes = input.SelectNodes("//img[@src]");
            if (nodes == null) return;
            foreach (var img in nodes)
            {
                var uri = new Uri(baseUri, img.Attributes["src"].Value);
                img.Attributes["src"].Value = ToDataURI.Transform(uri).ToString();
            }
        }
    }
}
