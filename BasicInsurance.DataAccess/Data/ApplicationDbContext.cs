﻿using BasicInsurance.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInsurance.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Undewritingcase> Undewritingcases { get; set; }
    

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
