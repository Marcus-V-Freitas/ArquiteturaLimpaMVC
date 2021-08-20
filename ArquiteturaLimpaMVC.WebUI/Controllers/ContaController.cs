using ArquiteturaLimpaMVC.Dominio.Conta;
using ArquiteturaLimpaMVC.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.WebUI.Controllers
{
    public class ContaController : Controller
    {
        private readonly IAuthenticate _authenticate;

        public ContaController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Login(string urlRetorno)
        {
            return View(new LoginViewModel()
            {
                UrlRetorno = urlRetorno
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var resultado = await _authenticate.Authenticate(loginViewModel.Email, loginViewModel.Senha);

            if (resultado)
            {
                if (string.IsNullOrEmpty(loginViewModel.UrlRetorno))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginViewModel.UrlRetorno);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Inválido. A senha definida deve ser forte!");
                return View(loginViewModel);
            }
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistroViewModel registroViewModel)
        {
            var resultado = await _authenticate.RegistrarUsuario(registroViewModel.Email, registroViewModel.Senha);

            if (resultado)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Inválido. A senha definida deve ser forte!");
                return View(registroViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Sair()
        {
            await _authenticate.Sair();
            return Redirect("/Conta/Login");
        }
    }
}