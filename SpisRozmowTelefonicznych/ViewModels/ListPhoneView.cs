using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpisRozmowTelefonicznych.ViewModels;
using SpisRozmowTelefonicznych.DAL;

using System.Web.Mvc;
namespace SpisRozmowTelefonicznych.ViewModels
{
    public class ListPhoneView
    {
        
         public IEnumerable<SelectListItem> Telefony { get; set; }
    }
}