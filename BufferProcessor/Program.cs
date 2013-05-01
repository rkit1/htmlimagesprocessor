using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using HtmlImagesProcessor;
using System.Windows.Forms;

using System.IO;

namespace BufferProcessor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (!Clipboard.ContainsText(TextDataFormat.Html)) return;
            var bufferData = Clipboard.GetText(TextDataFormat.Html);
            var bp = CF_HTML.Parse(bufferData);
            ProcessURIs.Go(bp.Item1.DocumentNode, new Uri(bp.Item2["SourceURL"]??"about:blank"));
            var newBufferData = CF_HTML.Produce(bp.Item1, bp.Item2["SourceURL"]);
            Clipboard.SetText(newBufferData, TextDataFormat.Html);
            return;
        }
    }
}
