using DeliveryCommunity.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCommunity.ViewModel
{
    public class UserVM
    {
        //현재 유저의 장소와 이름
        public static string Place { get; set; }
        public static string Name { get; set; }

        public LocationSelectCommand LocationSelectCommand { get; set; }
        public UserVM()
        {
            LocationSelectCommand = new LocationSelectCommand(this);
        }
    }
}
