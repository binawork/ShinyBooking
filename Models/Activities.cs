﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShinyBooking.Models
{
    public class Activities
    {
                public Activities()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<RoomActivities> RoomActivities { get; set; }
    }
}
