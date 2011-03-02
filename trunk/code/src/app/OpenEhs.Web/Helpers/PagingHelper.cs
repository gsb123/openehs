using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OpenEhs.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString PageLinks(this HtmlHelper helper, int currentPage, int totalPages, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();

            for(int i = 1; i <= totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                
                if (i == currentPage)
                {
                    tag.AddCssClass("selected");
                }

                result.AppendLine(tag.ToString());
            }

            return new HtmlString(result.ToString());
        }
    }
}