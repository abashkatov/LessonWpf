using LessonWpf.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.Service.Context
{
    class AppContext : DbContext
    {
        public DbSet<Phone> phones { get; set; }

        private string DSN;
        public AppContext(string dsn) : base()
        {
            DSN = dsn;
            //Database.Ensu
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DSN);
        }
    }
}
