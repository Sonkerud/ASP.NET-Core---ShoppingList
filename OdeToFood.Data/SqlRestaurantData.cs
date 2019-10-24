//using System.Collections.Generic;
//using System.Linq;
//using RestaurantLibrary;

//namespace OdeToFood.Data
//{
//    public class SqlRestaurantData : IRestaurantData
//    {
//        private readonly OdeToFoodDbContext db;

//        public SqlRestaurantData(OdeToFoodDbContext db)
//        {
//            this.db = db;
//        }

//        public Restaurant Add(Restaurant newRestaurant)
//        {
//            db.Add(newRestaurant);
//            return newRestaurant;
//        }

//        public int Commit()
//        {
//            return db.SaveChanges();
//        }

//        public Restaurant Delete(int id)
//        {
//            var restaurant = GetById(id);
//            if (restaurant != null)
//            {
//                db.Restaurants.Remove(restaurant);
                
//            }
//            return restaurant;
//        }

//        public Restaurant GetById(int id)
//        {
//            return db.Restaurants.Find(id);
//        }

//        public int GetCountofRestaurants()
//        {
//            return db.Restaurants.Count();
//        }

//        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
//        {
//            var query = db.Restaurants.Where(x => x.Name.StartsWith(name) || string.IsNullOrEmpty(name))
//                                      .OrderBy(x => x.Name).Select(x => x);
//            return query;
//        }

//        public Restaurant Update(Restaurant updatedRestaurant)
//        {
//            var entity = db.Restaurants.Attach(updatedRestaurant);
//            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            return updatedRestaurant;
//        }
//    }

//}
