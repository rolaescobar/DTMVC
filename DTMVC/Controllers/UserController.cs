using DTMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTMVC.Controllers
{
    public class UserController : Controller
    {
      
        public IActionResult Index()
        {

            //Datos de ejemplo, simulando que  vienen de la  base de datos

            var Users = new List<User>
            {
                new User { Id = 1,FirstName = "Rolando",LastName= "José", Email = "rolando.garcia@upana.edu.gt",Role="ADMIN"},
                new User { Id = 2,FirstName = "Juan",LastName= "José", Email = "juan.garcia@upana.edu.gt",Role="DELEGADO"},
                new User { Id = 3,FirstName = "Sergio",LastName= "Emilio", Email = "sergio.emilio@upana.edu.gt",Role="ADMIN"},
                new User { Id = 4,FirstName = "Marvin",LastName= "Gabriel", Email = "marvin.gabriel@upana.edu.gt",Role="ADMIN"},


            };

            return View(Users);
        }

        
    }
}
