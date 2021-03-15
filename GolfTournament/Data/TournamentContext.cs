using GolfTournament.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolfTournament.Data
{
    public class TournamentContext : IdentityDbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options)
            : base(options)
        {
        }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Holes> Holes { get; set; }
        public DbSet<IndividualCompetions> IndividualCompetions { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Sponsors> Sponsors { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Tournaments> Tournaments { get; set; }
    }
}
