using Catalogo.Application.DTOs;
using Catalogo.Domain.Entities;

namespace Catalogo.Application.DTOs.Mappings;

public static class DomainToDTOMappingProdutoProfile
{
    public static ProdutoDTO? ToProdutoDTO(this Produto produto)
    {
        if (produto is null) return null;
        return new ProdutoDTO()
        {
            ID = produto.ID,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            ImagemURL = produto.ImagemURL,
            Estoque = produto.Estoque,
            DataCadastro = produto.DataCadastro,
            CategoriaID = produto.CategoriaID
        };
    }

    public static Produto? ToProduto(this ProdutoDTO produtoDTO)
    {
        if (produtoDTO is null) return null;
        return new Produto(produtoDTO.Nome, produtoDTO.Descricao, produtoDTO.Preco,
            produtoDTO.ImagemURL, produtoDTO.Estoque, produtoDTO.DataCadastro)
        {
            CategoriaID = produtoDTO.CategoriaID
        };
    }

    public static IEnumerable<ProdutoDTO> ToProdutoDTOList(this IEnumerable<ProdutoDTO> produtos)
    {
        if (produtos is null || !produtos.Any()) 
            return new List<ProdutoDTO>();

        return produtos.Select(produto => new ProdutoDTO()
        {
            ID = produto.ID,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            ImagemURL = produto.ImagemURL,
            Estoque = produto.Estoque,
            DataCadastro = produto.DataCadastro,
            CategoriaID = produto.CategoriaID
        }).ToList();
    }
}
