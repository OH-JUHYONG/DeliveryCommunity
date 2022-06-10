using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DeliveryCommunity.Model;
using DeliveryCommunity.ViewModel.Commands;

namespace DeliveryCommunity.ViewModel
{

    class WriteVM //글 생성 페이지의 값을 바인딩하여 저장후 확인버튼 누르면 boardVM에 추가
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ChatLink { get; set; }
        public int FoodCategoryMask { get; set; }
        public WritePageFoodBitToggleCommand WritePageFoodBitToggleCommand{get;set;}
        public AddArticleCommand AddArticleCommand { get; set; }
        public WriteVM()
        {
            WritePageFoodBitToggleCommand = new WritePageFoodBitToggleCommand(this);
            AddArticleCommand = new AddArticleCommand(this);
            Title = "";
            Content = "";
            ChatLink = "";
            FoodCategoryMask = 0;
        }

    }
}
