using DeliveryCommunity.Model;
using DeliveryCommunity.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DeliveryCommunity.ViewModel
{
    class boardVM
    {
        public ObservableCollection<Article> ArticleCollection { get; set; }
        public int PrimaryArticleNumber = 1;
        //command
        public SearchByTextCommand SearchCommand { get; set; }
        public string TextQuery { get; set; }
        public FoodCategoryToggleCommand FoodCategoryToggleCommand { get; set; }
        public int FoodCategoryMask { get; set; }
        public AddArticleCommand AddArticleCommand { get; set; }

        //CollectionViewSource: 중간 layer에서 view를 관리해줌 filter를 적용해도 원본은 바뀌지 않음
        public CollectionViewSource ArticleCollectionViewSource { get; set; }
        public ICollectionView ArticleCollectionView
        {
            get { return ArticleCollectionViewSource.View; }
        }


        public boardVM()
        {
            AddArticleCommand = new AddArticleCommand(this);
            SearchCommand = new SearchByTextCommand(this);
            FoodCategoryToggleCommand = new FoodCategoryToggleCommand(this);
            FoodCategoryMask = 0;
            TextQuery = "";
            ArticleCollection = new ObservableCollection<Article>();
            ArticleCollectionViewSource = new CollectionViewSource();
            ArticleCollectionViewSource.Source = ArticleCollection;
            ArticleCollectionViewSource.Filter += ShowOnlyFilteredItem;
            AddTempData();
        }


        public void AddTempData()
        {
            
            ArticleCollection.Add(new Article() {
                ArticleNo = PrimaryArticleNumber++,
                Title = "3333",
                Content = "aaaa bbbb cccc ddddd",
                Place = "한빛관",
                Category = "한식",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["한식"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = PrimaryArticleNumber++,
                Title = "3333",
                Content = "aaaa bbbb cccc ddddd",
                Place = "한빛관",
                Category = "한식",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["한식"]
            });
            ArticleCollection.Add(new Article()
            {
                ArticleNo = PrimaryArticleNumber++,
                Title = "3333",
                Content = "aaaa bbbb cccc ddddd",
                Place = "한빛관",
                Category = "중식",
                ChatLink = "open.kakao.어쩌구",
                PeopleCount = 1,
                FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit["중식"]
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
