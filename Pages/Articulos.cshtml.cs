using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using controlcbtis.Models;
using controlcbtis.Services;

namespace controlcbtis.Pages
{
    public class ArticulosModel : PageModel
    {
        private readonly MongoDBService _mongoService;

        public ArticulosModel(MongoDBService mongoService)
        {
            _mongoService = mongoService;
        }

        [BindProperty]
        public Articulo NuevoArticulo { get; set; }

        public List<Articulo> ListaArticulos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToPage("/Login");
            }

            ListaArticulos = await _mongoService.GetArticulosAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mongoService.CreateArticuloAsync(NuevoArticulo);
            return RedirectToPage();
        }
    }
}