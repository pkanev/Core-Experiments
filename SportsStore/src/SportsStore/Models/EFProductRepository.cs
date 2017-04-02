using System;
using System.Collections.Generic;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Products => context.Products;
    }
}
