using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfTournament.Models
{
    public class IndividualCompetions
    {
        /// <summary>
        /// This is for hole prizes and competitions that are part of the tournament but are not based on the teams overall score. (Longest drive, chipping comp, closest to pin on second shot. etc.)
        /// </summary>
        [Key]
        public int IndividualCompetionsId { get; set; }
        /// <summary>
        /// First name of the winner of the competion
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the winner of the competion
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The description of the competition and where it took place.
        /// Example: 1st hole - Longest drive(seniors)
        /// Example: Practice chipping green - chipping competion
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Amount player won for competition
        /// </summary>
        [DataType(DataType.Currency)]
        public int PrizeMoney { get; set; }
    }
}
