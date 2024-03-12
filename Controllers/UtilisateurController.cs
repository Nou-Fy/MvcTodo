using MvcTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TacheMVC.Controllers
{
    public class UtilisateurController : Controller
    {
        // GET: Utilisateur
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inscription(Utilisateur utilisateur)
        {
            DBConnection.InsererUtilisateur(utilisateur);
            return RedirectToAction("Index");
        }
        public ActionResult login(Utilisateur utilisateur)
        {
            return View();
        }
    }
}
