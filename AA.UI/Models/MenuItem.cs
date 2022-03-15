using System;

namespace AA.UI.Models
{
    internal class MenuItem
    {
        public String Title { get; set; }
        public Action Action { get; set; }

        public MenuItem(String title, Action action)
        {
            Title = title;
            Action = action;
        }
    }
}
