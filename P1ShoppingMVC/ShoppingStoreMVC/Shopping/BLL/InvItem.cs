using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RLL;
using Shopping.Models;
using BLL;

namespace BLL
{
    public class InvItem : IInvItem
    {
        private readonly RStore _context;
        public InvItem(RStore context)
        {
            this._context = context;
        }
        public async Task<bool> CreateInvAsync(Inventory inv)
        {
            
            await _context.inventory.AddAsync(inv);

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


        public async Task<List<Inventory>> InvListAsync()
        {
            List<Inventory> ps = null;
            try
            {
                ps = _context.inventory.ToList();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"There was a problem gettign the players list => {ex.InnerException}");
            }
            return ps;
        }
    }
}
