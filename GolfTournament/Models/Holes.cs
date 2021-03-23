using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfTournament.Models
{
    public class Holes
    {
        [Key]
        public int HoleId { get; set; }
        /// <summary>
        /// number of hole on the golf course
        /// </summary>
        [Required]
        public int Number { get; set; }
        [Required]
        public int Par { get; set; }
        /// <summary>
        /// Difficulty of hole on the course. hardest = 1, easiest = 18
        /// Handicaps will be used to determine tiebreakers
        /// </summary>
        [Required]
        public int Handicap { get; set; }

        public int CourseId { get; set; }
        public virtual Courses Course { get; set; }
    }
}
