﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.DataAccess.Contracts.Models
{
    public class PaginatedDto <T> where T : class
    {
        public List<T> Results { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }

        public PaginatedDto()
        {
            Results = new List<T>();
        }
    }
}
