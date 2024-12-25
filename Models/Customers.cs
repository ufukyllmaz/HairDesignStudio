using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairDesginStudio.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Çalışan ismi 50 karakterden fazla olamaz.")]
        [Display(Name = "Müşteri İsmi")]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Çalışan ismi 50 karakterden fazla olamaz.")]
        [Display(Name = "Müşteri Soyismi")]
        public string CustomerSurname { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Müşteri Telefon Numarası")]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Müşteri E-mail Adresi")]
        public string CustomerEMail { get; set; }

    }
}