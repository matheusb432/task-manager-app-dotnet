﻿using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TaskManagerContext context) : base(context) { }

        public override IQueryable<User> Query() =>
            _dbSet.AsQueryable().Where(x => _isAdmin || x.Id == _userId).AsSplitQuery();

        private IQueryable<User> BaseQuery() => _dbSet.AsQueryable().AsSplitQuery();

        private IQueryable<User> QueryWithRoles() =>
            BaseQuery().Include(x => x.UserRoles).ThenInclude(x => x.Role);

        public async Task<User?> GetByEmailAsync(string email) =>
            await QueryWithRoles().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

        public async Task<User?> GetByUserNameAsync(string userName) =>
            await QueryWithRoles()
                .FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());

        public async Task<bool> CanCreateUser(User user)
        {
            var emailExists = await BaseQuery()
                .AnyAsync(x => x.Email.ToLower() == user.Email.ToLower());
            var userNameExists = await BaseQuery()
                .AnyAsync(x => x.UserName.ToLower() == user.UserName.ToLower());

            return !emailExists && !userNameExists;
        }

        public async Task<bool> EmailExists(string email) =>
            await BaseQuery().AnyAsync(x => x.Email.ToLower() == email.ToLower());

        public async Task<bool> UserNameExists(string userName) =>
            await BaseQuery().AnyAsync(x => x.UserName.ToLower() == userName.ToLower());

        public override async Task SaveChangesAsync()
        {
            await _context.SaveChangesWithoutUserTrackingAsync();
        }
    }
}
