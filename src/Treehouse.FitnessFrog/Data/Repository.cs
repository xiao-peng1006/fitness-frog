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

        public IList<Activity> GetActivities()
        {
            return _context.Activities
                .OrderBy(a => a.Name)
                .ToList();
        }

        public void AddActivities(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
        }
    }
}