﻿using Microsoft.EntityFrameworkCore;
using Users.API.Commands.CreateUser;
using Users.API.Models.Database;
using Users.API.Models.Entities;

namespace Users.API.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UsersContext _context;

    public UsersRepository(UsersContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsersAsync(CancellationToken ct)
    {
        return await _context.Users
            .Include(x => x.Role)
            .ToListAsync(ct);
    }

    public async Task<User> AddUserAsync(User user, CancellationToken ct)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}
