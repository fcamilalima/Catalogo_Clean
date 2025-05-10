using Catalogo.Application.DTOs;

namespace Catalogo.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    Task<CategoriaDTO> GetById(int id);
    Task Add(CategoriaDTO categoriaDTO);
    Task Update(CategoriaDTO categoriaDTO);
    Task Remove(int? id);
}
