using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core.BL
{
    public class DataService
    {
        private readonly ITicketRepository ticketRepo;
        private readonly INoteRepository noteRepo;

        public DataService(
            ITicketRepository ticketRepo, 
            INoteRepository noteRepo
        )
        {
            this.ticketRepo = ticketRepo;
            this.noteRepo = noteRepo;
        }

        #region Temp ... waiting for DI

        //private ITicketRepository GetTicketRepository()
        //{
        //    return null;
        //    //return new Ticketing.Core.ADONET.Repository.ADONETTicketRepository();
        //    //return new Ticketing.Core.EF.Repository.EFTicketRepository();
        //    //return new Ticketing.Core.Mock.Repository.MockTicketRepository();
        //}

        //private INoteRepository GetNoteRepository()
        //{
        //    return null;
        //    //return new Ticketing.Core.EF.Repository.EFNoteRepository();
        //    //return new Ticketing.Core.Mock.Repository.MockNoteRepository();
        //}

        #endregion

        public List<Ticket> List()
        {
            //ITicketRepository repo = GetTicketRepository();

            return ticketRepo.Get().ToList();
        }

        public bool Add(Ticket ticket)
        {
            try
            {
                //ITicketRepository repo = GetTicketRepository();

                if (ticket != null)
                {
                    var result = ticketRepo.Add(ticket);
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
                //INoteRepository repo = GetNoteRepository();

                if (newNote != null)
                {
                    noteRepo.Add(newNote);
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
            //ITicketRepository repo = GetTicketRepository();

            if (id > 0)
                return ticketRepo.GetByID(id);

            return null;
        }

        public bool Edit(Ticket ticket)
        {
            try { 
                //ITicketRepository repo = GetTicketRepository();

                if (ticket == null)
                    return false;

                Console.WriteLine("Smandrappa il Ticket e poi premi enter ...");
                Console.ReadKey();

                ticketRepo.Update(ticket);
                    
            }
            catch (Exception ex)
            {
                // ...
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}