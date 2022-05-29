using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCommunity.Model
{
    class BuildingCategoryDictionary
    {
        public static Dictionary<int, string> BuildingBitToString = new Dictionary<int, string>()
        {
            {0b1,"참빛관"},
            {0b10,"대동관"},
            {0b100,"공과대학 1호관"},
            {0b1000,"공과대학 7호관"},
            {0b10000,"농업생명과학대학 본관"},
            {0b100000,"농업생명과학대학 1호관"},
            {0b1000000,"인문대학 1호관"},
            {0b10000000,"인문대학 2호관"},
            {0b100000000,"상과대학 2호관"},
            {0b1000000000,"상과대학 2호관"},
        };
        public static Dictionary<string, int> StringToBuildingBit = new Dictionary<string, int>()
        {
            {"참빛관", 0b1},
            {"대동관", 0b10},
            {"공과대학 1호관", 0b100},
            {"공과대학 7호관", 0b1000},
            {"농업생명과학대학 본관", 0b10000},
            {"농업생명과학대학 1호관", 0b100000},
            {"인문대학 1호관", 0b1000000},
            {"인문대학 2호관", 0b10000000},
            {"상과대학 2호관", 0b100000000},
            {"상과대학 2호관", 0b1000000000},
        };
    }
}
