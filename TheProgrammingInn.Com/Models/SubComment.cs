﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheProgrammingInn.Com.Models
{
    public class SubComment : Comment
    {
        public int MainCommentId { get; set; }
        public MainComment MainComment { get; set; }

    }
}