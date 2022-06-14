using DeliveryCommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    public class ContentPageJoinButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        ContentPageVM ContentPageVM { get; set; }
        public ContentPageJoinButtonCommand(ContentPageVM vm)
        {
            ContentPageVM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int index = boardVM.ArticleCollection.Count - ContentPageVM.ContentArticle.ArticleNo - 1; //역순으로 삽입되므로 총개수 - 글번호 -1
            Article a = boardVM.ArticleCollection[index];
            if (a.PeopleCount < a.PeopleMaxCount)
            {
                boardVM.ArticleCollection[index].PeopleCount++;
            }
            else
            {
                MessageBox.Show("인원이 초과 되었습니다.","오류",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            PageReplaceVM pageReplace = new PageReplaceVM();
            pageReplace.NavigateTo("MainBoardPage");
        }
    }
}
