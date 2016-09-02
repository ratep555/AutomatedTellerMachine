﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Helpers;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;

namespace AutomatedTellerMachine.Controllers
{   [Authorize]
    public class CheckingAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CheckingAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckingAccount/Details/5
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccount = db.Checking.Where(c => c.AplicationUserId == userId).First();

            return View(checkingAccount);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var checkingAccount = db.Checking.Find(id);
            return View("Details",checkingAccount);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult List()
    {
        return View(db.Checking.ToList());
    }
        [HttpGet]
    public ActionResult Statement(int checkingAccountId)
    {
        var checkingAccount = db.Checking.Find(checkingAccountId);
        return View(checkingAccount.Transactions.ToList());
    }
        // GET: CheckingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckingAccount/Create
        [HttpPost]
        public ActionResult Create(CheckingAccount account)
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

        // GET: CheckingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Edit/5
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

        // GET: CheckingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Delete/5
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
