using Microsoft.AspNetCore.Mvc;
using inventario.Application.Interfaces;
using inventario.Domain.Entities;

namespace inventario.API.Controllers;

[ApiController]
[Route("api/inventario")] // Define la ruta: http://localhost:puerto/api/habitos
public class InventariosController : ControllerBase {
    private readonly IInventarioRepository _repository;

    // Inyección de Dependencias en acción
    public InventariosController(IInventarioRepository repository) {
        _repository = repository; 
    }

    // VERBO GET: Solicitar lectura de datos
    [HttpGet]
    public async Task<IActionResult> GetInventario() {
        var inventarios = await _repository.GetAllAsync();
        return Ok(inventarios); // HTTP 200 OK
    }

    // VERBO POST: Solicitar creación de un recurso
    [HttpPost]
    public async Task<IActionResult> CrearInventario([FromBody] InventarioGlobal inventario) {
        if (string.IsNullOrWhiteSpace(inventario.Nombre)) {
            return BadRequest("El nombre del inventario es obligatorio."); // HTTP 400 Bad Request
        }

        var nuevoInventario = await _repository.AddAsync(inventario);
        
        // HTTP 201 Created: Devuelve el recurso recién creado por cortesía RESTful
        return CreatedAtAction(nameof(GetInventario), new { id = nuevoInventario.Id }, nuevoInventario);
    }
}