using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    public class ClickMyArticleCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;
        UserVM UserVM { get; set; }
        public ClickMyArticleCommand(UserVM vm)
        {
            UserVM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string s = (string)parameter;
            PageReplaceVM pageReplace = new PageReplaceVM();
            pageReplace.NavigateTo("UpdatePage");
        }
    }
}
