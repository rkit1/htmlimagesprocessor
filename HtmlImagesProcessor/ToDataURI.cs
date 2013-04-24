using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlImagesProcessor
{
    public class ToDataURI
    {
        public static Uri Transform(Uri u)
        {
            if (!u.IsFile) return u;
            try
            {
                var ct = getCT(Path.GetExtension(u.LocalPath));
                var data = Convert.ToBase64String(File.ReadAllBytes(u.LocalPath));
                return (new Uri(String.Format("data:{0};base64,{1}", ct, data)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString() + "at ToDataURI with" + u.ToString());
                return u;
            }
        }

        public static string getCT(string ext)
        {
            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
