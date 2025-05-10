using Catalogo.Domain.Validation;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities;

public sealed class Categoria : Entity
{
    public Categoria(string nome, string imagemURL)
    {
        ValidateDomain(nome, imagemURL);
    }

    public Categoria(int id, string nome, string imagemURL)
    {
        DomainExceptionValidation.When(id < 0, "Valor do ID inválido!");
        ID = id;
        ValidateDomain(nome, imagemURL);
    }

    public string Nome { get; private set; }

    public string ImagemURL { get; set; }
    public ICollection<Produto> Produtos { get; set; }
    private void ValidateDomain(string nome, string imagemURL)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), 
            "Nome inválido. O nome é obrigatório!");

        DomainExceptionValidation.When(string.IsNullOrEmpty(imagemURL), 
            "Nome da imagem inválido. O nome da imagem é obrigatório!");

        DomainExceptionValidation.When(nome.Length < 3,
            "O nome deve ter, no mínimo, 3 caracteres!");

        DomainExceptionValidation.When(imagemURL.Length < 5,
            "O nome da imagem deve ter, no máximo, 5 caracteres!");

        Nome = nome;
        ImagemURL = imagemURL;
    }
}
