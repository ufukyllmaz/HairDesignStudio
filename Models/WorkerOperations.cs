using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HairDesignStudio.Models
{
    public class WorkerOperations
    {
        public int WorkerId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Çalışan ismi 50 karakterden fazla olamaz.")]
        [Display(Name = "Çalışan İsmi")]
        public string WorkerName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Çalışan ismi 50 karakterden fazla olamaz.")]
        [Display(Name = "Çalışan Soyismi")]
        public string WorkerSurname { get; set; }
        [Required]
        [Display(Name = "Çalışan Yetkinlikleri")]
        public List<string> WorkerHasOperations { get; set; } = new List<string>();

        public Workers? workers { get; set; }
    }
}