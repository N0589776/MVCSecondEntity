﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp2.Controllers
{
    public class StudentListController : Controller
    {
        // GET: StudentList
        public ActionResult Index()
        {
            return View();
        }
    }
}