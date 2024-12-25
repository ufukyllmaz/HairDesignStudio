using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairDesginStudio.Models
{
    public class Operations
    {
        
        public int OperationId { get; set; }
        [Required]
        [Display(Name = "İşlem İsmi")]
        public string OperationName { get; set; }
        [Required]
        [Display(Name = "İşlem Ücreti")]
        public double OperationPrice { get; set; }
        [Required]
        [Range(15, 120, ErrorMessage = "İşlem süresi 15 dakika ile 120 dakika arasında olmak zorundadır.")]
        [Display(Name = "İşlem Süresi")]
        public int OperationDuration { get; set; }

        public ICollection<Reservations> ?reservations { get; set; }
    }
}