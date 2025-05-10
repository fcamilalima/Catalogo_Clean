using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;

namespace Catalogo.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<CategoriaDTO>> GetCategorias()
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
