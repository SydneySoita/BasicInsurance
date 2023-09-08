using BasicInsurance.DataAccess.Data;
using BasicInsurance.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInsurance.DataAccess.Repository
{
    public class AnnuityRepository : Repository<Annuity>, IAnnuityRepository
    {
        private ApplicationDbContext _db;

        public AnnuityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
           
        }

        public void Update(Annuity obj)
        {
            _db.Annuity.Update(obj);
        }
    }
}
