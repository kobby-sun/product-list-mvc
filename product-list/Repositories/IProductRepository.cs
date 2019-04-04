using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using product_list.Models;

namespace product_list.Repositories
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProducts(string size);
    }
}