using ArquiteturaLimpaMVC.Dominio.Conta;
using Microsoft.AspNetCore.Identity;
using System;

namespace ArquiteturaLimpaMVC.Infra.Data.Identity
{
    public class SeedUsuarioRoleInicial : ISeedUsuarioRoleInicial
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedUsuarioRoleInicial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsuario()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result is null)
            {
                var usuario = new ApplicationUser();
                usuario.UserName = "usuario@localhost";
                usuario.Email = "usuario@localhost";
                usuario.NormalizedEmail = "USUARIO@LOCALHOST";
                usuario.NormalizedUserName = "USUARIO@LOCALHOST";
                usuario.EmailConfirmed = true;
                usuario.LockoutEnabled = false;
                usuario.SecurityStamp = Guid.NewGuid().ToString();

                var resultado = _userManager.CreateAsync(usuario, "Teste@2021").Result;

                if (resultado.Succeeded)
                {
                    _userManager.AddToRoleAsync(usuario, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result is null)
            {
                var usuario = new ApplicationUser();
                usuario.UserName = "admin@localhost";
                usuario.Email = "admin@localhost";
                usuario.NormalizedEmail = "ADMIN@LOCALHOST";
                usuario.NormalizedUserName = "ADMIN@LOCALHOST";
                usuario.EmailConfirmed = true;
                usuario.LockoutEnabled = false;
                usuario.SecurityStamp = Guid.NewGuid().ToString();

                var resultado = _userManager.CreateAsync(usuario, "Teste@2021").Result;

                if (resultado.Succeeded)
                {
                    _userManager.AddToRoleAsync(usuario, "Admin").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult resultado = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult resultado = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}