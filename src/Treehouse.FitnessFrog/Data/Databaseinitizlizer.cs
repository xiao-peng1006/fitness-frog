using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Treehouse.FitnessFrog.Models;
using System.Globalization;

namespace Treehouse.FitnessFrog.Data
{
    internal class Databaseinitizlizer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var activity1 = new Entry()
            {
                Id = 1,
                Date = DateTime.ParseExact("2018-03-03", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Duration = 10.0,
                Activity = new Activity()
                {
                    Name = "Biking"
                },
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity1);

            var activity2 = new Entry()
            {
                Id = 2,
                Date = DateTime.ParseExact("2018-03-09", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Duration = 12.2,
                Activity = new Activity()
                {
                    Name = "Biking"
                },
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity2);

            var activity3 = new Entry()
            {
                Id = 3,
                Date = DateTime.ParseExact("2018-03-10", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Duration = 123.0,
                Activity = new Activity()
                {
                    Name = "Hiking"
                },
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity3);

            var activity4 = new Entry()
            {
                Id = 4,
                Date = DateTime.ParseExact("2018-03-12", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Duration = 11.0,
                Activity = new Activity()
                {
                    Name = "Biking"
                },
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity4);

            var activity5 = new Entry()
            {
                Id = 5,
                Date = DateTime.ParseExact("2018-03-13", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Duration = 32.2,
                Activity = new Activity()
                {
                    Name = "Walking"
                },
                Intensity = Entry.IntensityLevel.Low
            };
            context.Entries.Add(activity5);

            var activity6 = new Entry()
            {
                Id = 6,
                Date = DateTime.ParseExact("2018-03-13", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Duration = 13.3,
                Activity = new Activity()
                {
                    Name = "Biking"
                },
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity6);

            var activity7 = new Entry()
            {
                Id = 7,
                Date = DateTime.ParseExact("2018-03-14", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Duration = 10.0,
                Activity = new Activity()
                {
                    Name = "Biking"
                },
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity7);


            context.SaveChanges();
        }
    }
}