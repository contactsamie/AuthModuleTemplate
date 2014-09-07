using System;

namespace authModule.EmailTemplates
{
    public class EmailTemplateFactory
    {
        public static string GetCommonTemplate(string title, string body)
        {
            var content =
                System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"EmailTemplates\Common.config");
            content = content.Replace("<!--title-->", title);

            content = content.Replace("<!--body-->", body);
            return content;
        }
    }
}