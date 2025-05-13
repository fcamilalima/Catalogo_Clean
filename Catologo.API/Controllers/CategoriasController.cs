using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catologo.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _service;

    public CategoriasController(ICategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        try
        {
            var categorias = await _service.GetCategorias();
            return Ok(categorias);

        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpGet("{id:int}", Name = "GetCategoria")]
    public async Task<ActionResult<CategoriaDTO>> GetById(int id)
    {
        try
        {
            var categoria = await _service.GetById(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.Add(categoriaDTO);
            return new CreatedAtRouteResult("GetCategoria", 
                new { id = categoriaDTO.ID }, categoriaDTO);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
