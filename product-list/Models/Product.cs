using System;

namespace product_list.Models
{
    public class Product
    {
        public int index { get; set; }

        public bool isSale { get; set; }

        public bool isExclusive { get; set; }

        public string price { get; set; }

        public string productImage { get; set; }

        public string productName { get; set; }

        public string[] size { get; set; }
    }
}