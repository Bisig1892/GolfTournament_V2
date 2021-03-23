using GolfTournament.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfTournament.ViewModels
{
    public class AddTournamentViewModel
    {
        public Tournaments Tournaments { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
    }
}
