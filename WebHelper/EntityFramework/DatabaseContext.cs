using DnDPlayerSheet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebHelper.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Spell> Spells { get; set; }

        public DbSet<Feat> Feats { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<CombatAction> CombatActions { get; set; }
    }
}
