using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Treehouse.FitnessFrog.Models;
using System.Globalization;

namespace Treehouse.FitnessFrog.Data
{
    internal class DatabaseInitizlizer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var biking = new Activity() { Name = "Biking" };
            var hiking = new Activity() { Name = "Hiking" };
            var walking = new Activity() { Name = "Walking" };

            var activity1 = new Entry()
            {
                Id = 1,
                Date = DateTime.ParseExact("2018-03-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Duration = 10.0,
                Activity = biking,
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity1);

            var activity2 = new Entry()
            {
                Id = 2,
                Date = DateTime.ParseExact("2018-03-09", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Duration = 12.2,
                Activity = biking,
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity2);

            var activity3 = new Entry()
            {
                Id = 3,
                Date = DateTime.ParseExact("2018-03-10", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Duration = 123.0,
                Activity = hiking,
                Intensity = Entry.IntensityLevel.High
            };
            context.Entries.Add(activity3);

            var activity4 = new Entry()
            {
                Id = 4,
                Date = DateTime.ParseExact("2018-03-12", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Duration = 11.0,
                Activity = biking,
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity4);

            var activity5 = new Entry()
            {
                Id = 5,
                Date = DateTime.ParseExact("2018-03-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Duration = 32.2,
                Activity = walking,
                Intensity = Entry.IntensityLevel.Low
            };
            context.Entries.Add(activity5);

            var activity6 = new Entry()
            {
                Id = 6,
                Date = DateTime.ParseExact("2018-03-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Duration = 13.3,
                Activity = biking,
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity6);

            var activity7 = new Entry()
            {
                Id = 7,
                Date = DateTime.ParseExact("2018-03-14", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Duration = 10.0,
                Activity = biking,
                Intensity = Entry.IntensityLevel.Medium
            };
            context.Entries.Add(activity7);


            context.SaveChanges();
        }
    }
}