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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace DeliveryCommunity.ViewModel
{
    class boardVM
    {
        public static ObservableCollection<Article> ArticleCollection = new ObservableCollection<Article>();

        public static int NextArticleNumber { get; set; }
        //command
        public BoardMouseDownCommand boardMouseDownCommand { get; set; }
        public SearchByTextCommand SearchCommand { get; set; }
        public string TextQuery { get; set; }
        public FoodCategoryToggleCommand FoodCategoryToggleCommand { get; set; }
        public int FoodCategoryMask { get; set; }
        
        public Article selectedArticle { get; set; }
        //CollectionViewSource: 중간 layer에서 view를 관리해줌 filter를 적용해도 원본은 바뀌지 않음
        public CollectionViewSource ArticleCollectionViewSource { get; set; }
        public ICollectionView ArticleCollectionView
        {
            get { return ArticleCollectionViewSource.View; }
        }


        public boardVM()
        {
            boardMouseDownCommand = new BoardMouseDownCommand(this);
            SearchCommand = new SearchByTextCommand(this);
            FoodCategoryToggleCommand = new FoodCategoryToggleCommand(this);
            FoodCategoryMask = 0;
            TextQuery = "";
            ArticleCollectionViewSource = new CollectionViewSource();
            ArticleCollectionViewSource.Source = ArticleCollection;
            ArticleCollectionViewSource.Filter += ShowOnlyFilteredItem;
            AddTempData();
            

        }


        public void AddTempData()
        {
            if(ArticleCollection.Count > 1) return;//page가 바뀔때마다 실행되므로 한번실행하면 막아둠

            NextArticleNumber = 1;
            ArticleCollection.Add(new Article() {
                ArticleNo = NextArticleNumber++,
                Title = "찜닭 드실 분?",
                Content = "찜닭 같이 먹을 분 구해요",
                Place = "참빛관",
                Category = "한식",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["한식"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = NextArticleNumber++,
                Title = "갈비탕 먹을 사람?",
                Content = "갈비탕 시킬려고 하는데 주문 같이 하실 분??",
                Place = "대동관",
                Category = "한식",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["한식"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = NextArticleNumber++,
                Title = "비오는데 짬뽕",
                Content = "비오는데 짬뽕 같이 시킬 분? 오카로 이야기해요",
                Place = "공과대학 7호관",
                Category = "중식",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["중식"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = NextArticleNumber++,
                Title = "피자 먹을 분?",
                Content = "피자 먹고 싶은데 혼자서 한판 시키기 부담스러워요 같이 드실 분 들어오세요",
                Place = "상과대학 1호관",
                Category = "피자",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["피자"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = NextArticleNumber++,
                Title = "아웃백 딜리버리",
                Content = "제목 그대로 아웃백 딜리버리 드실 분 오카 들어오세요",
                Place = "참빛관",
                Category = "양식",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["양식"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = NextArticleNumber++,
                Title = "버거킹 먹고 싶어요",
                Content = "버거킹 지금 할인하는데 같이 주문할 분?",
                Place = "농업생명과학대학 본관",
                Category = "햄버거",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["햄버거"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = NextArticleNumber++,
                Title = "치킨 한자리 남는데",
                Content = "BBQ 치킨 한자리 남는데 들어올 분? 선착순",
                Place = "대동관",
                Category = "치킨",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["치킨"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = NextArticleNumber++,
                Title = "엽떡 로제 떡볶이 먹고 싶어요ㅠㅠ",
                Content = "엽떡 로제 같이 먹을 분? 혼자 시키기에는 양이 많아서요",
                Place = "공과대학 7호관",
                Category = "분식",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["분식"]
            });
        }

        public void ShowOnlyFilteredItem(object sender, FilterEventArgs e)
        {
            Article article = e.Item as Article;
            e.Accepted = IsInQuery(article) && IsSelectedFoodCategory(article);
        }

        public bool IsInQuery(Article article)
        {
            // 필터가 비어있다면 전부 보여줌
            if (string.IsNullOrEmpty(TextQuery))
            {
                return true;
            }
            else
            {
                return article.ToString().Contains(TextQuery);
            }

        }
        public bool IsSelectedFoodCategory(Article article)
        {
            // 마스크가 비어있다면 전부 보여줌
            if (FoodCategoryMask == 0)
            {
                return true;
            }
            else
            {
                if ((article.FoodCategoryBit & FoodCategoryMask) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
