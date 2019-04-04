using System;
using System.Collections.Generic;
using product_list.Models;

namespace product_list.Repositories
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts(string size);
    }
}