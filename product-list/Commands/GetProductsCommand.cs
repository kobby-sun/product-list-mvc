namespace product_list.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using product_list.Repositories;
    using product_list.Models;
    using Microsoft.AspNetCore.Mvc;

    public class GetProductsCommand : IGetProductsCommand
    {
        private readonly IProductRepository productRepository;

        public GetProductsCommand(
            IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IActionResult> ExecuteAsync(string filter)
        {
            var list = await productRepository.GetProducts(filter);

            return new OkObjectResult(list);
        }
    }
}
