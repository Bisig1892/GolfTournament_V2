using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfTournament.Models
{
    public class Tournaments
    {
        [Key]
        public int TournamentId { get; set; }
        /// <summary>
        /// The name of the tournament taking place.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Date the tournament is being played 
        /// </summary>
        [Required]
        public DateTime ScheduledDate { get; set; }
        /// <summary>
        /// flights are the number of leaderboards the main tournament will be broken down into
        /// </summary>
        public int Flights { get; set; }
        /// <summary>
        /// The course being played
        /// </summary>
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Courses Course { get; set; }
    }
}
