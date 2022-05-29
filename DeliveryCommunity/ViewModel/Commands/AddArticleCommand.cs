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
        WriteVM WriteVM { get; set; }
        public AddArticleCommand(WriteVM vm)
        {
            WriteVM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Article article = new Article();
            article.Content = WriteVM.Content;
            article.Title = WriteVM.Title;
            article.ChatLink= WriteVM.ChatLink;
            article.ArticleNo = boardVM.NextArticleNumber++;
            boardVM.ArticleCollection.Insert(0, article);
            //확인을 눌렀을때는 화면이 넘어가야함
            PageReplaceVM pageReplace = new PageReplaceVM();
            pageReplace.NavigateTo("MainBoardPage");
        }
    }
}
