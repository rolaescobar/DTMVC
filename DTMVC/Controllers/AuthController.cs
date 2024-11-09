using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PersonaMVC.Controllers
{
    public class AuthController : Controller
    {
        // Vista de Login (GET)
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.HideNavBar = true; // Por si necesitas ocultar la barra de navegación
            return View();
        }

        // Proceso de Login (POST)
        [HttpPost]
        public IActionResult Login(string NombreUsuario, string ClaveUsuario)
        {
            // Verificar directamente el nombre de usuario y la contraseña sin base de datos
            if (NombreUsuario == "rjgarcia" && ClaveUsuario == "1234")
            {
            

                return RedirectToAction("Index", "Home"); 
            }

            // Si las credenciales son incorrectas
            ViewBag.HideNavBar = true;
            ViewBag.Error = "Credenciales inválidas";
            return View();
        }

        // Proceso de Logout (POST)
        [HttpPost]
        public IActionResult Logout()
        {
            // Limpiar la sesión
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
