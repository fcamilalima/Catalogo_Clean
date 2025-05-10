using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infraestructure.Repositories;

public class CategoriaRepository : ICategoryRepository
{
    private ApplicationDbContext _context;

    public CategoriaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Categoria> CreateAsync(Categoria categoria)
    {
        _context.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> GetByIDAsync(int? id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
    {
        try
        {
            var categorias = await _context.Categorias.ToListAsync();
            return categorias;
        }
        catch (Exception ex) {
            throw;
        }
    }

    public async Task<Categoria> RemoveAsync(Categoria categoria)
    {
        _context.Remove(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> UpdateAsync(Categoria categoria)
    {
        _context.Update(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }
}
