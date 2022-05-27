using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.BusinessLayer;
using Ticket.Interface;

namespace Ticket.BusinessLayer
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly ITicketRepository _ticketRepo;

        // DEPENDENCY INJECTION
        public MainBusinessLayer(
            ITicketRepository empRepo
        )
        {
            _ticketRepo = empRepo;
        }

        public List<AdoNET> FetchTickets(Func<AdoNET, bool> filter = null)
        {
            return _ticketRepo.Fetch(filter);
        }
    }
}
