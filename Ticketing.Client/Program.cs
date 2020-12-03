using System;
using Ticketing.Core.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Ticketing.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();

            Console.WriteLine("=== Ticket Management ===");
            bool quit = false;

            do
            {
                #region Main Loop
                Console.Write("Comando: ");
                string command = Console.ReadLine();
                Console.WriteLine();

                switch(command)
                {
                    case "h":
                        Console.WriteLine("Help");
                        Console.WriteLine("q: quit | a: add ticket");
                        Console.WriteLine("n: add note | l: list ticket");
                        Console.WriteLine("e: edit ticket");
                        break;
                    case "q":
                        quit = true;
                        break;
                    case "a":
                        // ADD
                        // codice per recuperare i dati di un ticket ...
                        Ticket ticket = new Ticket();
                        ticket.Title = GetData("Titolo");
                        ticket.Description = GetData("Descrizione");
                        ticket.Category = GetData("Categoria");
                        ticket.Priority = GetData("Priorità");
                        ticket.Requestor = "Roberto Ajolfi";
                        ticket.State = "New";
                        ticket.IssueDate = DateTime.Now;
                        
                        var result = dataService.Add(ticket);
                        Console.WriteLine("Operation " + ( result ? "Completed" : "Failed!" ));
                        break;
                    case "n":
                        // ADD NOTE
                        var ticketId = GetData("Ticket ID");
                        int.TryParse(ticketId, out int tId);
                        var comments = GetData("Commento");
                        Note newNote = new Note { 
                            TicketId = tId,
                            Comments = comments
                        };

                        var noteResult = dataService.AddNote(newNote);
                        Console.WriteLine("Operation " + (noteResult ? "Completed" : "Failed!"));
                        break;
                    case "l":
                        // LIST
                        Console.WriteLine("-- TICKET LIST (EAGER) --");
                        foreach (var t in dataService.List())
                        {
                            Console.WriteLine($"[{t.Id}] {t.Title}");
                            if(t.Notes != null)
                                foreach(var n in t.Notes)
                                    Console.WriteLine($"\t{n.Comments}");
                        }
                        Console.WriteLine("-----------------");
                        break;
                    case "e":
                        // EDIT
                        var ticketId3 = GetData("Ticket ID");
                        int.TryParse(ticketId3, out int tId3);
                        var ticket3 = dataService.GetTicketById(tId3);

                        ticket3.Title = GetData("Title", ticket3.Title);
                        ticket3.Description = GetData("Descrizione", ticket3.Description);
                        ticket3.Category = GetData("Categoria", ticket3.Category);
                        ticket3.Priority = GetData("Priorità", ticket3.Priority);
                        ticket3.State = GetData("Stato", ticket3.State);

                        var editResult = dataService.Edit(ticket3);
                        Console.WriteLine("Operation " + (editResult ? "Completed" : "Failed!"));
                        break;
                    case "d":
                        // DELETE
                        break;
                    default:
                        Console.WriteLine("Comando sconosciuto.");
                        break;
                }

                #endregion

            } while (!quit);

            Console.WriteLine("=== Bye Bye ===");

        }

        private static string GetData(string message)
        {
            Console.Write(message + ": ");
            var value = Console.ReadLine();
            return value;
        }

        private static string GetData(string message, string initialValue)
        {
            Console.Write(message + $" ({initialValue}): ");
            var value = Console.ReadLine();
            return string.IsNullOrEmpty(value) ? initialValue : value;
        }
    }
}
