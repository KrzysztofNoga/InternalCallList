using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpisRozmowTelefonicznych.DAL;
using PagedList;
using PagedList.Mvc;

namespace SpisRozmowTelefonicznych.ViewModels
{
    public class PagedListViewModel
    {
        public PagedList.IPagedList<Call> ListaPolaczen { get; set; }
    }
}