using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class VarorModel
    {

        public static List<VarorModel> listOfVaror = new List<VarorModel>();

        public string Name { get; set; }
        public decimal Price { get; set; }


        public VarorModel(string namn, decimal pris)
        {
            Price = pris;
            Name = namn;
        }

        public VarorModel()
        {

        }


        public string Display
        {
            get { return string.Format("{0} - Pris: {1} kronor", Name, Price); }
        }

    }

}