using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RLL;
using Shopping.Models;
using BLL;

namespace Shopping.BLL
{
    public class UserDi : IUserDi
    {

        private readonly RStore _context;
        public UserDi(RStore context)
        {
            this._context = context;
        }
        public async Task<bool> CreateUserAsync(User user)
        {

            await _context.Users.AddAsync(user);

            try
            {

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"There Was a problem upday=ting {ex.InnerException}");

                return false;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"There Was a problem upday=ting {ex.InnerException}");

                return false;
                //throw new Exception("Exeption Thrown");
            }


            return true;
        }


        public async Task<List<User>> UserListAsync()
        {
            List<User> ps = null;
            try
            {
                ps = _context.Users.ToList();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"There was a problem gettign the players list => {ex.InnerException}");
            }
            return ps;
        }
    }
}
