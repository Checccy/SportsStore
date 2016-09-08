using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SportsStore.Web.Areas.ProductArea.Models;

namespace SportsStore.Web.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, ProductPagingDTO productPagingDTO, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i < productPagingDTO.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == productPagingDTO.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                result.Append("<li>"+ tag.ToString() + "</li>");
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}