using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApp2.DAL;
using MVCWebApp2.Models;

namespace MVCWebApp2.Controllers
{
    public class ToDoListItemsController : Controller
    {
        //Defines the database context within this controller
        private ToDoListContext db = new ToDoListContext();

        // GET: ToDoListItems
        public ActionResult Index()
        {
            return View(db.ToDoListItems.ToList());
        }

        // GET: ToDoListItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Instructs the database context to look for the ID that's been passed into the link
            ToDoListItem toDoListItem = db.ToDoListItems.Find(id);

            //Checks to see if the ID is actually returned
            if (toDoListItem == null)
            {
                //If not returned, show a 'not found' message
                return HttpNotFound();
            }
            //If returned, show the details of the item
            return View(toDoListItem);
        }

        // GET: ToDoListItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoListItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemNumber,itemText,DateAdded,Completed")] ToDoListItem toDoListItem)
        {
            //Checks if the model state is valid
            if (ModelState.IsValid)
            {   //adds a ToDoListItem to the database context
                db.ToDoListItems.Add(toDoListItem);
                //Saves the changes to the database context
                db.SaveChanges();
                //Goes back to the original view for this controller
                return RedirectToAction("Index");
            }
            //If the model state isn't valid, it goes back to the Create view with the item back in
            return View(toDoListItem);
        }

        // GET: ToDoListItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoListItem toDoListItem = db.ToDoListItems.Find(id);
            if (toDoListItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoListItem);
        }

        // POST: ToDoListItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemNumber,itemText,DateAdded,Completed")] ToDoListItem toDoListItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoListItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoListItem);
        }

        // GET: ToDoListItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoListItem toDoListItem = db.ToDoListItems.Find(id);
            if (toDoListItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoListItem);
        }

        // POST: ToDoListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoListItem toDoListItem = db.ToDoListItems.Find(id);
            db.ToDoListItems.Remove(toDoListItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ClearCompleted() {

            foreach (ToDoListItem item in db.ToDoListItems) {

                if (item.Completed == true) {

                    db.ToDoListItems.Remove(item);
                }
                
            }

                db.SaveChanges();

                return RedirectToAction("Index");

        }
            }
}
