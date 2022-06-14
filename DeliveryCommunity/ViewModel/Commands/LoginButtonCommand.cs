using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel.Commands
{
    public class LoginButtonCommand : ICommand // 주의: 서버가 없으므로 로그인인증관련 로직없음
    {
        public event EventHandler CanExecuteChanged;
        LoginVM LoginVM { get; set; }
        public LoginButtonCommand(LoginVM vm)
        {
            LoginVM = vm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string s = (string)parameter;

            if (!string.IsNullOrWhiteSpace(s)){ //뭔가 입력되고 버튼 누르면 이름바뀌고 페이지 넘어감
                UserVM.Instance.Name = s;
                PageReplaceVM pageReplace = new PageReplaceVM();
                pageReplace.NavigateTo("MainBoardPage");
            }

            
        }
    }
}
