using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCommunity.Model
{
    public class Article
    {
        //글번호
        //제목,
        //본문,
        //장소,
        //모인인원,
        //카테고리,
        //링크
        //만든날짜?
        public int ArticleNo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Place { get; set; }
        public int PeopleCount { get; set; }
        public int PeopleMaxCount { get; set; }
        public int ExpireHour { get; set; }
        public int ExpireMin { get; set; }
        public string Category { get; set; }
        public string ChatLink { get; set; }
        public int FoodCategoryBit { get; set; }
        //public int BuildingCategoryBit { get; set; }
        public Article()
        {
            ArticleNo = 0;
            Title = "임시";
            Content = "aaaaaaaaaaaaaaaaaabbbbcbcbcbcbddd";
            Place = "공대 7호관";
            PeopleCount = 1;
            PeopleMaxCount = 3;
            ExpireHour = 20;
            ExpireMin = 30;
            Category = "치킨";
            ChatLink = "openkakao";
            FoodCategoryBit = FoodCategoryDictonary.StringToFoodBit[Category];
            //BuildingCategoryBit = BuildingCategoryDictionary.StringToBuildingBit[Place];
            
        }
        public override string ToString()
        {
            return Title + Content + Place + Category;
        }

    }
}
