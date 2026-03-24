using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using controlcbtis.Models;
using controlcbtis.Services;

namespace controlcbtis.Pages
{
    public class LoginModel : PageModel
    {
        private readonly MongoDBService _mongoService;

        public LoginModel(MongoDBService mongoService)
        {
            _mongoService = mongoService;
        }

        [BindProperty]
        public Usuario UsuarioLogin { get; set; }

        public string Mensaje { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var usuario = await _mongoService.GetUsuarioAsync(
                UsuarioLogin.Correo,
                UsuarioLogin.Password
            );

            if (usuario != null)
            {
                HttpContext.Session.SetString("Usuario", usuario.Correo);
                return RedirectToPage("/Prestamos");
            }

            Mensaje = "Datos incorrectos";
            return Page();
        }
    }
}
