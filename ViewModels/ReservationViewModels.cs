using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairDesginStudio.Models;

namespace HairDesginStudio.ViewModels
{
    public class ServiceSelectionViewModel
    {
        public DateTime SelectedDate { get; set; }
        public List<Operations> Operations { get; set; }
        public List<Workers> Workers { get; set; }
    }

    public class TimeViewModel
    {
        public TimeSpan Time { get; set; }
        public string DisplayTime { get; set; }
        public bool IsAvailable { get; set; }
        public Reservations ExistingReservation { get; set; }
    }

    public class TimeSelectionViewModel
    {
        public DateTime SelectedDate { get; set; }
        public int WorkerId { get; set; }
        public int OperationId { get; set; }
        public Workers Worker { get; set; }
        public Operations Operation { get; set; }
        public List<TimeViewModel> AvailableSlots { get; set; }
        public List<TimeViewModel> AllTimeSlots { get; set; }
        public TimeSpan SelectedTime { get; set; }
    }
    public class HairStyleViewModel
    {
        public List<string> GeneratedStyles { get; set; } = new List<string>();
        public string ErrorMessage { get; set; }
        public string InfoMessage { get; set; }
        public bool IsLoading { get; set; }
    }
}