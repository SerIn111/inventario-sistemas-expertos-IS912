using inventario.Domain.Entities;
namespace inventario.Application.Interfaces;

public interface IInventarioRepository
{
    Task<IEnumerable<InventarioGlobal>> GetAllAsync();
    Task<InventarioGlobal> AddAsync(InventarioGlobal inventario); // Agregamos el contrato para el POST
}