using DeliveryCommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    class AddArticleCommand : ICommand
    {
        boardVM BoardVM { get; set; }

        public AddArticleCommand(boardVM vm)
        {
            BoardVM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BoardVM.ArticleCollection.Insert(0, new Article());
        }
    }
}
