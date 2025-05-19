using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catologo.API.Controllers;
[Route("api/v1/[Controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
    {
        var produtosDTO = await _service.GetProdutos();
        return Ok(produtosDTO);
    }

    [HttpGet("{id}", Name = "GetProduto")]
    public async Task<ActionResult<ProdutoDTO>> Get(int id)
    {
        var produtoDTO = await _service.GetById(id);
        if (produtoDTO == null) return NotFound();
        return Ok(produtoDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.Add(produtoDTO);
        return new CreatedAtRouteResult("GetProduto",
            new { id = produtoDTO.ID }, produtoDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDTO)
    {
        if(id != produtoDTO.ID) return BadRequest();
        await _service.Update(produtoDTO);
        return Ok(produtoDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProdutoDTO>> Delete(int id)
    {
        var produtoDTO = await _service.GetById(id);
        if (produtoDTO == null) return NotFound();
        await _service.Remove(id);
        return Ok(produtoDTO);
    }
}
