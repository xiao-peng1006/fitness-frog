using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Treehouse.FitnessFrog.Models
{
    /// <summary>
    /// Represents a physical activity.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Constructors an activity for the provided activity type and name.
        /// </summary>
        /// <param name="activityType">The activity type for the activity.</param>
        /// <param name="name">The name for the activity.</param>
        public Activity()
        {
            Entries = new List<Entry>();
        }

        /// <summary>
        /// The ID of the activity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the activity.
        /// </summary>
        [Required, StringLength(20)]
        public string Name { get; set; }

        public ICollection<Entry> Entries { get; set; }
    }
}