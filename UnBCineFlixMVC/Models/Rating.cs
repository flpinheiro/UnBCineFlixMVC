﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnBCineFlix.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //public IList<RatingMovie> Movies { get; set; }

        public Rating()
        {
          //  Movies = new List<RatingMovie>();
        }
    }
}
