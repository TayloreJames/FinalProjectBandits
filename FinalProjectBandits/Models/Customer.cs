using Microsoft.AspNetCore.Identity;
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
       // public int Task { get; set; }
        public string Email { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int Phone { get; set; }

        public double MuapIndex { get; set; }

        public string Password { get; set; }
        //public string Skill1 { get; set; }
        //public string Skill2 { get; set; }
        //public string Skill3 { get; set; }

        // this is what Cory helped with to define the key relationships in ApplicationDbContext
        //public string Email { get; set; }

        public List<TaskListItem> Items { get; set; }

        public IdentityUser User { get; set; }

        //how do we relate now to the MedicallyUnderservedArea field we need: MUAPIndex
    }
}
