using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SpisRozmowTelefonicznych.ViewModels
{
    public class LoginViewModels
    {
        [Required(ErrorMessage  = "Musisz wprowadzić nazwę użytkownika!")]
        public String e_mail { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło!")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public String password { get; set; }

        [Display(Name ="Zapamiętaj mnie!")]
        public bool rememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]       
        public string Email { get; set; }

        [Required]
        
        [DataType(DataType.Password)]
        [Display(Name = " Hasło ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdz Hasło ")]
        [Compare("Password", ErrorMessage = "Hasło i potwierdzenie hasła nie pasują do siebie.")]
        public string ConfirmPassword { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}