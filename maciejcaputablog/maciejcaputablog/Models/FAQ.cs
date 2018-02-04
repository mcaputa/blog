﻿using System;
using System.ComponentModel.DataAnnotations;

namespace maciejcaputablog.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}