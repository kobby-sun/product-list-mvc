using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_list.Commands;
using product_list.Models;

namespace product_list.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("index.html");
        }

        public Task<IActionResult> Products([FromRoute] string filter, [FromServices] IGetProductsCommand command)
        {
            return command.ExecuteAsync(filter);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
