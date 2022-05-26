using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCommunity.Model
{
    class FoodCategoryDictonary
    {
        public static Dictionary<int, string> FoodBitToString = new Dictionary<int, string>()
        {
            {0b1,"한식"},
            {0b10,"일식"},
            {0b100,"중식"},
            {0b1000,"치킨"},
            {0b10000,"피자"},
            {0b100000,"햄버거"},
            {0b1000000,"양식"},
            {0b10000000,"분식"},
        };
        public static Dictionary<string, int> StringToFoodBit = new Dictionary<string, int>()
        {
            {"한식",0b1},
            {"일식",0b10},
            {"중식",0b100},
            {"치킨",0b1000},
            {"피자",0b10000},
            {"햄버거",0b100000},
            {"양식",0b1000000},
            {"분식",0b10000000},
        };
    }
}
