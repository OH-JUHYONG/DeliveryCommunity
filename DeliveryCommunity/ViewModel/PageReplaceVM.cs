using DeliveryCommunity.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DeliveryCommunity.ViewModel
{
    class PageReplaceVM
    {
        public PageNavigateCommand PageNavigateCommand { get; set; }

        Frame frame { get; set; }
        public string viewUri { get; set; }

        public PageReplaceVM()
        {
            PageNavigateCommand = new PageNavigateCommand(this);
            viewUri = "View/{0}.xaml";
            //View.MainWindow mainWindow = (View.MainWindow)Application.Current.MainWindow;

            //frame = mainWindow.PageFrame;
        }

        public void NavigateTo(string pageToShow)
        {
            View.DeliveryCommunity mainWindow = (View.DeliveryCommunity)Application.Current.MainWindow;
            frame = mainWindow.PageFrame;
            string pageUri = string.Format(viewUri, pageToShow);
            frame.NavigationService.Navigate(new Uri(pageUri, UriKind.RelativeOrAbsolute));
        }
    }
}
