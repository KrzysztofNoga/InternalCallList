using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SpisRozmowTelefonicznych.DAL;
using System.Web.Mvc;
using System.ComponentModel;

namespace SpisRozmowTelefonicznych.ViewModels
{  
       
    public class FormularzViewModel
    {
       
       


        [Required(ErrorMessage ="Musisz wprowadzić numer telefonu z którego odberałeś połączenie")]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string PHONE_NUMBER { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzić numer telefonu z którego połączenie przyszło")]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string PHONE_NUMBER_CALLER { get; set; }
        [Required(ErrorMessage = "Wprowadź datę połączenia")]
        [DefaultValue("01/01/2000")]
        public DateTime Date { get; set; }
        public string AdresseeID { get; set; }
        public string NameCaller { get; set; }
        public string LastNaemCaller { get; set; }
        [Required(ErrorMessage = "Wprowadź opis rozmowy")]
        public string Description { get; set; }
        public bool czydoUzytkownika { get; set; }
        //public IEnumerable<SelectListItem> Telefony { get; set; }
        public string SelectedDoKogo { get; set; }
        public IEnumerable<SelectListItem> DoKogo { get; set; }
        //public SelectList Phones { get; set; }
        public int SelectedTelefon { get; set; }
        public IEnumerable<SelectListItem> TelefonyUsera { get; set; }


      

    }
}