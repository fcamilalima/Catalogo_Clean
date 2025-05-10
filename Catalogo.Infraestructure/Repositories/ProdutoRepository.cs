using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infraestructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> CreateAsync(Produto produto)
    {
        _context.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> GetByIDAsync(int? id)
    {
        return await _context.Produtos.Include(c => c.Categorias)
            .SingleOrDefaultAsync(p => p.ID == id);
    }

    public async Task<IEnumerable<Produto>> GetProdutosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> RemoveAsync(Produto produto)
    {
        _context.Remove(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> UpdateAsync(Produto produto)
    {
        _context.Update(produto);
        await _context.SaveChangesAsync();
        return produto;
    }
}
