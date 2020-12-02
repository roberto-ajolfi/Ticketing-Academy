using System;
using System.Collections.Generic;

namespace Ticketing.Client.Model
{
    public class Ticket
    {
        //public Ticket()
        //{
        //    Notes = new List<Note>();
        //}

        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requestor { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string State { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual List<Note> Notes { get; set; }
    }
}
