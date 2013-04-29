using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace HtmlImagesProcessor
{
    public class ProcessibleDocument : HtmlDocument
    {
        public Uri baseUri = new Uri("about: blank");

        public ProcessibleDocument(string baseUri) : base()
        {
            this.baseUri = new Uri(baseUri);
        }

        public ProcessibleDocument() { }

        public void Process()
        {
            foreach (var img in DocumentNode.SelectNodes("//img[@src]"))
            {
                var uri = new Uri(baseUri, img.Attributes["src"].Value);
                img.Attributes["src"].Value = ToDataURI.Transform(uri).ToString();
            }
        }
    }
}
