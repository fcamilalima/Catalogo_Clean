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
            var categoriaDTO = await _service.GetById(id);
            if (categoriaDTO == null) return NotFound();
            return Ok(categoriaDTO);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.Add(categoriaDTO);
        return new CreatedAtRouteResult("GetCategoria",
            new { id = categoriaDTO.ID }, categoriaDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != categoriaDTO.ID) return BadRequest();
        await _service.Update(categoriaDTO);
        return Ok(categoriaDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoriaDTO>> Delete(int id)
    {
        var categoriaDTO = await _service.GetById(id);
        if (categoriaDTO == null) return NotFound();
        await _service.Remove(id);
        return Ok(categoriaDTO);
    }
}
