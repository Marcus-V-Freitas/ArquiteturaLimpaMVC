using ArquiteturaLimpaMVC.Aplicacao.Interfaces;
using ArquiteturaLimpaMVC.Aplicacao.Mappings;
using ArquiteturaLimpaMVC.Aplicacao.Services;
using ArquiteturaLimpaMVC.Dominio.Conta;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using ArquiteturaLimpaMVC.Infra.Data.Context;
using ArquiteturaLimpaMVC.Infra.Data.Identity;
using ArquiteturaLimpaMVC.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ArquiteturaLimpaMVC.Infra.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfraEstruturaAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                 x => x.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddAutoMapper(typeof(DominioParaDTOMappingProfile));

            var handlers = AppDomain.CurrentDomain.Load("ArquiteturaLimpaMVC.Aplicacao");
            services.AddMediatR(handlers);

            return services;
        }
    }
}