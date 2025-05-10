using Catalogo.Application.DTOs;

namespace Catalogo.Application.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> GetProdutos();
    Task<ProdutoDTO> GetById(int id);
    Task Add(ProdutoDTO produtoDTO);
    Task Update(ProdutoDTO produtoDTO);
    Task Remove(int? id);
}
