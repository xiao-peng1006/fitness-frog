using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Treehouse.FitnessFrog.Data;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Controllers
{
    public class EntriesController : BaseController
    {
        public ActionResult Index()
        {
            var entries = Repository.GetEntries();

            // Calculate the total activity.
            double totalActivity = entries
                .Where(e => e.Exclude == false)
                .Sum(e => e.Duration);

            // Determine the number of days that have entries.
            int numberOfActiveDays = entries
                .Select(e => e.Date)
                .Distinct()
                .Count();

            ViewBag.TotalActivity = totalActivity;
            ViewBag.AverageDailyActivity = (totalActivity / (double)numberOfActiveDays);

            return View(entries);
        }

        public ActionResult Add()
        {
            var entry = new Entry()
            {
                Date = DateTime.Today
            };

            SetupActivitiesSelectListItems();

            return View(entry);
        }

        [HttpPost]
        public ActionResult Add(Entry entry)
        {
            ValidateEntry(entry);

            if (ModelState.IsValid)
            {
                Repository.AddEntry(entry);

                TempData["Message"] = "Your entry was successfaully added!";

                return RedirectToAction("Index");
            }

            SetupActivitiesSelectListItems();

            return View(entry);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get the requested entry from the repository
            var entry = Repository.GetEntry((int)id);

            // Return a status of "not found" if the entry wasn't found
            if (entry == null)
            {
                return HttpNotFound();
            }

            SetupActivitiesSelectListItems();

            // Pass the entry into the view
            return View(entry);
        }

        [HttpPost]
        public ActionResult Edit(Entry entry)
        {
            // Validate entry
            ValidateEntry(entry);

            // If the entry is valid, use the repository to update entry, redirect user to the list page
            if (ModelState.IsValid)
            {
                Repository.UpdateEntry(entry);

                TempData["Message"] = "Your entry was successfaully updated!";

                return RedirectToAction("Index");
            }

            //Populate the activites selected list items ViewBag property
            SetupActivitiesSelectListItems();

            return View(entry);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Retrieve entry for the provided id parameter value
            var entry = Repository.GetEntry((int)id);

            // Retrun "not found" if entry wasn't found
            if (entry == null)
            {
                return HttpNotFound();
            }

            // Pass entry to the view
            return View(entry);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Delete entry
            var entry = new Entry() { Id = id };

            Repository.DeleteEntry(entry);

            TempData["Message"] = "Your entry was successfaully deleted!";

            // Redirect to the list page
            return RedirectToAction("Index");
        }

        private void ValidateEntry(Entry entry)
        {
            if (ModelState.IsValidField("Duration") && entry.Duration <= 0)
            {
                ModelState.AddModelError("Duration", "The Duration field value must be greater than '0'.");
            }
        }

        private void SetupActivitiesSelectListItems()
        {
            IList<Activity> activities = Repository.GetActivities();
            ViewBag.ActivitiesSelectListItems = new SelectList(activities, "Id", "Name");
        }
    }
}