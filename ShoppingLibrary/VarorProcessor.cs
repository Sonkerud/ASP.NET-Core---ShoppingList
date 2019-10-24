using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingLibrary
{
    public class VarorProcessor
    {

        public static void AddVara(List<VarorModel> list, string name, string price)
        {
            VarorModel model = new VarorModel(
                    name,
                    decimal.Parse(price)
                    );

            //Control if new Vara already exists. If it does - update price.
            var found = list.Any(x => x.Name.ToLower() == model.Name.ToLower());

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.ToLower() == model.Name.ToLower())
                {
                    list[i].Price = model.Price;
                    Console.WriteLine($"Du uppdaterade priset på {model.Name} till {model.Price} kr");
                }
            }

            //If if doesn't exist: Add new Vara.
            if (!found)
            {
                model.Name = model.Name.First().ToString().ToUpper() + model.Name.Substring(1).ToLower();
                list.Add(model);
            }


        }

        //Delete vara for WPF-UI
        //public static void DeleteVara(List<VarorModel> list, System.Windows.Controls.ListBox listBox)
        //{
        //    list.Remove((VarorModel)listBox.SelectedItem);

        //}

        ////Delete vara for Windows Forms UI
        //public static void DeleteVara(List<VarorModel> list, System.Windows.Forms.ListBox listBox)
        //{
        //    list.Remove((VarorModel)listBox.SelectedItem);

        //}

        //Calculate most expensive vara
        public static List<VarorModel> MostExpensive(List<VarorModel> list)
        {
            decimal maxPrice = 0;

            List<VarorModel> tomLista = new List<VarorModel>();
            List<VarorModel> mostExpensiveList = new List<VarorModel>();
            VarorModel model = new VarorModel();
            tomLista.Add(new VarorModel("Tom lista", 0));
            try
            {
                maxPrice = list.Max(t => t.Price);
            }
            catch (Exception)
            {
                return tomLista;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Price == maxPrice)
                {
                    mostExpensiveList.Add(list[i]);
                }
            }
            return mostExpensiveList;

        }
        public static VarorModel MostExpensiveModel(List<VarorModel> list)
        {
            decimal maxPrice = 0;
            VarorModel model = new VarorModel("Tom lista", 0);
            try
            {
                maxPrice = list.Max(t => t.Price);
            }
            catch (Exception)
            {
                return model;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Price == maxPrice)
                {
                    model = list[i];
                }
            }
            return model;

        }

        //Calculate cheapest vara - Return as VarorModel or List<VarorModel>.
        public static List<VarorModel> Cheapest(List<VarorModel> list)
        {
            decimal minPrice = 0;
            List<VarorModel> emptyList = new List<VarorModel>();
            List<VarorModel> cheapestList = new List<VarorModel>();
            VarorModel model = new VarorModel();
            emptyList.Add(new VarorModel("Tom lista", 0));

            try
            {
                minPrice = list.Min(t => t.Price);
            }
            catch (Exception)
            {
                return emptyList;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Price == minPrice)
                {
                    cheapestList.Add(list[i]);
                }
            }
            return cheapestList;
        }
        public static VarorModel CheapestModel(List<VarorModel> list)
        {
            decimal minPrice = 0;
            VarorModel model = new VarorModel("Tom lista", 0);
            try
            {
                minPrice = list.Min(t => t.Price);
            }
            catch (Exception)
            {
                return model;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Price == minPrice)
                {
                    model = list[i];
                }
            }
            return model;
        }

        //Calculate sum
        public static decimal Sum(List<VarorModel> list)
        {
            return list.Sum(x => x.Price);
        }


    }
}