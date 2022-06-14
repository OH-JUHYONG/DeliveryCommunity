using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    public class LocationSelectCommand : ICommand
    {
        //로케이션페이지에서 장소버튼을 누를경우 user 정보에 등록하는 커맨드

        UserVM UserVM { get; set; }
        public LocationSelectCommand(UserVM vm)
        {
            UserVM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string loc = (string)parameter;
            string question ="{0}이 맞나요?";
            question = string.Format(question, loc);
            var result = MessageBox.Show(question, "장소 선택", MessageBoxButton.YesNo,MessageBoxImage.Question);

            if(result == MessageBoxResult.Yes)
            {
                UserVM.Instance.Place = loc;
            }
        }
    }
}
