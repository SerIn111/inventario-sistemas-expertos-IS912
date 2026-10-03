using Microsoft.EntityFrameworkCore;
using inventario.Domain.Entities;

namespace inventario.Infrastructure.Data;

public class InventarioDbContext : DbContext {
    public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options) { }
    
    public DbSet<InventarioGlobal> InventariosGlobales { get; set; }
}