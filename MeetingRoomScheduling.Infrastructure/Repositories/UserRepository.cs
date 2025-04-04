﻿using MeetingRoomScheduling.Domain.Entities;
using MeetingRoomScheduling.Domain.Interfaces;
using MeetingRoomScheduling.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomScheduling.Infrastructure.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users
                .Where(user => user.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return false;

            // TODO: Implementar verificação de senha também.
            return true;
        }
    }
}
