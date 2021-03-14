using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfTournament.Models
{
    public class Sponsors
    {
        [Key]
        public int SponsorsId { get; set; }
        /// <summary>
        /// Name of person or business who sponsored the event.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Tournament that is being sponsored
        /// </summary>
        [Required]
        public Tournaments Tournament { get; set; }
    }
}
