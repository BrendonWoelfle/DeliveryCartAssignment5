#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using deliverycart.Data;
using deliverycart.Models;

namespace deliverycart.Pages_Orders
{
    public class CreateModel : PageModel
    {
        private readonly deliverycart.Data.Assignment3XTestsContext _context;

        public CreateModel(deliverycart.Data.Assignment3XTestsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID");
        ViewData["ItemID"] = new SelectList(_context.Set<Item>(), "ItemID", "ItemID");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.AddOrderAsync(Order);

            return RedirectToPage("./Index");
        }
    }
}
