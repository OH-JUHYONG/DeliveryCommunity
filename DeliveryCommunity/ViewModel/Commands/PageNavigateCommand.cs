using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    class PageNavigateCommand : ICommand
    {
        PageReplaceVM prVM { get; set; }
        public PageNavigateCommand(PageReplaceVM vm)
        {
            prVM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object PageNameParameter)
        {
            string pageName = (string)PageNameParameter;
            prVM.NavigateTo(pageName);
        }
    }
}
