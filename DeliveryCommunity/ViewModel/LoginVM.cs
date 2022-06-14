using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryCommunity.ViewModel.Commands;

namespace DeliveryCommunity.ViewModel
{
    public class LoginVM// 주의: 서버가 없으므로 인증같은거 없음
    {
        public LoginButtonCommand LoginButtonCommand { get; set; }
        public LoginVM()
        {
            LoginButtonCommand = new LoginButtonCommand(this);
        }

    }
}
