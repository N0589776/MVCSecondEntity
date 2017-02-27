using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVCWebApp2.Models;

namespace MVCWebApp2.DAL
{
    public class ToDoListInitialiser :  DropCreateDatabaseIfModelChanges<ToDoListContext>
    {
        protected override void Seed(ToDoListContext context)
        {
            var listItems = new List<ToDoListItem> {


                new ToDoListItem {itemNumber = 1, itemText = "Item1", DateAdded = DateTime.Now, Completed = false },
                new ToDoListItem {itemNumber = 2, itemText = "Item2", DateAdded = DateTime.Now, Completed = false },
                new ToDoListItem {itemNumber = 3, itemText = "Item3", DateAdded = DateTime.Now, Completed = true },
                new ToDoListItem {itemNumber = 4, itemText = "Item4", DateAdded = DateTime.Now, Completed = true },
                new ToDoListItem {itemNumber = 5, itemText = "Item5", DateAdded = DateTime.Now, Completed = false },
            };

            listItems.ForEach(s => context.ToDoListItems.Add(s));
            context.SaveChanges();
           
        }
    }
}