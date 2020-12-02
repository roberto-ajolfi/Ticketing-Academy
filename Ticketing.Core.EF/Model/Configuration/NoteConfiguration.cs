using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;

namespace Ticketing.Client.Model.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Comments)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .HasOne(n => n.Ticket)
                .WithMany(t => t.Notes)
                .HasConstraintName("FK_Ticket_Notes");

            builder
                .Property(n => n.RowVersion)
                .IsRowVersion();
        }
    }
}
