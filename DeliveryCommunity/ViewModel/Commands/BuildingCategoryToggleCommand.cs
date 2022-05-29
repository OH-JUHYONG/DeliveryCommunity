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
    class BuildingCategoryToggleCommand : ICommand
    {
        boardVM BoardVM { get; set; }

        public BuildingCategoryToggleCommand(boardVM vm)
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
            string buildingString = (string)toggleButton.Content;
            int buildingbit = BuildingCategoryDictionary.StringToBuildingBit[buildingString];
            if(ischecked)
            {
                BoardVM.BuildingCategoryMask |= buildingbit; //마스크에 추가
            }
            else
            {
                BoardVM.BuildingCategoryMask &= ~buildingbit; // 마스크에 제거
            }
            BoardVM.ArticleCollectionView.Refresh();
        }
    }
}
