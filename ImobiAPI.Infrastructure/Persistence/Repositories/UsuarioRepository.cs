using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImobiAPI.Infrastructure.Persistence.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterPorGoogleIdAsync(string googleId)
    {
        return await _context.Usuarios
            .Include(u => u.ApiKeys)
            .FirstOrDefaultAsync(u => u.GoogleId == googleId);
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _context.Usuarios
            .Include(u => u.ApiKeys)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Usuario?> ObterPorIdAsync(int id)
    {
        return await _context.Usuarios
            .Include(u => u.ApiKeys)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }
}