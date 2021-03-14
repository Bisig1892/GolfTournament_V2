using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfTournament.Models
{
    public class Tournaments
    {
        [Key]
        public int TournamentId { get; set; }
        /// <summary>
        /// Id of the course being played
        /// </summary>
        [Required]
        public Courses Course { get; set; }
        ///// <summary>
        ///// Date the tournament is being played 
        ///// </summary>
        [Required]
        public DateTime ScheduledDate { get; set; }
        /// <summary>
        /// flights are the number of leaderboards the main tournament will be broken down into
        /// </summary>
        public int Flights { get; set; }
    }
}
