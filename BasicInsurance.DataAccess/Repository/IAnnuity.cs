using BasicInsurance.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInsurance.DataAccess.Repository
{
    public interface IAnnuityRepository : IRepository<Annuity>
    {
        void Update(Annuity obj);
        void Save();
    }
}
