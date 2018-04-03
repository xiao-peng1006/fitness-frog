using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Treehouse.FitnessFrog.Models
{
    /// <summary>
    /// Represents an activity that has been logged in the Fitness Frog app.
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// The intensity level of the activity.
        /// </summary>
        public enum IntensityLevel
        {
            Low,
            Medium,
            High
        }

        public Entry()
        {
            Activities = new List<Activity>();
        }

        /// <summary>
        /// The ID of the entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date of the entry. Should not include a time portion.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The activity for the entry.
        /// </summary>
        public Activity Activity { get; set; }

        /// <summary>
        /// The duration for the entry (in minutes).
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// The level of intensity for the entry.
        /// </summary>
        public IntensityLevel Intensity { get; set; }

        /// <summary>
        /// Whether or not this entry should be excluded when calculating the total fitness activity.
        /// </summary>
        public bool Exclude { get; set; } = false;

        /// <summary>
        /// The notes for the entry.
        /// </summary>
        [MaxLength(200, ErrorMessage = "The Notes field cannot be longer than 200 characters.")]
        public string Notes { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}