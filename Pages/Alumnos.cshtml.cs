using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using controlcbtis.Models;
using controlcbtis.Services;

namespace controlcbtis.Pages
{
    public class AlumnosModel : PageModel
    {
        private readonly MongoDBService _mongoService;

        public AlumnosModel(MongoDBService mongoService)
        {
            _mongoService = mongoService;
        }

        [BindProperty]
        public Alumno NuevoAlumno { get; set; }

        public List<Alumno> ListaAlumnos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToPage("/Login");
            }

            ListaAlumnos = await _mongoService.GetAlumnosAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mongoService.CreateAlumnoAsync(NuevoAlumno);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            await _mongoService.DeleteAlumnoAsync(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(Alumno alumno)
        {
            await _mongoService.UpdateAlumnoAsync(alumno);
            return RedirectToPage();
        }
    }
}