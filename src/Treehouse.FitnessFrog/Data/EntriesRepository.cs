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
        /// <summary>
        /// Private method that returns a database context.
        /// </summary>
        /// <returns>An instance of the Context class.</returns>
        static Context GetContext()
        {
            var context = new Context();
            context.Database.Log = (message) => Debug.WriteLine(message);
            return context;
        }

        /// <summary>
        /// Returns a count of the comic books.
        /// </summary>
        /// <returns>An integer count of the comic books.</returns>
        public static int GetEntryCount()
        {
            using (Context context = GetContext())
            {
                return context.Entries.Count();
            }
        }

        /// <summary>
        /// Returns a collection of entries.
        /// </summary>
        /// <returns>A list of entries.</returns>
        public IList<Entry> GetEntries()
        {
            using (Context context = GetContext())
            {
                return context.Entries
                        .Include(e => e.Activity)                  
                        .OrderByDescending(e => e.Date)
                        .ThenByDescending(e => e.Id)
                        .ToList();
            }
        }

        /// <summary>
        /// Returns a single entry for the provided ID.
        /// </summary>
        /// <param name="id">The ID for the entry to return.</param>
        /// <returns>An entry.</returns>
        public Entry GetEntry(int id)
        {
            using (Context context = GetContext())
            {
                Entry entry = context.Entries
                .Where(e => e.Id == id)
                .Include(e => e.Activity)
                .SingleOrDefault();

                return entry;
            }
        }

        /// <summary>
        /// Adds an entry.
        /// </summary>
        /// <param name="entry">The entry to add.</param>
        public void AddEntry(Entry entry)
        {
            using (Context context = GetContext())
            {
                // Get the next available entry ID.
                int nextAvailableEntryId = context.Entries
                    .Max(e => e.Id) + 1;

                entry.Id = nextAvailableEntryId;

                context.Entries.Add(entry);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates an entry.
        /// </summary>
        /// <param name="entry">The entry to update.</param>
        public void UpdateEntry(Entry entry)
        {
            using (Context context = GetContext())
            {
                // Find the index of the entry that we need to update.
                context.Entries.Attach(entry);

                var Entry = context.Entry(entry);
                Entry.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes an entry.
        /// </summary>
        /// <param name="id">The ID of the entry to delete.</param>
        public void DeleteEntry(int id)
        {
            using (Context context = GetContext())
            {
                var entry = new Entry() { Id = id };
                context.Entry(entry).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public IList<Activity> GetActivities()
        {
            using (Context context = GetContext())
            {
                return context.Activities
                    .OrderBy(a => a.Name)
                    .ToList();
            }
        }

        public Activity GetActivity(int activityId)
        {
            using (Context context = GetContext())
            {
                return context.Activities
                    .Where(a => a.Id == activityId)
                    .SingleOrDefault();
            }
        }

    }
}