using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimesheetWeb
{
    public static class TableHelper
    {
        public static MvcHtmlString CreateBlankTable(this HtmlHelper helper, string id)
        {
            TagBuilder table = new TagBuilder("table");
            table.Attributes.Add("id", id);
            //table.Attributes.Add("style", "width:100%");
            TagBuilder tHead = new TagBuilder("thead");
            TagBuilder row = new TagBuilder("tr");
            TagBuilder body = new TagBuilder("tbody");

            tHead.InnerHtml = row.ToString(); 

            table.InnerHtml= tHead.ToString() +body.ToString();

            return MvcHtmlString.Create(table.ToString());
        }
    }
}