using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Elex.Instances
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Secondname { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
