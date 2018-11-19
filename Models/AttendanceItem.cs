using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMonitor.Models
{
    public class AttendanceItem
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string TimeArrived { get; set; }
        public string Note { get; set; }
    }
}