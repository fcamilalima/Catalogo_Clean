using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Application.Mappings;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            throw new NotImplementedException();
        }
        public Task<CategoriaDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task Add(CategoriaDTO categoriaDTO)
        {
            throw new NotImplementedException();
        }
        public Task Update(CategoriaDTO categoriaDTO)
        {
            throw new NotImplementedException();
        }
        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
