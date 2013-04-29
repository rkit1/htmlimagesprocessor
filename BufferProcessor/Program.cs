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
            var bp = new CF_HTMLParser(bufferData);
            return;
        }
    }
}
