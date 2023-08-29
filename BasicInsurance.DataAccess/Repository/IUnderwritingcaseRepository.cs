﻿using BasicInsurance.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInsurance.DataAccess.Repository
{
    public interface IUnderwritingcaseRepository : IRepository<Undewritingcase>
    {
        void Update(Undewritingcase obj);
        void Save();
    }
}
