namespace product_list.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public interface IAsyncCommand<T>
    {
        Task<IActionResult> ExecuteAsync(T parameter, CancellationToken cancellationToken = default);
    }
}
