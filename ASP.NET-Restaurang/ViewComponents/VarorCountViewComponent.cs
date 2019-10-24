using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Restaurang.ViewComponents
{
    public class VarorCountViewComponent : ViewComponent
    {
        private readonly IVarorData varorData;

        public VarorCountViewComponent(IVarorData varorData)
        {
            this.varorData = varorData;
        }

        public IViewComponentResult Invoke()
        {
            var count = varorData.GetCountofVaror();
            return View(count);
          
        }
    }
}
