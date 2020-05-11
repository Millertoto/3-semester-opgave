using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class FlightDBContext: DbContext
    {
        public FlightDBContext(DbContextOptions<FlightDBContext> options)
            :base(options)
        {

        }

        public DbSet<FlightDBContext> flightItem
        {
            get;
            set;
        }


    }
}
