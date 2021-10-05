﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Controllers
{
    public class Utileros : Controller
    {
        // GET: Utileros
        public ActionResult Index()
        {
            return View();
        }

        // GET: Utileros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utileros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utileros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Utileros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Utileros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Utileros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utileros/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}