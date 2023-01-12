using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithDataBase
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        private readonly string _path = @"C:\Users\bhanu\Desktop\ConnectWithDataBase\persons.db"; // <=If you put @ mark everything between in "" are going to be Raw string(\,/ neglected)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={_path}");
    }
}
