using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using product_list.Models;
using Newtonsoft.Json;

namespace product_list.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Products;

        static ProductRepository()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "product_list.Repositories.products.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                Products = JsonConvert.DeserializeObject<List<Product>>(result);
            }
        }

        public Task<ICollection<Product>> GetProducts(string size)
        {
            var products = Products.Where(x => string.IsNullOrEmpty(size) || x.size.Contains(size.ToUpper())).ToList();
            return Task.FromResult((ICollection<Product>)products);
        }
    }
}