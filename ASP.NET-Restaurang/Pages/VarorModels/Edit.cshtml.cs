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
    public class EditModel : PageModel
    {
        private readonly IVarorData varorData;

        [BindProperty]
        public VarorModel VarorModel { get; set; }
        public IEnumerable<VarorModel> Varor;

        public EditModel(IVarorData varorData)
        {
            this.varorData = varorData;
        }
        public IActionResult OnGet(int? varorId)
        {
            if (varorId.HasValue)
            {
                VarorModel = varorData.GetById(varorId.Value);
            }
            else
            {
                VarorModel = new VarorModel();
            }
            if (VarorModel == null)
            {
               return  RedirectToPage("./NotFound");
            }
           return Page();
        }

        public IActionResult OnPost()
        {
            Varor = varorData.GetVaraByName();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (VarorModel.Id > 0)
            {
                varorData.Update(VarorModel);
            }
            else
            {
                //for (int i = 0; i < Varor.Max(x => x.Id) + 1; i++)
                //{
                //    if (VarorModel.Name == Varor.ElementAt(i).Name)
                //    {
                //        VarorModel.Id = Varor.ElementAt(i).Id;
                //        varorData.Update(VarorModel);
                //    }
                //}
                
                varorData.Add(VarorModel);
            }
            varorData.Commit();
            return RedirectToPage("./List");
            
        }
    }
}