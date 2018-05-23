using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpisRozmowTelefonicznych.DAL
{
    public class Phone
    {
        [Key]
        public int id_phone { get; set; }
        public string User_Id { get; set; }
        public virtual ApplicationUser User { get; set; }



        public string phone_number { get; set; }
        public string room_number { get; set; }

        //public virtual UserData User { get; set; }
       
        public virtual ICollection<Call> Calls { get; set; }
        


    }
}