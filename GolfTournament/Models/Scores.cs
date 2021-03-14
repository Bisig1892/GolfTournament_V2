using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfTournament.Models
{
    public class Scores
    {
        [Key]
        public int ScoreId { get; set; }
        [Required]
        public int Score { get; set; }
        /// <summary>
        /// Team the score is for on the paticular hole
        /// </summary>
        [Required]
        public Teams Teams { get; set; }
        /// <summary>
        /// Hole in which the score was made
        /// </summary>
        [Required]
        public Holes Hole { get; set; }
    }
}
