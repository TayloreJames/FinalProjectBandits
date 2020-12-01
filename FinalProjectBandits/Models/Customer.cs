using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBandits.Models
{
    public class Customer
    {
        
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int Phone { get; set; }
    }
}
