using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVCWebApp2.Models;

namespace MVCWebApp2.DAL
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext() : base("ToDoListConnection") { }

        public DbSet<ToDoListItem> ToDoListItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            
        }
    }
}