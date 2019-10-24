using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;
using RestaurantLibrary;

namespace ASP.NET_Restaurang.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, 
                         IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        //OnGet svarar på get-request. Presents form to user. När du öppnar sidan.
        public IActionResult OnGet(int? restaurantId)
        {
            //Kopplar enum-list till Cuisine
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
            } 
            else
            {
                Restaurant = new Restaurant();
            }
           
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        //OnPost respond to post.Take form info and saves to datasource.

        public IActionResult OnPost() //
        {
            
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();

            }

            if (Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
               
            }
            else
            {
                restaurantData.Add(Restaurant);
            }
            restaurantData.Commit();
            //temporär data som kan skickas och plockas upp nästa GET på annan sida
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });

        }

    }
}