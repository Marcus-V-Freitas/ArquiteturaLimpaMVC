using ArquiteturaLimpaMVC.Dominio.Conta;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string senha)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, senha, false, lockoutOnFailure: false);
            return resultado.Succeeded;
        }

        public async Task<bool> RegistrarUsuario(string email, string senha)
        {
            var usuario = new ApplicationUser()
            {
                UserName = email,
                Email = email
            };

            var resultado = await _userManager.CreateAsync(usuario, senha);

            if (resultado.Succeeded)
            {
                await _signInManager.SignInAsync(usuario, isPersistent: false);
            }
            return resultado.Succeeded;
        }

        public async Task Sair()
        {
            await _signInManager.SignOutAsync();
        }
    }
}