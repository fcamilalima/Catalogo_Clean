using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Application.Mappings;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
    {
        var produtos = await _repository.GetProdutosAsync();
        return produtos.ToProdutoDTOList();
    }
    public async Task<ProdutoDTO?> GetById(int id)
    {
        var produto = await _repository.GetByIDAsync(id);
        return produto?.ToProdutoDTO();
    }

    public async Task Add(ProdutoDTO produtoDTO)
    {
        var produto = produtoDTO.ToProduto();
        _ = await _repository.CreateAsync(produto);
    }
    public async Task Update(ProdutoDTO produtoDTO)
    {
        var produto = produtoDTO.ToProduto();
        _ = await _repository.UpdateAsync(produto);
    }

    public async Task Remove(int? id)
    {
        var produto = await _repository.GetByIDAsync(id);
        _ = await _repository.RemoveAsync(produto);
    }
}
