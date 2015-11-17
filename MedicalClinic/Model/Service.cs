using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace MedicalClinic.Model
{
    public class Service:NamedDomainObject
    {
        public int Price { get; set; }
    }
}
