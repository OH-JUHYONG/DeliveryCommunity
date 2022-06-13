using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    public static class BoardMouseCommand
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand),
            typeof(BoardMouseCommand), new PropertyMetadata(null, OnCommandPropertyChanged));

        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        private static void OnCommandPropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var control = d as ListView;
            if (control != null)
            {
                control.MouseLeftButtonDown += OnItemClick;
            }

        }

        private static void OnItemClick(object sender, MouseButtonEventArgs e)
        {
            var control = sender as ListView;
            var command = GetCommand(control);
            PageReplaceVM pageReplace = new PageReplaceVM();
            pageReplace.NavigateTo("ContentPage");
            //if (command != null && command.CanExecute(e))
            //{
            //    command.Execute(e.ClickedItem);
            //}
        }
    }
}
