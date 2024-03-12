﻿using MvcTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTodo.Controllers
{
    public class TacheController : Controller
    {
        // GET: Tache
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tachelist()
        {
            //DBconnection.listetache(Session["username"].ToString())
            if (Session["username"] != null)
            {
                return View(DBConnection.listetache(Session["username"].ToString()));
            }
            else
            {
                return RedirectToRoute("Accueil");
            }

        }

        public ActionResult Supprimer(int Tacheid)
        {
            DBConnection.SuppresionTache(Tacheid);
            return RedirectToRoute("Accueil");
        }

        // GET: Tache/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tache/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tache/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tache/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tache/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tache/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tache/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
