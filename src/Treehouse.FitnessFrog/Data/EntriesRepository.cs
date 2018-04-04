using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Data
{
    /// <summary>
    /// The repository for entries.
    /// 
    /// Note: The code in this class is not to be considered a "best practice" 
    /// example of how to do data persistence, but rather as workaround for
    /// not having a database to persist data to.
    /// </summary>
    public class EntriesRepository
    {
        private Context _context = null;

        public EntriesRepository(Context context)
        {
            _context = context;
        }

        public Entry Get(int id)
        {
            return _context.Entries
                .Include(e => e.Activity)
                .Where(e => e.Id == id)
                .SingleOrDefault();
        }

        public IList<Entry> GetList()
        {
            return _context.Entries
                .Include(e => e.Activity)
                .OrderByDescending(e => e.Date)
                .ThenByDescending(e => e.Id)
                .ToList();
        }

        public void Add(Entry entry)
        {
            _context.Entries.Add(entry);
            _context.SaveChanges();
        }

        public void Update(Entry entry)
        {
            _context.Entry(entry).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Entry entry)
        {
            _context.Entry(entry).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}