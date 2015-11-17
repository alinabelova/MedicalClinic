using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace MedicalClinic.Model
{
    public class Doctor:FullNamedDomainObject
    {
        [Required]
        public string Speciality { get; set; }
        [Required]
        public int Cabinet { get; set; }
        [Required]
        public string WorkHours { get; set; }
        [Required]
        public int Cost  { get; set; }
        [Required]
        public ICollection<Talon> Talons { get; set; } 
    }
}
