using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfTournament.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        /// <summary>
        /// Name of the course
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Total Par for whole course
        /// </summary>
        [Required]
        public int Par { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZIP { get; set; }

        public List<Holes> Holes { get; set; }
    }
}
