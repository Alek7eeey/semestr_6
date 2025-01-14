﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab_4.Data;
using Lab_4.Models;

namespace Lab_4.Pages.Link
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Links Link { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var link =  await _context.Links.FirstOrDefaultAsync(m => m.Id == id);
            if (link == null) return NotFound();

            Link = link;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var existingLink = await _context.Links.FindAsync(Link.Id);
            if (existingLink == null)
            {
                return NotFound();
            }

            existingLink.Url = Link.Url;
            existingLink.Description = Link.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(Link.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LinkExists(int id)
        {
          return (_context.Links?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
