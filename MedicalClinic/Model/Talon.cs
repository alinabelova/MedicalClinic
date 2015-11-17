using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace MedicalClinic.Model
{
    public class Talon:DomainObject
    {
        [Required]
        public DateTime DateStart { get; set; }
        //[Required]
        //public DateTime DateEnd { get; set; }

      //  
       public int DoctorId { get; set; }
   //     public int ServiceId { get; set; }

      //  public List<DateTime> DateTime { get; set; }

        public Client Client { get; set; }
        public Service Service{ get; set; }
        public Doctor Doctor { get; set; }
        public int ClientsId { get; set; }
      //  public Employee Employee { get; set; }
    }
}
