using System.Collections.Generic;
using System.Linq;
using VarorLibrary;

namespace OdeToFood.Data
{
    public class SqlVarorData : IVarorData
    {
        private readonly OdeToFoodDbContext db;

        public SqlVarorData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public VarorModel Add(VarorModel newVara)
        {
            db.Add(newVara);
            return newVara;
         }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public VarorModel Delete(int id)
        {
            var vara = GetById(id);
            if (vara != null)
            {
                db.VarorModel.Remove(vara);
            }
            return vara;
        }

        public VarorModel GetById(int id)
        {
            return db.VarorModel.Find(id);
        }

        public int GetCountofVaror()
        {
            return db.VarorModel.Count();
        }

        public IEnumerable<VarorModel> GetVaraByName(string name)
        {
            var query = db.VarorModel.Where(x => x.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                                      .OrderBy(x => x.Name).Select(x => x);
            return query;
        }

        public IEnumerable<VarorModel> GetVaraByName()
        {
            var query = db.VarorModel.OrderBy(x => x.Name).Select(x => x);

            return query;
        }

        public VarorModel Update(VarorModel updatedVara)
        {
            var entity = db.VarorModel.Attach(updatedVara);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedVara;
        }
    }

}
