using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.data
{
    public class BookingContext : DbContext
    {

        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {

        }

        public DbSet<Bedroom> Bedrooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Hotel> Hotels { get; set; }


    }
}
