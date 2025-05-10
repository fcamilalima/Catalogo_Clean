using Catalogo.Application.DTOs;
using Catalogo.Domain.Entities;

namespace Catalogo.Application.Mappings;

public static class DomainToDTOMappingProfile
{
    public static Categoria? ToCategoria(this CategoriaDTO categoriaDTO) {
        if (categoriaDTO is null) return null;

        return new Categoria(categoriaDTO.ID, categoriaDTO.Nome, categoriaDTO.ImagemURL)
        {
            Produtos = new List<Produto>()
        };
    }

    public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
    {
        if (categoria is null) return null;
        return new CategoriaDTO
        {
            ID = categoria.ID,
            Nome = categoria.Nome,
            ImagemURL = categoria.ImagemURL
        };
    }

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

    public static ProdutoDTO? ToProdutoDTO(this ProdutoDTO produtoDTO)
    {
        if (produtoDTO is null) return null;
        return new ProdutoDTO()
        {
            ID = produtoDTO.ID,
            Nome = produtoDTO.Nome,
            Descricao = produtoDTO.Descricao,
            Preco = produtoDTO.Preco,
            ImagemURL = produtoDTO.ImagemURL,
            Estoque = produtoDTO.Estoque,
            DataCadastro = produtoDTO.DataCadastro,
            CategoriaID = produtoDTO.CategoriaID
        };
    }
}
