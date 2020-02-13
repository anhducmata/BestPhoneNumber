using BestPhoneNumber.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestPhoneNumber.Context
{
    public class PhoneContext : DbContext
    {
        public DbSet<TelecomHost> TelecomHost { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-UB2DQ71;Initial Catalog=master;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelecomHost>().HasData(
                new TelecomHost()
                {
                    Name = "Viettel",
                    Id = 1
                },
                new TelecomHost()
                {
                    Name = "Mobi",
                    Id = 2
                },
                new TelecomHost()
                {
                    Name = "VinaPhone",
                    Id = 3
                }
            );

            modelBuilder.Entity<NumberProvide>().HasData(
                // Viettel prefix
                new NumberProvide()
                {
                    Id = 1,
                    TelecomHostId = 1,
                    PrefixNumber = "086"
                },
                new NumberProvide()
                {
                    Id = 2,
                    TelecomHostId = 1,
                    PrefixNumber = "096"
                },
                new NumberProvide()
                {
                    Id = 3,
                    TelecomHostId = 1,
                    PrefixNumber = "097"
                },

                // Mobi Prefix
                new NumberProvide()
                {
                    Id = 4,
                    TelecomHostId = 2,
                    PrefixNumber = "089"
                },
                new NumberProvide()
                {
                    Id = 5,
                    TelecomHostId = 2,
                    PrefixNumber = "090"
                },
                new NumberProvide()
                {
                    Id = 6,
                    TelecomHostId = 2,
                    PrefixNumber = "093"
                },

                // VinaPhone Prefix
                new NumberProvide()
                {
                    Id = 7,
                    TelecomHostId = 3,
                    PrefixNumber = "088"
                },
                new NumberProvide()
                {
                    Id = 8,
                    TelecomHostId = 3,
                    PrefixNumber = "091"
                },
                new NumberProvide()
                {
                    Id = 9,
                    TelecomHostId = 3,
                    PrefixNumber = "094"
                }
            );
        }
    }
}
