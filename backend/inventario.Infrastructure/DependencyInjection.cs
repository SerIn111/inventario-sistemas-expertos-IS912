using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using inventario.Application.Interfaces;
using inventario.Infrastructure.Data;
using inventario.Infrastructure.Repositories;

namespace inventario.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString) {
        
        // 1. Configuramos el acceso a PostgreSQL
        services.AddDbContext<InventarioDbContext>(options =>
            options.UseNpgsql(connectionString));

        // 2. LA INYECCIÓN CLAVE (El contrato firmado por el Gerente):
        // "Cada vez que un Chef (Controlador) pida la Receta (IInventarioRepository), 
        // entrégale los datos de la Finca PostgreSQL (InventarioRepository)"
        services.AddScoped<IInventarioRepository, InventarioRepository>();

        return services;
    }
}