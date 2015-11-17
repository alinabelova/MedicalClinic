using System;
using System.ComponentModel.DataAnnotations;
using Mita.DataAccess;

namespace MedicalClinic.Model
{
    public class Client:FullNamedDomainObject
    {
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Pasport { get; set; }
        [Required]
        public string Policy { get; set; }
        [Required]
        public string Disease{ get; set; }
    }
}
