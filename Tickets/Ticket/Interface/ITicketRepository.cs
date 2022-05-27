using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Interface
{
    public interface ITicketRepository : IRepository<AdoNET>
    {
        AdoNET GetByTicketCode(string ticketCode);
        List<AdoNET> Fetch(Func<AdoNET, bool> filter);
    }
}
