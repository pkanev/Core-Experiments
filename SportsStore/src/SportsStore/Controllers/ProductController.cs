using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult List(int page = 1)
            => View(new ProductsListViewModel
            {
                Products = this.repository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * this.PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = this.PageSize,
                    TotalItems = this.repository.Products.Count()
                }
            });
    }
}
