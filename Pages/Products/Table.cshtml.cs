using ContosoPizaa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoPizaa.Data;


namespace ContosoPizaa.Pages.Products
{
    public class TableModel : PageModel
    {
        private readonly ContosoPizzaContext _context;
        public IEnumerable<Product> Product { get; set; }


        public TableModel(ContosoPizzaContext context) 
        {
            _context = context;
        }


        public void OnGet()
        {
            Product = _context.Products;
        }




    }
}
