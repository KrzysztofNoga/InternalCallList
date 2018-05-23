using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpisRozmowTelefonicznych.DAL;

namespace SpisRozmowTelefonicznych.DAL
{
    public class Call
    {
        [Key]
        public int id_call { get; set; }
        [ForeignKey("Phone")]
        public int id_phone { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public string caller_number { get; set; }
        
        public DateTime date { get; set; }
        public string adresseID { get; set; }
        
        public string callerName { get; set; }
        public string callerLastName { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public DateTime dataDodania { get; set; }

        public virtual Phone Phone { get; set; }
        //public virtual UserData User { get; set; }
    }
}