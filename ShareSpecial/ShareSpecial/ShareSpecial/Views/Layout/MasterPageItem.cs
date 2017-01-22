using ShareSpecial.Views.Account;
using ShareSpecial.Views.Test;
using System;
using System.Collections.Generic;

namespace ShareSpecial.Views.Layout
{
    internal class MasterPageItem
    {
        public string IconSource { get; internal set; }
        public Type TargetType { get; internal set; }
        public string Title { get; internal set; }

        public static IEnumerable<MasterPageItem> GetList()
        {
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Page 1",
                IconSource = "contacts.png",
                TargetType = typeof(Page1)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Page 2",
                IconSource = "todo.png",
                TargetType = typeof(Page2)
            });

            return masterPageItems;
        }
    }
}