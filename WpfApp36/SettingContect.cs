using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp36
{
    public class SettingContect: DbContext
    {
        public DbSet<LineStatus> LineStatuses { get; set; }
        public DbSet<KeyValue> KeyValues { get; set; }
        public DbSet<MoDel> MoDels { get; set; }
        public DbSet<ModelTimer> ModelTimers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
}
