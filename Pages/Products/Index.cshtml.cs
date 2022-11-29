using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoPizaa.Data;
using ContosoPizaa.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContosoPizaa.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ContosoPizaa.Data.ContosoPizzaContext _context;

        public IndexModel(ContosoPizaa.Data.ContosoPizzaContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {

            IQueryable<string> PriceQuery = from m in _context.Products
                                            orderby m.Name
                                            select m.Name;


            var products = from m in _context.Products
                           select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(x => x.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ProductName))
            {
                products = products.Where(x => x.Name == ProductName);
            }
            Price = new SelectList(await PriceQuery.Distinct().ToListAsync());

            Product = await products.ToListAsync();
        }


        public IList<Product> Product { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Price { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ProductName { get; set; }



    }
}
