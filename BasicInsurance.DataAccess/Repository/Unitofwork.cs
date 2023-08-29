using BasicInsurance.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInsurance.DataAccess.Repository
{
    public class Unitofwork : IUnitofwork
    {
        private ApplicationDbContext _db;
        public IUnderwritingcaseRepository Underwritingcase { get; set; }

        public Unitofwork(ApplicationDbContext db)
        {
            _db = db;
            Underwritingcase = new UnderwritingcaseRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
