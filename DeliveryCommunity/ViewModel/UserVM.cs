using DeliveryCommunity.Model;
using DeliveryCommunity.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DeliveryCommunity.ViewModel
{
    public class UserVM : DependencyObject
    {
        public LocationSelectCommand LocationSelectCommand { get; set; }

        //내글보기관련
        //public Dictionary<string, List<int>> UserArticleDB;
        public CollectionViewSource ArticleCollectionViewSource { get; set; }
        public ICollectionView ArticleCollectionView
        {
            get { return ArticleCollectionViewSource.View; }
        }
        public List<int> myArticleList;
        public UserVM()
        {
            Place = "장소를 선택하세요";
            LocationSelectCommand = new LocationSelectCommand(this);
            ArticleCollectionViewSource = new CollectionViewSource();
            ArticleCollectionViewSource.Source = boardVM.ArticleCollection;
            ArticleCollectionViewSource.Filter += ShowOnlyMyItem;
            myArticleList = new List<int>();
            myArticleList.Add(1);
            myArticleList.Add(2);

        }

        private void ShowOnlyMyItem(object sender, FilterEventArgs e)
        {
            Article article = e.Item as Article;
            bool hasit = false;
            foreach(int i in myArticleList)
            {
                if(article.ArticleNo == i)
                {
                    hasit = true;
                    break;
                }
            }
            e.Accepted = hasit;
        }

        public bool HasLocation// 장소를 선택했으면 true
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


        public static readonly DependencyProperty NameProperty =
        DependencyProperty.Register("Name", typeof(string),
        typeof(UserVM), new UIPropertyMetadata("로그인하세요"));

        
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set
            {
                SetValue(NameProperty, value+"님 환영합니다");
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
