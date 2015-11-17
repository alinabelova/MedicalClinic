using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalClinic.Model;

namespace MedicalClinic
{
    public class Db : DbContext
    {
        public Db() : base("MedicalClinicDb") { }

        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Doctor> Doctors { get; set; }
        public IDbSet<Service> Services { get; set; }
        public IDbSet<Talon> Talons { get; set; }
       // public IDbSet<TalonAmount> TalonAmounts{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

         //   modelBuilder.Entity<Employee>().H
        }
    }
}
