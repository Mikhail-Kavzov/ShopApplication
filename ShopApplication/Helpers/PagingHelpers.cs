using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApplication.ViewModel;
using System.Text;
using System.Web.Mvc;

namespace ShopApplication.Helpers
{
    public static class PagingHelpers
    {
        public static HtmlString PageLinks(this IHtmlHelper html,
        PageInfoViewModel pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                System.Web.Mvc.TagBuilder tag = new("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return new HtmlString(result.ToString());
        }
    }
}
