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
            try
            {
                var categorias = await _repository.GetCategoriasAsync();
                var categoriasDTO = categorias.ToCategoriaDTOList();
                return categoriasDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CategoriaDTO> GetById(int id)
        {
            var categoria = await _repository.GetByIDAsync(id);
            return categoria?.ToCategoriaDTO();

        }

        public async Task Add(CategoriaDTO categoriaDTO)
        {
            var categoria = categoriaDTO.ToCategoria();
            _ = await _repository.CreateAsync(categoria);
        }
        public async Task Update(CategoriaDTO categoriaDTO)
        {
            var categoria = categoriaDTO.ToCategoria();
            _ = await _repository.UpdateAsync(categoria);
        }
        public async Task Remove(int? id)
        {
            var categoria = await _repository.GetByIDAsync(id);
            _ = _repository.RemoveAsync(categoria);
        }
    }
}
