using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Data
{
    public class Repository
    {
        private Context _context = null;

        public Repository(Context context)
        {
            _context = context;
        }

        public Entry GetEntry(int id)
        {
            return _context.Entries
                .Include(e => e.Activity)
                .Where(e => e.Id == id)
                .SingleOrDefault();
        }

        public IList<Entry> GetEntries()
        {
            return _context.Entries
                .Include(e => e.Activity)
                .OrderByDescending(e => e.Date)
                .ThenByDescending(e => e.Id)
                .ToList();
        }

        public void AddEntry(Entry entry)
        {
            _context.Entries.Add(entry);
            _context.SaveChanges();
        }

        public void UpdateEntry(Entry entry)
        {
            _context.Entry(entry).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEntry(Entry entry)
        {
            _context.Entry(entry).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IList<Activity> GetActivities()
        {
            return _context.Activities
                .OrderBy(a => a.Name)
                .ToList();
        }
    }
}