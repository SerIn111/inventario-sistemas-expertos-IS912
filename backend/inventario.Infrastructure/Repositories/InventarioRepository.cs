using Microsoft.EntityFrameworkCore;
using inventario.Application.Interfaces;
using inventario.Domain.Entities;
using inventario.Infrastructure.Data;

namespace inventario.Infrastructure.Repositories;

// Implementamos la interfaz (La finca obedece a la receta)
public class InventarioRepository : IInventarioRepository
{
    private readonly InventarioDbContext _context;
    
    // El constructor recibe el contexto de EF Core
    public InventarioRepository(InventarioDbContext context) {
        _context = context;
    }
    
    public async Task<IEnumerable<InventarioGlobal>> GetAllAsync() {
        return await _context.InventariosGlobales.ToListAsync(); // Consulta real a BD (Magia SQL)
    }
    
    public async Task<InventarioGlobal> AddAsync(InventarioGlobal inventario) {
        await _context.InventariosGlobales.AddAsync(inventario);
        
        // SaveChangesAsync envuelve la operación en una transacción SQL (COMMIT)
        await _context.SaveChangesAsync(); 
        
        return inventario;
    }
}