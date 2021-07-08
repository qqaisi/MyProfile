using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Models;

namespace BLL
{
    public interface IInvItem
    {
        Task<bool> CreateInvAsync(Inventory inv);
        Task<List<Inventory>> InvListAsync();
    }
}
