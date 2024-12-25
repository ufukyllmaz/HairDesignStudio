using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HairDesginStudio.Models
{
    public class Workers
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
        [Phone]
        [Display(Name = "Çalışan Telefon Numarası")]
        public string WorkerPhoneNumber { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Çalışan adresi 150 karakterden fazla olamaz.")]
        [Display(Name = "Çalışan Adresi")]
        public string WorkerAddress { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Çalışan E-mail Adresi")]
        public string WorkerEMail { get; set; }
        [Required]
        [Display(Name = "Çalışan İşe Başlama Tarihi")]
        public DateOnly WorkerStartDate { get; set; }

        public ICollection<WorkerOperations> ?workerOperations { get; set; }
        public ICollection<Reservations> ?reservations { get; set; }
    }
}