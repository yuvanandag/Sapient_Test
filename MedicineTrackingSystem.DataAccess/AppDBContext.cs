using MedicineTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedicineTrackingSystem.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
           
        }
        public DbSet<MedicineAttribute> MedicineAttributes { get; set; }
    }
}
