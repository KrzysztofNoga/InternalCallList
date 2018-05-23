using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpisRozmowTelefonicznych.DAL
{
    public class UserData
    {   /*[Key]*/
        public int id_userData { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }


        //public  virtual ICollection<Phone> Phones { get; set; }
        //public virtual  ICollection<Call> Calls { get; set; }



    }
}