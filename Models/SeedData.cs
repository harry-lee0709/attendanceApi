using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMonitor.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AttendanceMonitorContext(
                serviceProvider.GetRequiredService<DbContextOptions<AttendanceMonitorContext>>()))
            {
                // Look for any movies.
                if (context.AttendanceItem.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.AttendanceItem.AddRange(
                    new AttendanceItem
                    {
                        Id = 1,
                        Company = "Datacom",
                        Department = "Mobile",
                        FirstName = "Andy",
                        LastName = "Park",
                        Phone = "091234567",
                        TimeArrived = "19/11/18 12:55:40 PM",
                        Note = "On holiday from next week"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}