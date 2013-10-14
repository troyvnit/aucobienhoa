using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TroyLeeMVCEF.Models
{
    public class BookingModel
    {
       

        public BookingModel(BookingViewModel model)
        {
            // TODO: Complete member initialization
            DoctorId = model.doctorid;
            BookedDate = string.Format("{0}/{1}/{2}", model.year, model.month, model.day);
            BookekTime = model.timeid;
            FullName = model.name;
            Phone = model.phone;
            Address = model.address;
            DOB = model.birthday;
            Note = model.question;
            Email = model.email;
            
        }
        public string DoctorId { get; set; }
        public string BookedDate { get; set; }
        public string BookekTime { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string Note { get; set; }

    }

}