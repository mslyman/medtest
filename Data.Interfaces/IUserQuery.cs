using Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserQuery
    {
        Task<IEnumerable<UserDto>> GetListAsync();
        Task<UserDto> GetAsync(Guid userId);
    }
}
