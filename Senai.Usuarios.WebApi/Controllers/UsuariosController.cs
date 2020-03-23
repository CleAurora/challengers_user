using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Senai.Usuarios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}