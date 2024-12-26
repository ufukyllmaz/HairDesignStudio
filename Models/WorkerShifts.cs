using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairDesignStudio.Models
{
    public class WorkerShifts
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
        [Display(Name = "Çalışan İşe Başlama Saati")]
        public DateTime WorkStartTime { get; set; }
        [Display(Name = "Çalışan İşten Çıkış Saati")]
        public DateTime WorkEndTime { get; set; }
        public Workers? workers { get; set; }
    }
}