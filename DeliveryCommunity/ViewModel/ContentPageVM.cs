using System;
using DeliveryCommunity.Model;
using DeliveryCommunity.ViewModel.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
namespace DeliveryCommunity.ViewModel
{
    public class ContentPageVM
    {
        public static Article ContentArticle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ChatLink { get; set; }
        public string Category { get; set; }
        public int PeopleMaxCount { get; set; }
        public int PeopleCount { get; set; }
        public int ExpireHour { get; set; }
        public int ExpireMin { get; set; }
        public ContentPageVM()
        {
            Title = ContentArticle.Title;
            Content = ContentArticle.Content;
            ChatLink = ContentArticle.ChatLink;
            Category = ContentArticle.Category;
            PeopleMaxCount = ContentArticle.PeopleMaxCount;
            PeopleCount = ContentArticle.PeopleCount;
            ExpireHour = ContentArticle.ExpireHour;
            ExpireMin = ContentArticle.ExpireMin;

        }

    }
}
