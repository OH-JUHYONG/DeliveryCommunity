using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    class SearchByTextCommand : ICommand
    {
        boardVM BoardVM { get; set; }

        public SearchByTextCommand(boardVM vm)
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
            //BoardVM.ArticleCollectionViewSource.Filter += BoardVM.ShowOnlyQueryFilter;
            BoardVM.ArticleCollectionViewSource.View.Refresh();
        }
    }
}
