using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Details
    {
        [Key]
        public long DoctorDetailsID { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public long UID { get; set; }
        public DateTime DateofBirth { get; set; }
        public string HospitalName { get; set; }
        public long MobileNumber { get; set; }
    }
}
