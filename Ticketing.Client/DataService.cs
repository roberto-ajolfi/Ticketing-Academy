using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing.Core.EF.Repository;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Client
{
    public class DataService
    {
        #region Temp ... waiting for DI

        private ITicketRepository GetTicketRepository()
        {
            return new Ticketing.Core.EF.Repository.EFTicketRepository();
        }

        private INoteRepository GetNoteRepository()
        {
            return new Ticketing.Core.EF.Repository.EFNoteRepository();
        }

        #endregion

        public List<Ticket> List()
        {
            ITicketRepository repo = GetTicketRepository();

            return repo.Get().ToList();
        }

        public bool Add(Ticket ticket)
        {
            try
            {
                ITicketRepository repo = GetTicketRepository();

                if (ticket != null)
                {
                    var result = repo.Add(ticket);
                    return result;
                }
                else
                {
                    Console.WriteLine("Ticket non può essere nullo.");
                    return true;
                }
            } catch(Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }  
        }

        public bool AddNote(Note newNote)
        {
            try
            {
                INoteRepository repo = GetNoteRepository();

                if (newNote != null)
                {
                    repo.Add(newNote);
                }
                else
                    Console.WriteLine("Note non può essere nullo.");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }

        public Ticket GetTicketById(int id)
        {
            ITicketRepository repo = GetTicketRepository();

            if (id > 0)
                return repo.GetByID(id);

            return null;
        }

        public bool Edit(Ticket ticket)
        {
            try { 
                ITicketRepository repo = GetTicketRepository();

                if (ticket == null)
                    return false;

                Console.WriteLine("Smandrappa il Ticket e poi premi enter ...");
                Console.ReadKey();

                repo.Update(ticket);
                    
            }
            catch (Exception ex)
            {
                // ...
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            return true;
        }
    }
}