﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.BusinessModels.Models
{
    public class PaginatedBaseRequest
    {
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 5;

    }
}
