using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DBModel;
using System.Data;
using System.Threading.Tasks;
using Data.Interfaces;
using Dto;
using System;

namespace Data.Services
{
    public class UserCommand: IUserCommand
    {
        private readonly MainDbContext _db;
        private readonly IMapper _mapper;
        private readonly IUserQuery _userQuery;

        public UserCommand(MainDbContext db, IMapper mapper, IUserQuery userQuery)
        {
            _db = db;
            _mapper = mapper;
            _userQuery = userQuery;
        }

        public async Task AddAsync(UserDto user)
        {
            _db.User.Add(_mapper.Map<User>(user));
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserDto user)
        {
            var entry = _mapper.Map<User>(user);
            _db.User.Update(entry);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid userId)
        {
            var dto = await _userQuery.GetAsync(userId);

            if (dto != null)
            {
                var entry = _mapper.Map<User>(dto);
                entry.IsDeleted = true;
                _db.User.Attach(entry);
                _db.Entry(entry).Property(x => x.IsDeleted).IsModified = true;
                await _db.SaveChangesAsync();
            }
        }
    }
}
