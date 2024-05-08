using IELCadastroEstudante.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IELCadastroEstudante.Controllers
{
    public class HomeController : Controller
    {
 
        private readonly ILogger<HomeController> _logger;

        [AllowAnonymous]
        public IActionResult Index(bool erroLogin)
        {

            if (erroLogin)
            {
                ViewBag.Erro = "Usuário e/ou senha estão incorretos";

            }
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Estudante");
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioViewModel user)
        {
            var usuarioDB = new UsuarioViewModel()
            {
                Usuario = "admin",
                Senha = "123456",
                Funcao = "adm"
            };

            if (!usuarioDB.Usuario.Equals(user.Usuario) ||
                !usuarioDB.Senha.Equals(user.Senha)
                )
            {
                return RedirectToAction("Index", new { erroLogin = true });
            }

            await new LoginService().Login(HttpContext, user);
            return RedirectToAction("Index", "Estudante");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Sair()
        {
            await new LoginService().Logoff(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Profile()
        {
            ViewBag.Permissoes = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
            return View();
        }

    }
}
