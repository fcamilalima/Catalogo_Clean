using Catalogo.Domain.Entities;

namespace Catalogo.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Categoria>> GetCategoriasAsync();
    Task<Categoria> GetByIDAsync(int? id);
    Task<Categoria> CreateAsync(Categoria categoria);
    Task<Categoria> UpdateAsync(Categoria categoria);
    Task<Categoria> RemoveAsync(Categoria categoria);
}
