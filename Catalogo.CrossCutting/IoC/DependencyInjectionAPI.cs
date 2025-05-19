using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Repositories;
using Catalogo.Domain.Interfaces;
using Catalogo.Application.Interfaces;
using Catalogo.Application.Services;

namespace Catalogo.CrossCutting.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfraestructureAPI(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 4, 4))));

        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<ICategoriaService, CategoriaService>();

        return services;
    }
}
