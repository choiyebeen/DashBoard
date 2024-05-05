using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choiyebeen.Model
{
    public class SalesData // 자바랑 C#이랑 똑같이 유지해야함 
    {
        public string store { get; set; }
        public string time { get; set; }
        public List<ProductDetail> detail { get; set; }
    }

    public class ProductDetail // 이게 위에 있는 List<ProductDetail>로 들어간것
    {
        public string product { get; set; }
        public int count { get; set; }
        public int price { get; set; }
    }

    public class Inventory
    {
        public List<GetDetailItem> Detail { get; set; }

        public class GetDetailItem
        {
            public string Product { get; set; }
            public string Count { get; set; }
        }
    }
}
