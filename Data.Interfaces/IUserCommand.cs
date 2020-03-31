using Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserCommand
    {
        Task AddAsync(UserDto user);
        Task RemoveAsync(Guid userId);
        Task UpdateAsync(UserDto user);
    }
}
