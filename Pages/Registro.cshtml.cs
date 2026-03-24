using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using controlcbtis.Models;
using controlcbtis.Services;

namespace controlcbtis.Pages
{
    public class RegistroModel : PageModel
    {
        private readonly MongoDBService _mongoService;

        public RegistroModel(MongoDBService mongoService)
        {
            _mongoService = mongoService;
        }

        [BindProperty]
        public Usuario NuevoUsuario { get; set; }

        [BindProperty]
        public string Clave { get; set; }

        public string Mensaje { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Clave != "bachiller0404")
            {
                Mensaje = "Clave incorrecta";
                return Page();
            }

            await _mongoService.CreateUsuarioAsync(NuevoUsuario);

            Mensaje = "Registro exitoso";
            return Page();
        }
    }
}
