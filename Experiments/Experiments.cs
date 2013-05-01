using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;

namespace Experiments
{
    [TestClass]
    public class Experiments
    {
        [TestMethod]
        public void TestMethod1()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml("<html><body><div></div></body></html>");
            var div = doc.DocumentNode.SelectSingleNode("//div");
            var z = div.StreamPosition;
            var child = new HtmlNode(HtmlNodeType.Element, doc, 0);
            child.Name = "huy";
            div.ParentNode.InsertBefore(child, div);
            var w = new System.IO.StringWriter();
            doc.Save(w);
            var x = div.StreamPosition;
        }

        [TestMethod]
        public void TestMethod2()
        {

        }
    }
}
