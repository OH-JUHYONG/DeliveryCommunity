using DeliveryCommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    class FoodCategoryToggleCommand : ICommand
    {
        boardVM BoardVM { get; set; }

        public FoodCategoryToggleCommand(boardVM vm)
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
            ToggleButton toggleButton = (ToggleButton)parameter;
            bool ischecked = (bool)toggleButton.IsChecked;
            string foodString = (string)toggleButton.Content;
            int foodbit = FoodCategoryDictonary.StringToFoodBit[foodString];
            if (ischecked)
            {
                BoardVM.FoodCategoryMask |= foodbit; //마스크에 추가
            }
            else
            {
                BoardVM.FoodCategoryMask &= ~foodbit; // 마스크에 제거
            }
            BoardVM.ArticleCollectionView.Refresh();
        }
    }
}
