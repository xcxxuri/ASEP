﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Models
{
    public class InterviewFeedbackRequestModel
    {

        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int Rating { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Comment { get; set; }
    }
}

