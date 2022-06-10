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
    class WritePageFoodBitToggleCommand : ICommand
    {
        WriteVM WriteVM { get; set; }

        public WritePageFoodBitToggleCommand(WriteVM vm)
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
            ToggleButton toggleButton = (ToggleButton)parameter;
            bool ischecked = (bool)toggleButton.IsChecked;
            string foodString = toggleButton.Content.ToString().Remove(0,2); // 이름옆에 #이랑공백 제거
            //string foodString = toggleButton.Content.ToString(); //

            int foodbit = FoodCategoryDictonary.StringToFoodBit[foodString];
            if (ischecked)
            {
                WriteVM.FoodCategoryMask |= foodbit; //마스크에 추가
            }
            else
            {
                WriteVM.FoodCategoryMask &= ~foodbit; // 마스크에 제거
            }
        }
    }
}
