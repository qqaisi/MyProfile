using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Models;

namespace BLL
{
    public interface IUserDi
    {
        Task<bool> CreateUserAsync(User user);
        Task<List<User>> UserListAsync();
    }
}
