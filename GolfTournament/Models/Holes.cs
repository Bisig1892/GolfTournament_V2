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
        public int Number { get; set; }
        public int Par { get; set; }
        /// <summary>
        /// Difficulty of hole on the course. hardest = 1, easiest = 18
        /// </summary>
        public int Handicap { get; set; }

        public Courses Course { get; set; }
    }
}
