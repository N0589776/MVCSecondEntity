using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVCWebApp2.Models
{
    [Table("todolistitems")]
    public class ToDoListItem
        
    {
        [Key]
        public int itemNumber { get; set; }

        public string itemText { get; set; }

        public DateTime DateAdded { get; set; }

        public bool Completed { get; set; }



    }
}