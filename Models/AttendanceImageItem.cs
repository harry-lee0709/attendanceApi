using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMonitor.Models
{
    public class AttendanceImageItem
    {
        public string LastName { get; set; }
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}