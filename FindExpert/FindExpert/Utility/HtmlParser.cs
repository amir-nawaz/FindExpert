using HtmlAgilityPack;

namespace FindExpert.Utility
{
    public class HtmlParser
    {
        /// <summary>
        /// get html from the provided url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ReadHtmlPage(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Parse the HTML string and get the required (Heading) tags.
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static List<string> ParseHtml(string html)
        {
            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(html);

            List<string> headings = new List<string>();

            var xpath = "//*[self::h1 or self::h2 or self::h3 or self::h4]";
            foreach (HtmlNode heading in htmlSnippet.DocumentNode.SelectNodes(xpath))
            {
                headings.Add(heading.InnerText);
            }

            return headings;

        }
    }
}
