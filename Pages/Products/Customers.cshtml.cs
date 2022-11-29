using ContosoPizaa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizaa.Pages.Products
{
    public class CustomersModel : PageModel
    {
        private readonly ContosoPizaa.Data.ContosoPizzaContext _context;

        public CustomersModel(ContosoPizaa.Data.ContosoPizzaContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {

            IQueryable<string> CustomersQuery = from m in _context.Customers
                                                orderby m.FirstName
                                                select m.FirstName;

            IQueryable<string> CustomersAdres = from m in _context.Customers
                                                orderby m.Address
                                                select m.Address;


            var Customers = from m in _context.Customers
                            select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Customers = Customers.Where(x => x.Email.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(CustomerFirstName))
            {
                Customers = Customers.Where(x => x.FirstName == CustomerFirstName);
            }
            FirstName = new SelectList(await CustomersQuery.Distinct().ToListAsync());

            if (!string.IsNullOrEmpty(CustomerAdrs))
            {
                Customers = Customers.Where(x => x.Address == CustomerAdrs);
            }
            Addres = new SelectList(await CustomersAdres.Distinct().ToListAsync());


            Customer = await Customers.ToListAsync();
        }


        public IList<Customer> Customer { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CustomerFirstName { get; set; }

        public SelectList? Addres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CustomerAdrs { get; set; }
    }
}
