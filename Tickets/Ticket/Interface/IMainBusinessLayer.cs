using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.BusinessLayer;
using Ticket.Interface;

namespace Ticket.Interface
{
    public interface IMainBusinessLayer
    {
        List<AdoNET> FetchTickets(Func<AdoNET, bool> filter = null);
    }
}
