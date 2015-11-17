using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SemanticUI.Helpers
{
    public class SemanticDropdownListItem : SelectListItem
    {
        public SemanticDropdownListItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public SemanticDropdownListItem()
        {

        }
    }

    public class SemanticDropdownIconListItem : SemanticDropdownListItem
    {
        public string Icon { get; set; }
        public SemanticDropdownIconListItem(string text, string value, string icon)
            : base(text, value)
        {
            Icon = icon;
        }

        public SemanticDropdownIconListItem()
        {

        }
    }
}