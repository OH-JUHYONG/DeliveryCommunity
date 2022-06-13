using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    class BoardMouseDownCommand : ICommand
    {
        public boardVM BoardVM { get; set; }
        public BoardMouseDownCommand(boardVM vm)
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
            ContentPageVM.ContentArticle = this.BoardVM.selectedArticle;
            PageReplaceVM pageReplace = new PageReplaceVM();
            pageReplace.NavigateTo("ContentPage");
        }
    }
}
