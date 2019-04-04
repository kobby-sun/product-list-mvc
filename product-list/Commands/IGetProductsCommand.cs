namespace product_list.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using product_list.Repositories;
    using product_list.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface IGetProductsCommand : IAsyncCommand<string>
    {
    }
}
