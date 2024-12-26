using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairDesignStudio.Models
{
    public class Reservations
    {
        public int ReservationId { get; set; }
        
        [Required]
        public int WorkerId { get; set; }
        public Workers Worker { get; set; }
        
        [Required]
        public int OperationId { get; set; }
        public Operations Operation { get; set; }
        
        [Required]
        public DateTime ReservationDate { get; set; }
        
        [Required]
        public TimeSpan ReservationTime { get; set; }
        
        public string UserId { get; set; }
        public AdvanceUser User { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }

}