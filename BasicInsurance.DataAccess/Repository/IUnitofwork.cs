﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInsurance.DataAccess.Repository
{
    public interface IUnitofwork
    {
        IUnderwritingcaseRepository Underwritingcase { get; set; }
        IAnnuityRepository Annuity { get; set; }

        void Save();
    }
}
