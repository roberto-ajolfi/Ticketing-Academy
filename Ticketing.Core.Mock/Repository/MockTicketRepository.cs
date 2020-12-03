using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core.Mock.Repository
{
    public class MockTicketRepository : ITicketRepository
    {
        #region Mock Data

        private List<Ticket> _tickets = new List<Ticket>
        {
            new Ticket { 
                Id = 1, 
                Title = "Mock Ticket 1", 
                Description = "Desc Mock 1",
                IssueDate = DateTime.Now,
                Category = "Systems",
                Priority = "Alta",
                State = "New"
            },
            new Ticket {
                Id = 2,
                Title = "Mock Ticket 2",
                Description = "Desc Mock 2",
                IssueDate = DateTime.Now,
                Category = "Dev",
                Priority = "Alta",
                State = "OnGoing"
            },
            new Ticket {
                Id = 3,
                Title = "Mock Ticket 3",
                Description = "Desc Mock 3",
                IssueDate = DateTime.Now,
                Category = "Dev",
                Priority = "Normale",
                State = "New"
            },
            new Ticket {
                Id = 4,
                Title = "Mock Ticket 4",
                Description = "Desc Mock 4",
                IssueDate = DateTime.Now,
                Category = "Systems",
                Priority = "Bassa",
                State = "Closed"
            }
        };

        #endregion

        public bool Add(Ticket item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Get(Func<Ticket, bool> filter = null)
        {
            return _tickets;
        }

        public Ticket GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
