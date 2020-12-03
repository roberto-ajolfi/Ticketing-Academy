using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core.Mock.Repository
{
    public class MockNoteRepository : INoteRepository
    {
        #region Mock Data

        private List<Note> _notes = new List<Note>
        {
            new Note
            {
                Id = 1,
                Comments = "Prima Nota"
            },
            new Note
            {
                Id = 2,
                Comments = "Seconda Nota"
            }
        };

        #endregion
        public bool Add(Note item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> Get(Func<Note, bool> filter = null)
        {
            return _notes;
        }

        public Note GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Note item)
        {
            throw new NotImplementedException();
        }
    }
}
