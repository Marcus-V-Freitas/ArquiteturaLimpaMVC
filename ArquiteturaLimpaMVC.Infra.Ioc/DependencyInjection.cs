using ArquiteturaLimpaMVC.Dominio.Interfaces;
using ArquiteturaLimpaMVC.Infra.Data.Context;
using ArquiteturaLimpaMVC.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraEstrutura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options=> 
                {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                 x => x.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
                });

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            
            return services;
        }
    }
}
