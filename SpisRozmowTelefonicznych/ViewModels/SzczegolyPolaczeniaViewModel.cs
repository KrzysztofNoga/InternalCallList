using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpisRozmowTelefonicznych.DAL;

namespace SpisRozmowTelefonicznych.ViewModels
{
    public class SzczegolyPolaczeniaViewModel
    {
        public string Opis { get; set; }
        public string NumerAdresata  { get; set; }
        public string NumerDzwoniacego { get; set; }
        public string ImieDzwoniacego { get; set; }
        public string NazwiskoDzwoniacego { get; set; }
        public string ImieOdbierajacego { get; set; }
        public string NazwiskoOdbierajacego { get; set; }
        public DateTime DataPolaczeia { get; set; }
        public DateTime DataDodania { get; set; }
        public bool StatusSprawy { get; set; }
        public string NumerOdbierajacego { get; set; }
        public string StatusString { get; set; }
        public int callID { get; set; } 
    }
}