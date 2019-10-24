using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using RestaurantLibrary;

namespace ASP.NET_Restaurang.Pages.VarorModels
{
    public class DetailModel : PageModel
    {
        private readonly IVarorData varorData;

        public VarorModel VarorModel { get; set; }

        public DetailModel(IVarorData varorData)
        {
            this.varorData = varorData;
        }

        public IActionResult OnGet(int varorId)
        {
            VarorModel = varorData.GetById(varorId);
            //VarorModel = new VarorModel();
            //VarorModel.Id = varorId;
            if (VarorModel == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();


        }
    }
}