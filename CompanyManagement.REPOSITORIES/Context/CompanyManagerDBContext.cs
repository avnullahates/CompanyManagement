using CompanyManagement.ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.REPOSITORIES.Context
{
    public class CompanyManagerDBContext :DbContext
    {

        public CompanyManagerDBContext(DbContextOptions<CompanyManagerDBContext> options):base(options) 
        { 

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-FA6RBVRG; Database=CompanyManagmentEnocaDb; Uid=sa; Pwd=1234;");
        }


        public DbSet<Firm> Firms { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
