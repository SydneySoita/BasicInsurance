using BasicInsurance.DataAccess.Data;
using BasicInsurance.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInsurance.DataAccess.Repository
{
    public class UnderwritingcaseRepository : Repository<Undewritingcase>, IUnderwritingcaseRepository
    {
        private ApplicationDbContext _db;

        public UnderwritingcaseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
           
        }

        public void Update(Undewritingcase obj)
        {
            _db.Undewritingcases.Update(obj);
        }
    }
}
