using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public Task Add(ProdutoDTO produtoDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ProdutoDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProdutoDTO>> GetProdutos()
    {
        throw new NotImplementedException();
    }

    public Task Remove(int? id)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProdutoDTO produtoDTO)
    {
        throw new NotImplementedException();
    }
}
