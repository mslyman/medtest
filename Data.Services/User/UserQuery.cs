using AutoMapper;
using Data.Interfaces;
using DBModel;
using Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class UserQuery: IUserQuery
    {
        private readonly MainDbContext _db;
        private readonly IMapper _mapper;

        public UserQuery(MainDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(Guid userId)
        {
            var entity = await _db.User.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId && !x.IsDeleted);

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetListAsync()
        {
            var user = await _db.User.AsNoTracking()
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserDto>>(user);
        }


    }
}
