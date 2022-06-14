using DeliveryCommunity.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryCommunity.ViewModel
{
    public class UserVM : DependencyObject
    {
        public LocationSelectCommand LocationSelectCommand { get; set; }

        public UserVM()
        {
            Place = "장소를 선택하세요";
            LocationSelectCommand = new LocationSelectCommand(this);
        }
        public bool HasLocation
        {
            get { return (bool)GetValue(HasLocationProperty); }
            set
            {
                SetValue(HasLocationProperty, value);
            }
        }
        public static readonly DependencyProperty HasLocationProperty =
        DependencyProperty.Register("HasLocation", typeof(bool),
        typeof(UserVM), new UIPropertyMetadata(false));

        public static readonly DependencyProperty PlaceProperty =
        DependencyProperty.Register("Place", typeof(string),
        typeof(UserVM), new UIPropertyMetadata("없음"));

        public string Place // 호출시 Instance.Place로 해야 같은 vm의 place접근가능 GetPlace()를 이용하세요
        {
            get { return (string)GetValue(PlaceProperty); }
            set { 
                SetValue(PlaceProperty, value);
            }
        }

        public static UserVM Instance { get; private set; }

        static UserVM()
        {
            Instance = new UserVM();
        }
        public static string GetPlace()
        {
            return Instance.Place;
        }
        
    }
}
