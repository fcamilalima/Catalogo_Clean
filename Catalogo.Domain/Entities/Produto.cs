using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entities;

public sealed class Produto : Entity
{
    public Produto(int ID, string nome, string descricao, decimal preco, string imagemURL, int estoque, DateTime dataCadastro)
    {
        ValidateDomain(ID, nome, descricao, preco, imagemURL, estoque, dataCadastro);
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public string ImagemURL { get; private set; }
    public int Estoque { get; private set; }
    public DateTime DataCadastro { get; private set; }


    public Categoria Categoria { get; set; }
    public int CategoriaID {  get; set; }

    public void Update(int id, string nome, string descricao, decimal preco, string imagemURL, 
        int estoque, DateTime dataCadastro, int categoriaID)
    {
        ValidateDomain(id, nome, descricao, preco, imagemURL, estoque, dataCadastro);
        CategoriaID = categoriaID;
    }
    private void ValidateDomain(int ID, string nome, string descricao, decimal preco, string imagemURL, int estoque, DateTime dataCadastro)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), 
            "Nome inválido.O nome é obrigatório!");

        DomainExceptionValidation.When(nome.Length < 3, 
            "O nome deve ter, no mínimo, 3 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
            "Descrição inválida. A descrição é obrigatória!");

        DomainExceptionValidation.When(descricao.Length < 5,
            "A descrição deve ter no mínimo 5 caracteres!");

        DomainExceptionValidation.When(preco < 0, "Valor do preço inválido!");

        DomainExceptionValidation.When(imagemURL?.Length > 250, 
            "O nome da imagem não pode exceder 250 caracteres");

        DomainExceptionValidation.When(estoque < 0, "Estoque inválido!");
        this.ID = ID;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        ImagemURL = imagemURL;
        Estoque = estoque;
        DataCadastro = dataCadastro;
    }
}