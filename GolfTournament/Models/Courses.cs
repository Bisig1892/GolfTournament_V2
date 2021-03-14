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
        public string Name { get; set; }
        /// <summary>
        /// Total Par for whole course
        /// </summary>
        public int Par { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZIP { get; set; }

        public List<Holes> Holes { get; set; }
    }
}
