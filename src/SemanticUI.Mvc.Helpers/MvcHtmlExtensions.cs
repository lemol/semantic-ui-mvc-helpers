using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using System.Linq.Expressions;

namespace SemanticUI.Mvc.Helpers
{
    public static class MvcHtmlExtensions
    {
        public static HtmlString SemanticDropdownFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expr, IEnumerable<SemanticDropdownListItem> list = null, string defaultText = "")
        {
            var mexpr = expr.Body as MemberExpression;
            var name = mexpr.Member.Name;
            return html.SemanticDropdown(name, list, defaultText);
        }
        public static HtmlString SemanticDropdown(this HtmlHelper html, string name, IEnumerable<SemanticDropdownListItem> list = null, string defaultText = "")
        {
            var tb = new TagBuilder("div");
            tb.Attributes.Add("tabindex", "0");
            tb.AddCssClass("ui");
            tb.AddCssClass("fluid");
            tb.AddCssClass("selection");
            tb.AddCssClass("dropdown");

            var hidden = new TagBuilder("input");
            hidden.Attributes.Add("type", "hidden");
            hidden.Attributes.Add("name", name);
            if (html.ViewData.Model != null)
            {
                var propInfo = html.ViewData.Model.GetType().GetProperty(name);
                var value = propInfo.GetGetMethod().Invoke(html.ViewData.Model, null);
                hidden.Attributes.Add("value", value.ToString());
            }
            hidden.GenerateId(name);
            tb.InnerHtml += hidden.ToString(TagRenderMode.SelfClosing);

            tb.InnerHtml += "<i class=\"dropdown icon\"></i>";

            if (defaultText != null)
            {
                var defaultTextB = new TagBuilder("div");
                defaultTextB.AddCssClass("default");
                defaultTextB.AddCssClass("text");
                defaultTextB.InnerHtml = defaultText;
                tb.InnerHtml += defaultTextB.ToString();
            }

            var menuElement = new TagBuilder("div");
            menuElement.Attributes.Add("tabindex", "-1");
            menuElement.AddCssClass("menu");
            if (list != null)
                foreach (var item in list)
                {
                    var itemElement = new TagBuilder("div");
                    itemElement.AddCssClass("item");
                    itemElement.Attributes.Add("data-value", item.Value);
                    itemElement.InnerHtml = item.Text;
                    menuElement.InnerHtml += itemElement.ToString(TagRenderMode.Normal);
                }
            tb.InnerHtml += menuElement.ToString();

            return MvcHtmlString.Create(tb.ToString());
        }

        public static HtmlString SemanticDropdownIconSearchFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expr, IEnumerable<SemanticDropdownIconListItem> list = null, string defaultText = "")
        {
            var mexpr = expr.Body as MemberExpression;
            var name = mexpr.Member.Name;
            return html.SemanticDropdownSearchIcon(name, list, defaultText);
        }
        public static HtmlString SemanticDropdownSearchIcon(this HtmlHelper html, string name, IEnumerable<SemanticDropdownIconListItem> list = null, string defaultText = "")
        {
            var tb = new TagBuilder("div");
            tb.Attributes.Add("tabindex", "0");
            tb.AddCssClass("ui");
            tb.AddCssClass("fluid");
            tb.AddCssClass("search");
            tb.AddCssClass("selection");
            tb.AddCssClass("dropdown");

            var hidden = new TagBuilder("input");
            hidden.Attributes.Add("type", "hidden");
            hidden.Attributes.Add("name", name);
            if (html.ViewData.Model != null)
            {
                var propInfo = html.ViewData.Model.GetType().GetProperty(name);
                var value = propInfo.GetGetMethod().Invoke(html.ViewData.Model, null);
                hidden.Attributes.Add("value", value.ToString());
            }
            hidden.GenerateId(name);
            tb.InnerHtml += hidden.ToString(TagRenderMode.SelfClosing);

            tb.InnerHtml += "<i class=\"dropdown icon\"></i>";
            tb.InnerHtml += "<input tabindex=\"0\" autocomplete=\"off\" class=\"search\" />";

            if (defaultText != null)
            {
                var defaultTextB = new TagBuilder("div");
                defaultTextB.AddCssClass("default");
                defaultTextB.AddCssClass("text");
                defaultTextB.InnerHtml = defaultText;
                tb.InnerHtml += defaultTextB.ToString();
            }

            var menuElement = new TagBuilder("div");
            menuElement.Attributes.Add("tabindex", "-1");
            menuElement.AddCssClass("menu");
            if (list != null)
                foreach (var item in list)
                {
                    var itemElement = new TagBuilder("div");
                    itemElement.AddCssClass("item");
                    itemElement.Attributes.Add("data-value", item.Value);
                    itemElement.InnerHtml += "<i class=\"" + item.Icon + "\"></i>";
                    itemElement.InnerHtml += item.Text;
                    menuElement.InnerHtml += itemElement.ToString(TagRenderMode.Normal);
                }
            tb.InnerHtml += menuElement.ToString();

            return MvcHtmlString.Create(tb.ToString());
        }

        public static HtmlString SemanticCalendarFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expr, DateTime? initialValue = null)
        {
            var mexpr = expr.Body as MemberExpression;
            var name = mexpr.Member.Name;
            return html.SemanticCalendar(name, initialValue);
        }

        public static HtmlString SemanticCalendar(this HtmlHelper html, string name, DateTime? initialValue = null)
        {
            var tb = new TagBuilder("div");
            tb.AddCssClass("input");
            tb.AddCssClass("icon");
            tb.AddCssClass("left");
            tb.AddCssClass("ui");
            
            var input = new TagBuilder("input");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("name", name);

            if (html.ViewData.Model != null)
            {
                var propInfo = html.ViewData.Model.GetType().GetProperty(name);
                var value = propInfo.GetGetMethod().Invoke(html.ViewData.Model, null);
                input.Attributes.Add("value", value.ToString());
            }
            else
            {
                initialValue = initialValue ?? DateTime.Now;
                input.Attributes.Add("value", initialValue.Value.ToString());
            }
            input.GenerateId(name);

            tb.InnerHtml += input.ToString(TagRenderMode.SelfClosing);
            tb.InnerHtml += "<i class=\"calendar icon\"></i>";

            return MvcHtmlString.Create(tb.ToString());
        }
    }
}